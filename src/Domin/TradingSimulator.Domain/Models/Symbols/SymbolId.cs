namespace TradingSimulator.Domain.Models.Symbols;

public class SymbolId(Guid id)
{
    public Guid Id { get; private set; } = id;

    public static SymbolId New() => new SymbolId(Guid.NewGuid());
}