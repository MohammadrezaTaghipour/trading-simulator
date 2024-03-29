﻿using TradingSimulator.Domain.Models.OrderBooks.V2.Orders;
using TradingSimulator.Infrastructure.Domain;

namespace TradingSimulator.Domain.Models.OrderBooks.V2;

public interface IOrderBook : IAggregateRoot<OrderBookId>, IOrderBookOptions
{
    IEnumerable<IOrder> Orders { get; }
    
    IOrder EnqueueOrder(IOrderOptions options);
    void DequeOrder(OrderId id);
}