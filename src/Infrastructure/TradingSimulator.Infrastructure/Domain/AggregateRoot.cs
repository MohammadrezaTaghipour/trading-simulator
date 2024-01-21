namespace TradingSimulator.Infrastructure.Domain;

public interface IAggregateRoot<TId>
{
    TId Id { get; }
    IReadOnlyCollection<IDomainEvent> Changes { get; }
}

public abstract class AggregateRoot<TId> : IAggregateRoot<TId>
{
    public TId Id { get; protected set; }
    public long CurrentVersion { get; set; }

    /// <summary>
    /// The collection of new persisted events
    /// </summary>
    private readonly List<IDomainEvent> _pendingChanges = new();

    /// <summary>
    /// Get the list of pending changes (new events) within the scope of the current operation.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> Changes => _pendingChanges.AsReadOnly();

    public void Apply(IDomainEvent @event)
    {
        CurrentVersion += 1;
        _pendingChanges.Add(@event);
    }

    protected void ClearChanges() => _pendingChanges.Clear();
}