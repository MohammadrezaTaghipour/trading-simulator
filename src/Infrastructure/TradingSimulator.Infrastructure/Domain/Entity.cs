﻿namespace TradingSimulator.Infrastructure.Domain;

public abstract class Entity<TId>
{
    public TId Id { get; protected set; }
}