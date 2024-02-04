using TradingSimulator.Domain.Models.Parties.V2;

namespace TradingSimulator.Test.Domain.Parties.V3;


public class IndividualPartyTestBuilder : PartyTestBuilder<IndividualPartyTestBuilder>, 
    IIndividualPartyOptions
{
    public IndividualPartyTestBuilder()
    {
        NationCode = "some national code";
    }
    
    public string NationCode { get; private set; }

    public override Party Build()
    {
        return new IndividualParty(this);
    }

    public IndividualPartyTestBuilder WithNationalCode(string value)
    {
        NationCode = value;
        return this;
    }
}