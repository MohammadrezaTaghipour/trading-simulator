using TradingSimulator.Domain.Models.Targets.V1;
using TradingSimulator.Domain.Models.Targets.V1.Managers;

namespace TradingSimulator.Test.Domain.Targets.V1.Fixtures;

public class TestTargetManager : 
    TestTargetManager<TestTargetManager, TestTarget, TestFuckingTargetManager>
{
    public TestTargetManager()
    {
        SutBuilder.WithTargetName("some name");
    }
    
    protected override TestFuckingTargetManager CreateManager()
    {
        return new TestFuckingTargetManager();
    }
}

public class TestFuckingTargetManager : TargetManager<TestFuckingTargetManager, TestTarget>
{
    
}

public abstract class TestTargetManager<TSelf, TTarget, TManager>
    where TSelf : TestTargetManager<TSelf, TTarget, TManager>
    where TTarget : ITargetOptions
    where TManager : ITargetManager<TManager, TTarget>
{
    protected TestTargetManager()
    {
        SutBuilder = CreateManager();
    }
    
    public TManager SutBuilder;
    protected abstract TManager CreateManager();
    
    public TTarget Build()
    {
        return SutBuilder.Build();
    }
}
