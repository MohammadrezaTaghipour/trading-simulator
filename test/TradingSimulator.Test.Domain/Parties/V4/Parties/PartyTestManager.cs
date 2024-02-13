using TradingSimulator.Domain.Models.Parties.V4;
using TradingSimulator.Domain.Models.Parties.V4.Parties;

namespace TradingSimulator.Test.Domain.Parties.V4.Parties;

public abstract class PartyTestManager<TSelf, TParty, TManager>
    where TSelf : PartyTestManager<TSelf, TParty, TManager>
    where TParty : IPartyOptions
    where TManager : IPartyManager<TManager, TParty>
{
    public TManager SutBuilder;
    protected abstract TManager CreateManager();

    protected PartyTestManager()
    {
        SutBuilder = CreateManager();
        SutBuilder.WithName("sample");
    }

    public string Name => SutBuilder.Name;

    public TParty Build()
    {
        return SutBuilder.Build();
    }

    public TSelf WithName(string name)
    {
        SutBuilder.WithName(name);
        return this;
    }

    public static implicit operator TSelf(PartyTestManager<TSelf, TParty, TManager> self)
        => (self as TSelf)!;
}