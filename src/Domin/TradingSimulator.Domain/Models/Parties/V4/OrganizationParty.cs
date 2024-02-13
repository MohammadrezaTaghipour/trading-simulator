

namespace TradingSimulator.Domain.Models.Parties.V4;

public class OrganizationParty : Party, IOrganizationPartyOptions
{
    public OrganizationParty(IOrganizationPartyOptions options) : base(options)
    {
        NationalId = options.NationalId;
    }

    public string NationalId { get; private set; }
}