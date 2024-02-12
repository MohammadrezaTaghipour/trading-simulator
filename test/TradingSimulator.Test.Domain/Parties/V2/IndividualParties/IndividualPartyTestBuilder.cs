using TradingSimulator.Domain.Models.Parties.V2;
using TradingSimulator.Test.Domain.Parties.V2.Parties;

namespace TradingSimulator.Test.Domain.Parties.V2.IndividualParties;

public class IndividualPartyTestBuilder : PartyTestBuilder<IndividualPartyTestBuilder, IndividualParty>,
    IIndividualPartyOptions
{
    public IndividualPartyTestBuilder()
    {
        NationCode = "some national code";
    }

    public string NationCode { get; private set; }

    public IndividualPartyTestBuilder WithNationalCode(string value)
    {
        NationCode = value;
        return this;
    }
}