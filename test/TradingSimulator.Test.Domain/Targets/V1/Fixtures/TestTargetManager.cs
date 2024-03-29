﻿using TradingSimulator.Domain.Models.Targets.V1;
using TradingSimulator.Domain.Models.Targets.V1.Builders;

namespace TradingSimulator.Test.Domain.Targets.V1.Fixtures;

public class TestTargetManager : 
    TestTargetManager<TestTargetManager, TestTarget, TestFuckingTargetManager>
{
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
        SutBuilder.WithTargetName("some name");
    }
    
    public TManager SutBuilder;
    protected abstract TManager CreateManager();
    
    public TTarget Build()
    {
        return SutBuilder.Build();
    }

    public void Update(TTarget sut)
    {
        SutBuilder.Update(sut);
    }
}
