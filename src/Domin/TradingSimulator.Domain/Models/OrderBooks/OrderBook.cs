using System.Text.RegularExpressions;
using TradingSimulator.Infrastructure.Domain;
using TradingSimulator.Domain.Models.OrderBooks.Args;
using TradingSimulator.Domain.Models.OrderBooks.Events.OrderBooks;
using TradingSimulator.Domain.Models.OrderBooks.Orders;
using TradingSimulator.Infrastructure.Utils;

namespace TradingSimulator.Domain.Models.OrderBooks;

public partial class OrderBook : AggregateRoot<OrderBookId>, IOrderBook
{
    protected OrderBook()
    {
    }

    public OrderBook(DefineOrderBookArg arg)
    {
        Id = arg.Id;
        Title = arg.Title;
        SessionId = arg.SessionId;
        SymbolId = arg.SymbolId;
    }

    public void PlaceOrder(PlaceOrderArg arg, IDateTimeProvider dateTimeProvider)
    {
        var order = new Order(arg.OrderId, this.Id, arg.TraderId,
            arg.Cmd, arg.Volume, arg.Price, dateTimeProvider.Now());
        _orders.Add(order);

        TryMatch(order);

        Apply(new OrderPlacedEvent(arg.OrderId, this.Id,
            arg.TraderId, arg.Cmd, arg.Volume, arg.Price));
    }

    private void TryMatch(Order incomingOrder)
    {
        if (incomingOrder.OrderType is OrderType.Sell)
        {
            TryMatchWithBuyOrder(incomingOrder, _incomingBuyOrderQueue);
            if (!incomingOrder.IsMatched())
                _incomingSellOrderQueue.Enqueue(incomingOrder, incomingOrder);
        }
        else
        {
            TryMatchWithBuyOrder(incomingOrder, _incomingSellOrderQueue);
            if (!incomingOrder.IsMatched())
                _incomingBuyOrderQueue.Enqueue(incomingOrder, incomingOrder);
        }
    }

    private void TryMatchWithBuyOrder(Order incomingOrder,
        PriorityQueue<Order, Order> matchingOrderQueue)
    {
        while (!incomingOrder.IsMatched() && matchingOrderQueue.Count > 0)
        {
            var matchingOrder = matchingOrderQueue.Peek();
            if (incomingOrder.CanBeMatchedWith(matchingOrder))
            {
                var matchedVolume = Math.Min(incomingOrder.Volume, matchingOrder.Volume);

                RaiseOrderMatchedEvent(incomingOrder, matchingOrder, matchedVolume);
                
                incomingOrder.ModifyVolume(incomingOrder.Volume - matchedVolume);
                matchingOrder.ModifyVolume(matchingOrder.Volume - matchedVolume);

                if (matchingOrder.IsMatched())
                    matchingOrderQueue.Dequeue();
            }
        }
    }

    private void RaiseOrderMatchedEvent(Order incomingOrder, Order matchingOrder,
        OrderVolume matchedVolume)
    {
        var sellOrderId = incomingOrder.OrderType is OrderType.Sell
            ? incomingOrder.Id
            : matchingOrder.Id;
        var buyOrderId = matchingOrder.OrderType is OrderType.Buy
            ? matchingOrder.Id
            : incomingOrder.Id;

        Apply(new OrderMatchedEvent(this.Id, buyOrderId,
            sellOrderId, matchingOrder.Price, matchedVolume));
    }
}