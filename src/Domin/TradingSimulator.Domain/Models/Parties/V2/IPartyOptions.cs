namespace TradingSimulator.Domain.Models.Parties.V2;

public interface IPartyOptions
{
    string Name { get; }
}

public interface IIndividualPartyOptions : IPartyOptions
{
    string NationCode { get; }
}

public interface IOrganizationalPartyOptions : IPartyOptions
{
    string NationId { get; }
}