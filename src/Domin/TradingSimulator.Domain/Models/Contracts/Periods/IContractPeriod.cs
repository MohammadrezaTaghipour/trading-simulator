namespace TradingSimulator.Domain.Models.Contracts.Periods;

public interface IContractPeriod
{
    DateTime? StartingDateTime { get; }
    DateTime? EndingDateTime { get; }
}