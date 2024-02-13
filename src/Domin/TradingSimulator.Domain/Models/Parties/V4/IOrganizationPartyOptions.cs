namespace TradingSimulator.Domain.Models.Parties.V4;

public interface IOrganizationPartyOptions : IPartyOptions
{
    public string NationalId { get; }
}