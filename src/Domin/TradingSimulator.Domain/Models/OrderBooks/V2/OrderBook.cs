﻿using TradingSimulator.Domain.Models.OrderBooks.V2.Events;
using TradingSimulator.Domain.Models.OrderBooks.V2.Exceptions;
using TradingSimulator.Domain.Models.OrderBooks.V2.Orders;
using TradingSimulator.Domain.Models.Shared.OrderVolumes;
using TradingSimulator.Infrastructure.Domain;

namespace TradingSimulator.Domain.Models.OrderBooks.V2;

public class OrderBook : AggregateRoot<OrderBookId>, IOrderBook
{
    public string Title { get; private set; }
    public Guid SymbolId { get; private set; }

    private readonly List<Order> _orders = new();
    IEnumerable<IOrder> IOrderBook.Orders => _orders.AsReadOnly();
    IEnumerable<IOrderOptions> IOrderBookOptions.Orders => _orders.AsReadOnly();

    private readonly PriorityQueue<IOrder, IOrder> _incomingBuyOrderQueue = new(new BuyOrderQueueComparer());
    private readonly PriorityQueue<IOrder, IOrder> _incomingSellOrderQueue = new(new SellOrderQueueComparer());

    internal OrderBook(IOrderBookOptions options)
    {
        GuardAgainstEmptyTitle(options);
        GuardAgainstEmptySymbolId(options);

        Id = new OrderBookId(options.SymbolId);
        Title = options.Title;
        SymbolId = options.SymbolId;
    }

    public IOrder EnqueueOrder(IOrderOptions options)
    {
        var incomingOrder = new Order(options);
        _orders.Add(incomingOrder);

        TryMatch(incomingOrder);

        return incomingOrder;
    }

    public void DequeOrder(OrderId id)
    {
        var dequeuingOrder = _orders.Find(o => Equals(o.Id, id));
        if (dequeuingOrder is null)
            throw new OrderNotFount(id);
        dequeuingOrder.SetAsCanceled();
    }

    private void GuardAgainstEmptyTitle(IOrderBookOptions options)
    {
        if (string.IsNullOrEmpty(options.Title))
            throw new OrderBookTitleIsRequired();
    }

    private void GuardAgainstEmptySymbolId(IOrderBookOptions options)
    {
        if (Guid.Empty.Equals(options.SymbolId))
            throw new OrderBookSymbolIdIsRequired();
    }

    private void TryMatch(IOrder incomingOrder)
    {
        if (incomingOrder.OrderType is OrderType.Sell)
        {
            TryMatchWithOtherSideOrder(incomingOrder, _incomingBuyOrderQueue);
            if (!incomingOrder.IsCompletelyMatched())
                _incomingSellOrderQueue.Enqueue(incomingOrder, incomingOrder);
        }
        else
        {
            TryMatchWithOtherSideOrder(incomingOrder, _incomingSellOrderQueue);
            if (!incomingOrder.IsCompletelyMatched())
                _incomingBuyOrderQueue.Enqueue(incomingOrder, incomingOrder);
        }
    }

    private void TryMatchWithOtherSideOrder(IOrder incomingOrder,
        PriorityQueue<IOrder, IOrder> otherSideOrderQueue)
    {
        while (!incomingOrder.IsCompletelyMatched() && otherSideOrderQueue.Count > 0)
        {
            var otherSideOrder = otherSideOrderQueue.Peek();
            if (otherSideOrder.IsCanceled)
                otherSideOrderQueue.Dequeue();

            if (incomingOrder.CanBeMatchedWith(otherSideOrder))
            {
                var matchedVolume = Math.Min(incomingOrder.Volume.Value, otherSideOrder.Volume.Value);

                incomingOrder.IncreaseMatchedVolume(matchedVolume);
                otherSideOrder.IncreaseMatchedVolume(matchedVolume);

                if (otherSideOrder.IsCompletelyMatched())
                    otherSideOrderQueue.Dequeue();

                RaiseOrderMatchedEvent(incomingOrder, otherSideOrder,
                    new OrderVolumeBuilder().WithValue(matchedVolume).Build());
            }
            else
            {
                break;
            }
        }
    }

    private void RaiseOrderMatchedEvent(IOrder incomingOrder, IOrder otherSideOrder,
        IOrderVolume matchedVolume)
    {
        var sellOrderId = incomingOrder.OrderType is OrderType.Sell
            ? incomingOrder.Id
            : otherSideOrder.Id;
        var buyOrderId = otherSideOrder.OrderType is OrderType.Buy
            ? otherSideOrder.Id
            : incomingOrder.Id;

        Apply(new OrderMatchedEventV2(this.Id, buyOrderId,
            sellOrderId, otherSideOrder.Price, matchedVolume));
    }
}