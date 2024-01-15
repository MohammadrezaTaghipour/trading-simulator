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

        Apply(new OrderPlacedEvent(arg.OrderId, this.Id,
            arg.TraderId, arg.SessionId, arg.SymbolId, arg.Cmd, 
            arg.Volume, arg.Price));

        TryMatch(order);
    }

    private void TryMatch(Order order)
    {
        if (order.Type is OrderType.Sell)
            TryMatchWithBuyOrder(order);
        else
            TryMatchWithSellOrder(order);
    }

    private void TryMatchWithBuyOrder(Order sellOrder)
    {
        if (_incomingBuyOrderQueue.Count == 0)
        {
            _incomingSellOrderQueue.Enqueue(sellOrder, sellOrder.Price.Value);
            return;
        }

        var remainingVolume = new OrderVolume(0);
        do
        {
            var buyOrder = _incomingBuyOrderQueue.Peek();
            if (buyOrder.State is OrderStateEnum.Matched or OrderStateEnum.Closed)
            {
                _incomingBuyOrderQueue.Dequeue();
                continue;
            }

            if (buyOrder.Price >= sellOrder.Price)
            {
                remainingVolume = sellOrder.Volume - buyOrder.Volume;

                if (sellOrder.Volume == buyOrder.Volume)
                {
                    Apply(new OrderMatchedEvent(sellOrder.OrderBookId,
                        buyOrder.Id, sellOrder.Id, sellOrder.Price,
                        sellOrder.Volume));
                    sellOrder.SetAsMatched();
                    buyOrder.SetAsMatched();
                }
                else if (sellOrder.Volume > buyOrder.Volume)
                {
                    Apply(new OrderMatchedEvent(sellOrder.OrderBookId,
                        buyOrder.Id, sellOrder.Id, sellOrder.Price,
                        sellOrder.Volume - buyOrder.Volume));
                    sellOrder.ModifyVolume(sellOrder.Volume - buyOrder.Volume);
                    buyOrder.SetAsMatched();
                }
                else if (sellOrder.Volume < buyOrder.Volume)
                {
                    sellOrder.SetAsMatched();
                    buyOrder.ModifyVolume(buyOrder.Volume - sellOrder.Volume);
                }
            }
            else
            {
                _incomingSellOrderQueue.Enqueue(sellOrder, sellOrder.Price.Value);
            }
        } while (remainingVolume > 0);
    }

    private void TryMatchWithSellOrder(Order buyOrder)
    {
        if (_incomingSellOrderQueue.Count == 0)
        {
            _incomingBuyOrderQueue.Enqueue(buyOrder, buyOrder);
            return;
        }

        var remainingVolume = new OrderVolume(0);
        do
        {
            var sellOrder = _incomingSellOrderQueue.Peek();
            if (sellOrder.State is OrderStateEnum.Matched or OrderStateEnum.Closed)
            {
                _incomingSellOrderQueue.Dequeue();
                continue;
            }

            if (buyOrder.Price >= sellOrder.Price)
            {
                remainingVolume = buyOrder.Volume - sellOrder.Volume;

                if (sellOrder.Volume == buyOrder.Volume)
                {
                    Apply(new OrderMatchedEvent(buyOrder.OrderBookId,
                        buyOrder.Id, sellOrder.Id, buyOrder.Price,
                        buyOrder.Volume));
                    sellOrder.SetAsMatched();
                    buyOrder.SetAsMatched();
                }
                else if (buyOrder.Volume > sellOrder.Volume)
                {
                    Apply(new OrderMatchedEvent(buyOrder.OrderBookId,
                        buyOrder.Id, sellOrder.Id, buyOrder.Price,
                        buyOrder.Volume - sellOrder.Volume));
                    buyOrder.ModifyVolume(buyOrder.Volume - sellOrder.Volume);
                    sellOrder.SetAsMatched();
                }
                else if (buyOrder.Volume < sellOrder.Volume)
                {
                    buyOrder.SetAsMatched();
                    sellOrder.ModifyVolume(sellOrder.Volume - buyOrder.Volume);
                }
            }
            else
            {
                _incomingSellOrderQueue.Enqueue(sellOrder, sellOrder.Price.Value);
            }
        } while (remainingVolume > 0);
    }
}