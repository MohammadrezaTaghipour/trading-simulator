namespace TradingSimulator.Domain.Models.Parties.V2;

public interface IPartyOptions
{
    string Name { get; }
}

public interface IIndividualPartyOptions : IPartyOptions
{
    string NationCode { get; }
}