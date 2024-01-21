using TradingSimulator.Domain.Models.Shared.Monies;

namespace TradingSimulator.Test.Domain.Monies.Fixtures;

public class MoneyTestBuilder : IMoney
{
    private readonly MoneyBuilder _sutBuilder = new();
    
    public decimal Value { get; private set; }


    public MoneyTestBuilder()
    {
        Value = 100;
        _sutBuilder.WithValue(Value);
    }

    public MoneyTestBuilder WithValue(decimal value)
    {
        _sutBuilder.WithValue(value);
        Value = _sutBuilder.Value;
        return this;
    }
    
    public Money Build()
    {
        return _sutBuilder.Build();
    }
}