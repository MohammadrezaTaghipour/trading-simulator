namespace TradingSimulator.Infrastructure.Domain;

public abstract class AggregateRoot<TId>
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

    protected virtual void Apply(IDomainEvent @event)
    {
        @event.Version = CurrentVersion + 1;
        _pendingChanges.Add(@event);
    }
    
    protected void ClearChanges() => _pendingChanges.Clear();
}