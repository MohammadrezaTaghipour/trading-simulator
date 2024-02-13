namespace TradingSimulator.Domain.Models.Parties.V4.Parties;

public abstract class PartyManager<TSelf, TParty> : IPartyManager<TSelf, TParty>
    where TSelf : IPartyManager<TSelf, TParty>
    where TParty : class, IPartyOptions
{
    public string Name { get; private set; }

    public TParty Build()
    {
        try
        {
            return (Activator.CreateInstance(typeof(TParty), this) as TParty)!;
        }
        catch (Exception e)
        {
            throw e.InnerException!;
        }
    }

    public TSelf WithName(string value)
    {
        Name = value;
        return this;
    }

    public static implicit operator TSelf(PartyManager<TSelf, TParty> manager)
        => (TSelf)(IPartyManager<TSelf, TParty>)manager;
}