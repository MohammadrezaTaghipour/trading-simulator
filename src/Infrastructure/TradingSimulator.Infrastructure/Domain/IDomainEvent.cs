namespace TradingSimulator.Infrastructure.Domain;

public interface IDomainEvent
{
    Guid EventId { get; }
    DateTime PublishedOn { get; }
    long Version { get; set; }
}