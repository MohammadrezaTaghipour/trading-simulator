using TradingSimulator.Domain.Models.Parties.V2;

namespace TradingSimulator.Test.Domain.Parties.V2;

public abstract class PartyTestManger<TManger , TBuilder, TParty> 
    where TManger : PartyTestManger<TManger, TBuilder, TParty>
    where TBuilder : PartyTestBuilder<TBuilder, TParty>
    where TParty : Party
{
    protected abstract PartyTestBuilder<TBuilder, TParty> CreateSutBuilder();
    public TBuilder SutBuilder;

    public PartyTestManger()
    {
        SutBuilder = CreateSutBuilder();
    }
    
    public TManger WithName(string value)
    {
        SutBuilder.WithName(value);
        return (TManger)this;
    }

    public TManger WithInvalidLengthName()
    {
        SutBuilder.WithInvalidLengthName();
        return (TManger)this;
    }
    
    public TParty Build()
    {
        return SutBuilder.Build();
    }

    public virtual void Update(TParty sut)
    {
        sut.Update(SutBuilder);
    }
}


public class PartyTestManger : PartyTestManger<PartyTestManger, PartyTestBuilder, TestParty>
{
    protected override PartyTestBuilder<PartyTestBuilder, TestParty> CreateSutBuilder()
    {
        SutBuilder = new PartyTestBuilder();
        return SutBuilder;
    }
}