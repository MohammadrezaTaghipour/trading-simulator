using TradingSimulator.Domain.Models.Parties.V2;

namespace TradingSimulator.Test.Domain.Parties.V2.Parties;

public abstract class PartyTestBuilder<TSelf, TParty> : IPartyOptions
    where TSelf : PartyTestBuilder<TSelf, TParty>
    where TParty : Party
{
    protected PartyTestBuilder()
    {
        Name = "some name";
    }

    public string Name { get; private set; }

    public TParty Build()
    {
        try
        {
            return Activator.CreateInstance(typeof(TParty), this) as TParty;
        }
        catch (Exception e)
        {
            throw e.InnerException;
        }
    }

    public TSelf WithInvalidLengthName()
    {
        Name = "werttrewwe3";
        return this;
    }

    public TSelf WithName(string value)
    {
        Name = value;
        return this;
    }

    public static implicit operator TSelf(PartyTestBuilder<TSelf, TParty> self) => (self as TSelf)!;
}

public class PartyTestBuilder : PartyTestBuilder<PartyTestBuilder, TestParty>
{
}