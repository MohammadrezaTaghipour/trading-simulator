using FluentAssertions;
using TradingSimulator.Domain.Models.Targets.V1;
using TradingSimulator.Test.Domain.Targets.V1.Fixtures;
using Xunit;

namespace TradingSimulator.Test.Domain.Targets.V1;

public abstract class SubTargetTests :
    TargetTests<TestSubTargetManager, SubTarget, FuckingSubTargetManager>
{
    
    [Theory, InlineData(""), InlineData(" "), InlineData(null)]
    public void Constructor_should_throw_exception_when_SubName_is_NullOrWhiteSpace(string name)
    {
        // Arrange
        Manager.SutBuilder.WithSubName(name);

        // Act
        var act = () => Manager.Build();

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }
}