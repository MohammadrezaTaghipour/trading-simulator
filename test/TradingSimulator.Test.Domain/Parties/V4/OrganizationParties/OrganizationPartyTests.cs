using TradingSimulator.Domain.Models.Parties.V4;
using TradingSimulator.Domain.Models.Parties.V4.OrganizationParties;
using TradingSimulator.Test.Domain.Parties.V4.Parties;

namespace TradingSimulator.Test.Domain.Parties.V4.OrganizationParties;

public class OrganizationPartyTests :
    PartyTests<OrganizationPartyTestManager, OrganizationParty, OrganizationPartyManager>
{

    public override void Constructor_Should_Create_Without_Optional_References_Successfully()
    {
        base.Constructor_Should_Create_Without_Optional_References_Successfully();

        Console.WriteLine("Test");
    }
}

public class OrganizationPartyTestManager :
    PartyTestManager<OrganizationPartyTestManager, OrganizationParty,OrganizationPartyManager>
{
    protected override OrganizationPartyManager CreateManager()
    {
        return new OrganizationPartyManager();
    }
    
    public OrganizationPartyTestManager()
    {
        SutBuilder.WithNationalId("with some nationalId");
    }
    
    public string NationalId => SutBuilder.NationalId;
}