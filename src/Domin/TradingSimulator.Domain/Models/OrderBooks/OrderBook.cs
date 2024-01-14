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

        CurrentVersion += 1;
    }

    public void PlaceOrder(PlaceOrderArg arg, IDateTimeProvider dateTimeProvider)
    {
        _orders.Add(new Order(arg.OrderId, arg.TraderId, arg.SessionId,
            arg.SymbolId, arg.Cmd, arg.Volume, arg.Price));
        CurrentVersion += 1;

        var orderPlacedEvent = new OrderPlacedEvent(arg.OrderId, this.Id,
            arg.TraderId, arg.SessionId, arg.SymbolId, arg.Cmd, arg.Volume,
            arg.Price, CurrentVersion);
        Apply(orderPlacedEvent);

        TryMatch(orderPlacedEvent, dateTimeProvider);
    }

    private void TryMatch(OrderPlacedEvent @event, IDateTimeProvider dateTimeProvider)
    {
        if(_incomingBuys.Count == 0 || _incomingSells.Count == 0)
            return;
        
        if (@event.Cmd is OrderCommandType.Sell)
            TryMatchWithBuyOrder(@event, dateTimeProvider);
        else
            TryMatchWithSellOrder(@event, dateTimeProvider);
    }

    private void TryMatchWithBuyOrder(OrderPlacedEvent sellOrder,
        IDateTimeProvider dateTimeProvider)
    {
        var buyOrder = _incomingBuys.Peek();
        if (buyOrder.Price >= sellOrder.Price)
        {
            var matchedPrice = sellOrder.CreatedOn > buyOrder.CreatedOn
                ? sellOrder.Price
                : buyOrder.Price;

            Apply(new OrderMatchedEvent(sellOrder.OrderBookId,
                buyOrder.OrderId, sellOrder.OrderId, matchedPrice, sellOrder.Version));

            if (sellOrder.Volume > buyOrder.Volume)
            {
                _incomingBuys.Dequeue();
                var matchItem = new MatchOrderItem(sellOrder.OrderId,
                    sellOrder.OrderBookId, sellOrder.Volume - buyOrder.Volume,
                    sellOrder.Price, dateTimeProvider.Now());
                _incomingSells.Enqueue(matchItem, matchItem.Price);
            }
            else if (sellOrder.Volume < buyOrder.Volume)
            {
                var matchItem = new MatchOrderItem(sellOrder.OrderId,
                    sellOrder.OrderBookId, buyOrder.Volume - sellOrder.Volume,
                    sellOrder.Price, dateTimeProvider.Now());
                _incomingSells.DequeueEnqueue(matchItem, matchItem.Price);
            }
            else
            {
                _incomingBuys.Dequeue();
            }
        }
        else
        {
            var matchItem = new MatchOrderItem(sellOrder.OrderId,
                sellOrder.OrderBookId, sellOrder.Volume, sellOrder.Price,
                dateTimeProvider.Now());
            _incomingSells.Enqueue(matchItem, matchItem.Price);
        }
    }

    private void TryMatchWithSellOrder(OrderPlacedEvent buyOrder,
        IDateTimeProvider dateTimeProvider)
    {
        var sellOrder = _incomingSells.Peek();
        if (buyOrder.Price >= sellOrder.Price)
        {
            var matchedPrice = buyOrder.CreatedOn > sellOrder.CreatedOn
                ? buyOrder.Price
                : sellOrder.Price;

            Apply(new OrderMatchedEvent(buyOrder.OrderBookId, buyOrder.OrderId,
                sellOrder.OrderId, matchedPrice, buyOrder.Version));

            if (buyOrder.Volume > sellOrder.Volume)
            {
                _incomingSells.Dequeue();
                var matchItem = new MatchOrderItem(buyOrder.OrderId,
                    buyOrder.OrderBookId, buyOrder.Volume - sellOrder.Volume,
                    buyOrder.Price, dateTimeProvider.Now());
                _incomingBuys.Enqueue(matchItem, matchItem);
            }
            else if (buyOrder.Volume < sellOrder.Volume)
            {
                var matchItem = new MatchOrderItem(buyOrder.OrderId,
                    buyOrder.OrderBookId, sellOrder.Volume - buyOrder.Volume,
                    buyOrder.Price, dateTimeProvider.Now());
                _incomingSells.DequeueEnqueue(matchItem, matchItem.Price);
            }
            else
            {
                _incomingSells.Dequeue();
            }
        }
        else
        {
            var matchItem = new MatchOrderItem(buyOrder.OrderId, buyOrder.OrderBookId,
                buyOrder.Volume, buyOrder.Price, dateTimeProvider.Now());
            _incomingBuys.Enqueue(matchItem, matchItem);
        }
    }
}