namespace TradingSimulator.Infrastructure.Domain;

public interface IEntity<TId>
{
    TId Id { get; }
}