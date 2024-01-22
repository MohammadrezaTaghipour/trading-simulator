using TradingSimulator.Domain.Models.Shared.Monies;

namespace TradingSimulator.Test.Domain.Monies;

public class MoneyOptionsTestBuilder : IMoneyOptions
{
    private readonly MoneyOptionsBuilder _sutOptionsBuilder = new();

    public decimal Value => _sutOptionsBuilder.Value;


    public MoneyOptionsTestBuilder()
    {
        _sutOptionsBuilder.WithValue(100);
    }

    public MoneyOptionsTestBuilder WithValue(decimal value)
    {
        _sutOptionsBuilder.WithValue(value);
        return this;
    }
    
    public IMoneyOptions Build()
    {
        return _sutOptionsBuilder.Build();
    }
}