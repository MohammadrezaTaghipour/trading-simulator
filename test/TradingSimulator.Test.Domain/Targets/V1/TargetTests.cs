using FluentAssertions;
using TradingSimulator.Domain.Models.Targets.V1;
using TradingSimulator.Domain.Models.Targets.V1.Builders;
using TradingSimulator.Test.Domain.Targets.V1.Fixtures;
using Xunit;

namespace TradingSimulator.Test.Domain.Targets.V1;

public class TargetTests :
    TargetTests<TestTargetManager, TestTarget, TestFuckingTargetManager>
{
}

public abstract class TargetTests<TTestManager, TTarget, TManager>
    where TTestManager : TestTargetManager<TTestManager, TTarget, TManager>
    where TTarget : ITargetOptions
    where TManager : ITargetManager<TManager, TTarget>
{
    protected TargetTests()
    {
        Manager = Activator.CreateInstance<TTestManager>();
    }

    protected TestTargetManager<TTestManager, TTarget, TManager> Manager;

    [Fact]
    public void Constructor_should_create_properly_without_optional_references()
    {
        // Arrange

        // Act
        var sut = Manager.Build();

        // Assert
        sut.Should().BeEquivalentTo<TManager>(Manager.SutBuilder);
    }

    [Theory, InlineData(""), InlineData(" "), InlineData(null)]
    public void Constructor_should_throw_exception_when_Name_is_NullOrWhiteSpace(string name)
    {
        // Arrange
        Manager.SutBuilder.WithTargetName(name);

        // Act
        var act = () => Manager.Build();

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }
}