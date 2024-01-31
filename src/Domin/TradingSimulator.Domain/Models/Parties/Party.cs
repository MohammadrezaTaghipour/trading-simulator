namespace TradingSimulator.Domain.Models.Parties;

public abstract class Party : IPartyOptions
{
    protected Party(string name)
    {
        Name = name;
    }

    public string Name { get; }
}