using FluentAssertions;
using TradingSimulator.Domain.Models.Parties.V2;
using Xunit;

namespace TradingSimulator.Test.Domain.Parties.V2;

public abstract class PartyTests<TBuilder, TParty>
    where TBuilder : PartyTestBuilder<TBuilder, TParty>
    where TParty : Party
{
    protected abstract TBuilder CreateTestBuilder();
    protected TBuilder SutBuilder;
    protected TParty _sut;

    #region Constructor

    #region Happy Path

    [Fact]
    public virtual void It_gets_constructed_without_optional_references()
    {
        // Arrange
        SutBuilder = CreateTestBuilder();

        // Act
        _sut = SutBuilder.Build();

        // Assert
        _sut.Should().BeEquivalentTo<IPartyOptions>(SutBuilder);
    }

    [Fact]
    public void It_gets_constructed_with_Title_with_10_characters()
    {
        // Arrange
        SutBuilder = CreateTestBuilder()
            .WithName("1234567890");

        // Act
        _sut = SutBuilder.Build();

        // Assert
        _sut.Should().BeEquivalentTo<IPartyOptions>(SutBuilder);
    }

    #endregion

    #region Exceptional Path

    [Fact]
    public void It_throws_exception_constructing_with_name_greater_than_10_characters()
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

    #endregion

    #endregion

    #region Update Method

    [Fact]
    public virtual void Update_modifies_all_references()
    {
        // Arrange
        It_gets_constructed_without_optional_references();
        SutBuilder.WithName("name1");

        // Act
        _sut.Update(SutBuilder);

        // Assert
        _sut.Should().BeEquivalentTo<IPartyOptions>(SutBuilder);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Update_Should_Throw_Exception_When_Name_Is_Null_Or_Empty(string name)
    {
        //Arrange
        It_gets_constructed_without_optional_references();
        SutBuilder.WithName(name);

        //Act
        Action act=()=> _sut.Update(SutBuilder);
        
        //Assert
        act.Should().Throw<NullReferenceException>();
    }

    [Fact]
    public void Update_Should_Throw_Exception_When_Name_Is_Greater_Than_10_Characters()
    {
        //Arrange
        It_gets_constructed_without_optional_references();
        SutBuilder.WithInvalidLengthName();

        //Act
        Action act=()=> _sut.Update(SutBuilder);
        
        //Assert
        act.Should().Throw<ArgumentOutOfRangeException>();
    }

    #endregion
}