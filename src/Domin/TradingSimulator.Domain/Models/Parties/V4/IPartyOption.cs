namespace TradingSimulator.Domain.Models.Parties.V4;

public interface IPartyOptions
{
    string Name { get;  }
}

public interface IOrganizationPartyOptions : IPartyOptions
{
    public string NationalId { get; }
}