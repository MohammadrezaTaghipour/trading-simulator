namespace TradingSimulator.Domain.Models.Contracts.V1.Periods;

public interface IContractPeriod
{
    DateTime? StartingDateTime { get; }
    DateTime? EndingDateTime { get; }
}