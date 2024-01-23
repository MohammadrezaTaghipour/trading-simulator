namespace TradingSimulator.Domain.Models.Shared.Monies;

public class MoneyOptionsBuilder : IMoneyOptions
{
    public decimal Value { get; private set; }

    public MoneyOptionsBuilder WithValue(decimal value)
    {
        Value = value;
        return this;
    }

    public Money Build()
    {
        return new Money(this);
    }
}