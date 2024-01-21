namespace TradingSimulator.Domain.Models.Symbols;

public class SymbolBuilder : ISymbolOptions
{
    public string Code { get; private set; }

    public SymbolBuilder WithCode(string value)
    {
        Code = value;
        return this;
    }
    
    public Symbol Build()
    {
        return new Symbol(this);
    }
}