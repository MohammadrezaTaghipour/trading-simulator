using TradingSimulator.Domain.Models.Parties.V4.Parties;

namespace TradingSimulator.Domain.Models.Parties.V4.OrganizationParties;

public interface IOrganizationalPartyOptions : IPartyOptions
{
    string NationId { get; }
}