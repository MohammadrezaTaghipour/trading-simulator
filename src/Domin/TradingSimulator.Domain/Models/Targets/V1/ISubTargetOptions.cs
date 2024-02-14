namespace TradingSimulator.Domain.Models.Targets.V1;

public interface ISubTargetOptions : ITargetOptions
{
    string SubTargetName { get; }
}