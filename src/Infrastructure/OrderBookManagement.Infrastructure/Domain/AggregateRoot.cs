﻿namespace OrderBookManagement.Infrastructure.Domain;

public abstract class AggregateRoot<TId>
{
    public TId Id { get; protected set; }
}