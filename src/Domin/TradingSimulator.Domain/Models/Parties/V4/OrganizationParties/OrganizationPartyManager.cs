using TradingSimulator.Domain.Models.Parties.V4.Parties;

namespace TradingSimulator.Domain.Models.Parties.V4.OrganizationParties;

public class OrganizationPartyManager : 
    PartyManager<OrganizationPartyManager, OrganizationParty>,
    IOrganizationPartyOptions
{
    public string NationalId { get;  private set;}

    public OrganizationPartyManager WithNationalId(string value)
    {
        NationalId = value;
        return this;
    }
}