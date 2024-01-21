using TradingSimulator.Domain.Models.Symbols;

namespace TradingSimulator.Test.Domain.Symbols;

public class SymbolTestBuilder : ISymbolOptions
{
    private readonly SymbolBuilder _sutBuilder = new();
    public string Code { get; private set; }

    public SymbolTestBuilder()
    {
        Code = "some code";
        _sutBuilder.WithCode(Code); //TODO: ask question from Mr.Mohammadi
    }

    public SymbolTestBuilder WithCode(string value)
    {
        _sutBuilder.WithCode(value);
        Code = _sutBuilder.Code;
        return this;
    }
    
    public Symbol Build()
    {
        return _sutBuilder.Build();
    }
}