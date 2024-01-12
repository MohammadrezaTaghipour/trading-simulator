using TradingSimulator.Infrastructure.Domain;

namespace TradingSimulator.Domain.Models.Symbols;

public class Symbol : AggregateRoot<SymbolId>
{
    private Symbol()
    {
    }

    public Symbol(SymbolId id, string code)
    {
        Id = id;
        Code = code;
    }
    
    public string Code { get; private set; }
}