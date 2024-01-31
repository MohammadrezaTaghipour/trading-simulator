using TradingSimulator.Domain.Models.Contracts.V1.Periods;

namespace TradingSimulator.Domain.Models.Contracts.V1;

public interface IContract
{
    string Title { get; }
    IReadOnlyList<IContractPeriod>? Periods { get; }
}