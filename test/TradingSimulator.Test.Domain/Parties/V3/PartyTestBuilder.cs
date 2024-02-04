using TradingSimulator.Domain.Models.Parties.V2;

namespace TradingSimulator.Test.Domain.Parties.V3;

public class PartyTestBuilder<T> : IPartyOptions where T : PartyTestBuilder<T>
{
    public PartyTestBuilder()
    {
        Name = "some name";
    }

    public string Name { get; private set; }

    public virtual Party Build()
    {
        return new PartyTest(this);
    }

    public T WithInvalidLengthName()
    {
        Name = "werttrewwe3";
        return (T)this;
    }

    public T WithName(string value)
    {
        Name = value;
        return (T)this;
    }
}

public class PartyTestBuilder : PartyTestBuilder<PartyTestBuilder>
{
    
}
