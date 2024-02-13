namespace TradingSimulator.Domain.Models.Parties.V4;
public abstract class Party : IPartyOptions
{
    protected Party(IPartyOptions options)
    {
        Name = options.Name;
    }

    public string Name { get; private set; }
}