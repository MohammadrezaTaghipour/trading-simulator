namespace OrderBookManagement.Infrastructure.Domain;

public class AggregateRoot<TId>
{
    public TId Id { get; protected set; } 
}