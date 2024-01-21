﻿using TradingSimulator.Domain.Models.OrderBooks.V2.Entities;
using TradingSimulator.Infrastructure.Domain;

namespace TradingSimulator.Domain.Models.OrderBooks.V2;

public interface IOrderBook : IAggregateRoot<OrderBookId>, IOrderBookOptions
{
    IReadOnlyCollection<IOrder> Orders { get; }
    
    void EnqueueOrder(IOrderOptions options); 
}