﻿namespace TradingSimulator.Infrastructure.Domain;

public interface IDomainEvent
{
    Guid EventId { get; }
    DateTime CreatedOn { get; }
}