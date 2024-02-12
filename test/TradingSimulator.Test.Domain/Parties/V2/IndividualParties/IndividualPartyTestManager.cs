using TradingSimulator.Domain.Models.Parties.V2;

namespace TradingSimulator.Test.Domain.Parties.V2.IndividualParties;

public class IndividualPartyTestManager :
    PartyTestManger<IndividualPartyTestManager, IndividualPartyTestBuilder, IndividualParty>
{
    protected override PartyTestBuilder<IndividualPartyTestBuilder, IndividualParty> CreateSutBuilder()
    {
        return new IndividualPartyTestBuilder();
    }
    
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
    
    // public  void Update(IndividualParty sut)
    // {
    //     base.Update<IndividualParty>(sut);
    // }
}