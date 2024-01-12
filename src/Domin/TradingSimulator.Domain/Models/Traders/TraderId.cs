namespace TradingSimulator.Domain.Models.Traders;

public class TraderId(Guid id)
{
    public Guid Id { get; private set; } = id;

    public static TraderId New() => new TraderId(Guid.NewGuid());
}