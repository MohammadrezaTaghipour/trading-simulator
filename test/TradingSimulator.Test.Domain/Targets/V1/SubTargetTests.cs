﻿using FluentAssertions;
using TradingSimulator.Domain.Models.Targets.V1;
using TradingSimulator.Domain.Models.Targets.V1.Builders;
using TradingSimulator.Test.Domain.Targets.V1.Fixtures;
using Xunit;

namespace TradingSimulator.Test.Domain.Targets.V1;

public class SubTargetTests :
    TargetTests<TestSubTargetManager, SubTarget, SubTargetManager>
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

    [Theory]
    [InlineData("changed name")]
    public override void Update_Should_Be_Done_Successfully(string name)
    {
        //Arrange
        base.Update_Should_Be_Done_Successfully(name);
        Manager.SutBuilder.WithSubName(name);

        //Act
        Manager.Update(SUT);

        //Assert
        SUT.Should().BeEquivalentTo(Manager.SutBuilder);
    }
}