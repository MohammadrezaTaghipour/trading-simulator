using FluentAssertions;
using TradingSimulator.Domain.Models.Targets.V1;
using TradingSimulator.Domain.Models.Targets.V1.Managers;
using TradingSimulator.Test.Domain.Targets.V1.Fixtures;
using Xunit;

namespace TradingSimulator.Test.Domain.Targets.V1;

public abstract class SubTargetTests<TTestManager, TTarget, TManager> : 
    TargetTests<TTestManager, TTarget, TManager>
    where TTestManager : TestSubTargetManager<TTestManager, TTarget, TManager>
    where TTarget : ITargetOptions
    where TManager : ITargetManager<TManager, TTarget>
{
    
    [Theory, InlineData(""), InlineData(" "), InlineData(null)]
    public void Constructor_should_throw_exception_when_SubName_is_NullOrWhiteSpace(string name)
    {
        // Arrange
        Manager.SutBuilder.with(name);

        // Act
        var act = () => Manager.Build();

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }
}