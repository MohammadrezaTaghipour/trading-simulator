namespace TradingSimulator.Domain.Models.Targets.V1.Managers;

public interface ISubTargetManager<TSelf, TTarget> : ITargetManager<TSelf, TTarget>, ISubTargetOptions
    where TSelf : ITargetManager<TSelf, TTarget>
    where TTarget : ITargetOptions
{
    
}