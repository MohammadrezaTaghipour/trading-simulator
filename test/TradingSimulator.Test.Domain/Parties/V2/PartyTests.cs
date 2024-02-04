using FluentAssertions;
using TradingSimulator.Domain.Models.Parties.V2;
using Xunit;

namespace TradingSimulator.Test.Domain.Parties.V2;

public abstract class PartyTests<T> where T : PartyTestBuilder<T>
{
    protected abstract T CreateTestBuilder();
    protected T SutBuilder;

    [Fact]
    public virtual void It_gets_constructed_without_optional_references()
    {
        // Arrange
        SutBuilder = CreateTestBuilder();

        // Act
        var sut = SutBuilder.Build();

        // Assert
        sut.Should().BeEquivalentTo<IPartyOptions>(SutBuilder);
    }

    [Fact]
    public void It_gets_constructed_with_Title_with_10_characters()
    {
        // Arrange
        SutBuilder = CreateTestBuilder()
            .WithName("1234567890");

        // Act
        var sut = SutBuilder.Build();

        // Assert
        sut.Should().BeEquivalentTo<IPartyOptions>(SutBuilder);
    }

    [Fact]
    public void It_throws_exception_constructing_with_Title_great_10_characters()
    {
        // Arrange
        SutBuilder = CreateTestBuilder()
            .WithInvalidLengthName();

        // Act
        var act = () => SutBuilder.Build();

        // Assert
        act.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void It_throws_exception_constructing_with_NullOrEmpty_Title(string name)
    {
        // Arrange
        SutBuilder = CreateTestBuilder()
            .WithName(name);

        // Act
        var act = () => SutBuilder.Build();

        // Assert
        act.Should().Throw<NullReferenceException>();
    }
}