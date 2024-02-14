using TradingSimulator.Domain.Models.Targets.V1;
using TradingSimulator.Domain.Models.Targets.V1.Managers;

namespace TradingSimulator.Test.Domain.Targets.V1.Fixtures;

public abstract class TestSubTargetManager<TSelf, TTarget, TManager>
    : TestTargetManager<TSelf, TTarget, TManager>
    where TSelf : TestSubTargetManager<TSelf, TTarget, TManager>
    where TTarget : ITargetOptions
    where TManager : ISubTargetManager<TManager, TTarget>
{
    public TSelf WithSubName(string value)
    {
        
        return this;
    }
}