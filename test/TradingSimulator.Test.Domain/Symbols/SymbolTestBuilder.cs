using TradingSimulator.Domain.Models.Symbols;

namespace TradingSimulator.Test.Domain.Symbols;

public class SymbolTestBuilder : ISymbolOptions
{
    private readonly SymbolBuilder _sutBuilder = new();
    public string Code => _sutBuilder.Code;

    public SymbolTestBuilder()
    {
        _sutBuilder.WithCode("some code"); 
    }

    public SymbolTestBuilder WithCode(string value)
    {
        _sutBuilder.WithCode(value);
        return this;
    }
    
    public Symbol Build() 
    {
        return _sutBuilder.Build();
    }
}