using TradingSimulator.Domain.Models.Parties.V2;

namespace TradingSimulator.Test.Domain.Parties.V2;

public class IndividualPartyTestManager :
    PartyTestManger<IndividualPartyTestManager, IndividualPartyTestBuilder, IndividualParty>
{
    public IndividualPartyTestBuilder SutBuilder = new();

    public IndividualPartyTestManager WithNationalCode(string nationalCode)
    {
        SutBuilder.WithNationalCode(nationalCode);
        return this;
    }

    public override void Update(IndividualParty sut)
    {
        base.Update(sut);
        sut.Update(SutBuilder);
    }

    protected override PartyTestBuilder<IndividualPartyTestBuilder, IndividualParty> CreateSutBuilder()
    {
        SutBuilder = new IndividualPartyTestBuilder();
        return SutBuilder;
    }
}