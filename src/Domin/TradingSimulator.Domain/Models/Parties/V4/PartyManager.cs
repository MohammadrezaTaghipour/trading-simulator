namespace TradingSimulator.Domain.Models.Parties.V4;

public interface IPartyManager<TSelf, TParty> : IPartyOptions
    where TSelf : IPartyManager<TSelf, TParty>
    where TParty : Party
{
    TParty Build();
    TSelf WithName(string value);
}

public abstract class PartyManager<TSelf, TParty> : IPartyManager<TSelf, TParty>
    where TSelf : class, IPartyManager<TSelf, TParty>
    where TParty : Party
{
    public string Name { get; private set; }

    public TParty Build()
    {
        try
        {
            return Activator.CreateInstance(typeof(TParty), this) as TParty;
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

    public static implicit operator TSelf(PartyManager<TSelf, TParty> self) => (self as TSelf)!;
}