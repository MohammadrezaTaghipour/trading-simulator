namespace TradingSimulator.Domain.Models.Parties.V1;

public abstract class Party : IPartyOptions
{
    protected Party(string name)
    {
        Name = name;
    }

    public string Name { get; }
}