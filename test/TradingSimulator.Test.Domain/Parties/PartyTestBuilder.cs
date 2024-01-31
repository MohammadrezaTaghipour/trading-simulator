using TradingSimulator.Domain.Models.Parties;

namespace TradingSimulator.Test.Domain.Parties;

public class PartyTestBuilder : IPartyOptions
{
    public PartyTestBuilder()
    {
        Name = "some party";
    }
    
    public string Name { get; }

    public Party Build()
    {
        return new TestParty(Name);
    }
    
    
    public class TestParty : Party
    {
        public TestParty(string name) : base(name)
        {
        }
    }
}