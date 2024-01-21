using TradingSimulator.Infrastructure.Domain;

namespace TradingSimulator.Domain.Models.Symbols;

public class Symbol : AggregateRoot<Guid>, ISymbolOptions
{
    internal Symbol(ISymbolOptions options)
    {
        Id = Guid.NewGuid();
        Code = options.Code;
    }
    
    public string Code { get; private set; }
}