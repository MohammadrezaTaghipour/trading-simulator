using TradingSimulator.Domain.Models.Parties.V4.Parties;

namespace TradingSimulator.Domain.Models.Parties.V4.OrganizationParties;

public interface IOrganizationPartyOptions : IPartyOptions
{
    public string NationalId { get; }
}