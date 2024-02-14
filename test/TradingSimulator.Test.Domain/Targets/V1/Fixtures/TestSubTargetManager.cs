using TradingSimulator.Domain.Models.Targets.V1;
using TradingSimulator.Domain.Models.Targets.V1.Managers;

namespace TradingSimulator.Test.Domain.Targets.V1.Fixtures;

public class TestSubTargetManager :
    TestSubTargetManager<TestSubTargetManager, SubTarget, FuckingSubTargetManager>
{
    protected override FuckingSubTargetManager CreateManager()
    {
        return new FuckingSubTargetManager();
    }
}

public class FuckingSubTargetManager : SubTargetManager<FuckingSubTargetManager, SubTarget>
{
}

public abstract class TestSubTargetManager<TSelf, TTarget, TManager>
    : TestTargetManager<TSelf, TTarget, TManager>
    where TSelf : TestSubTargetManager<TSelf, TTarget, TManager>
    where TTarget : ISubTargetOptions
    where TManager : ISubTargetManager<TManager, TTarget>
{
}