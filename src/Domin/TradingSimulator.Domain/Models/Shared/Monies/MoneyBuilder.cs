namespace TradingSimulator.Domain.Models.Shared.Monies;

public class MoneyBuilder : IMoneyOptions
{
    public decimal Value { get; private set; }

    public MoneyBuilder WithValue(decimal value)
    {
        Value = value;
        return this;
    }

    public Money Build()
    {
        return new Money(this);
    }
}