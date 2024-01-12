namespace TradingSimulator.Domain.Models.Sessions;

public class SessionId(Guid id)
{
    public Guid Id { get; private set; } = id;

    public static SessionId New() => new SessionId(Guid.NewGuid());
}