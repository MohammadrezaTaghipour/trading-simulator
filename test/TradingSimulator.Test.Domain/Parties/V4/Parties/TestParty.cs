using TradingSimulator.Domain.Models.Parties.V4;
using TradingSimulator.Domain.Models.Parties.V4.Parties;

namespace TradingSimulator.Test.Domain.Parties.V4.Parties;

public class TestParty : Party
{
    public TestParty(IPartyOptions options) : base(options)
    {
    }
}