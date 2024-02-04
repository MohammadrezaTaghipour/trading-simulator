namespace TradingSimulator.Domain.Models.Parties.V1;

public interface IPartyOptions
{
    string Name { get; }
}

public interface IIndividualOptions : IPartyOptions
{
    string NationCode { get; }
}

public interface IOrganizationOptions : IPartyOptions
{
    string NationId { get; }
}