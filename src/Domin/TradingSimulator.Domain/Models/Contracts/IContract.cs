using TradingSimulator.Domain.Models.Contracts.Periods;

namespace TradingSimulator.Domain.Models.Contracts;

public interface IContract
{
    string Title { get; }
    IReadOnlyList<IContractPeriod>? Periods { get; }
}