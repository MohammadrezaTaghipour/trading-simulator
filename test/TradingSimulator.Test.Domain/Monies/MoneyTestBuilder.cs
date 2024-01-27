using TradingSimulator.Domain.Models.Shared.Monies;

namespace TradingSimulator.Test.Domain.Monies;

public class MoneyTestBuilder : IMoney
{
    private readonly MoneyBuilder _sutBuilder = new();

    public decimal Value => _sutBuilder.Value;


    public MoneyTestBuilder()
    {
        _sutBuilder.WithValue(100);
    }

    public MoneyTestBuilder WithValue(decimal value)
    {
        _sutBuilder.WithValue(value);
        return this;
    }
    
    public Money Build()
    {
        return _sutBuilder.Build();
    }
}