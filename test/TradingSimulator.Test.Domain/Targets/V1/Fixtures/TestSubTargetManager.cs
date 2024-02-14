using TradingSimulator.Domain.Models.Targets.V1;
using TradingSimulator.Domain.Models.Targets.V1.Builders;

namespace TradingSimulator.Test.Domain.Targets.V1.Fixtures;

public class TestSubTargetManager :
    TestSubTargetManager<TestSubTargetManager, SubTarget, SubTargetManager>
{
    protected override SubTargetManager CreateManager()
    {
        return new SubTargetManager();
    }
}

public abstract class TestSubTargetManager<TSelf, TTarget, TManager>
    : TestTargetManager<TSelf, TTarget, TManager>
    where TSelf : TestSubTargetManager<TSelf, TTarget, TManager>
    where TTarget : ISubTargetOptions
    where TManager : ISubTargetManager<TManager, TTarget>
{
}