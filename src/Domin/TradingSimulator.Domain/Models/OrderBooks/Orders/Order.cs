﻿using TradingSimulator.Domain.Models.Traders;
using TradingSimulator.Infrastructure.Domain;

namespace TradingSimulator.Domain.Models.OrderBooks.Orders;

public class Order : Entity<OrderId>
{
    public Order(OrderId id, OrderBookId orderBookId,
        TraderId traderId, OrderType orderType,
        OrderVolume volume, Money price,
        DateTime createdOn)
    {
        Id = id;
        OrderBookId = orderBookId;
        TraderId = traderId;
        OrderType = orderType;
        Volume = volume;
        Price = price;
        CreatedOn = createdOn;
    }

    public OrderBookId OrderBookId { get; private set; }
    public TraderId TraderId { get; private set; }
    public OrderType OrderType { get; private set; }
    public OrderVolume Volume { get; private set; }
    public Money Price { get; private set; }
    public DateTime CreatedOn { get; private set; }

    public void ModifyVolume(OrderVolume volume)
    {
        Volume = volume;
    }

    public bool IsMatched()
    {
        return Volume == 0;
    }

    public bool CanBeMatchedWith(Order matchingOrder)
    {
        if (OrderType is OrderType.Buy)
            return Price >= matchingOrder.Price;
        return matchingOrder.Price <= Price;
    }
}