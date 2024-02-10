using FluentAssertions;
using TradingSimulator.Domain.Models.Parties.V2;
using Xunit;

namespace TradingSimulator.Test.Domain.Parties.V2;

public abstract class PartyTests<TManger, TBuilder, TParty>
    where TManger : PartyTestManger<TManger, TBuilder, TParty>
    where TBuilder : PartyTestBuilder<TBuilder, TParty>
    where TParty : Party
{
    protected abstract PartyTestManger<TManger, TBuilder, TParty> CreateTestManager();
    protected PartyTestManger<TManger, TBuilder, TParty> _manager;
    protected TParty _sut;

    public PartyTests()
    {
        _manager = CreateTestManager();
    }
    

    #region Constructor

    #region Happy Path

    [Fact]
    public virtual void It_gets_constructed_without_optional_references()
    {
        // Act
        _sut = _manager.Build();

        // Assert
        _sut.Should().BeEquivalentTo<IPartyOptions>(_manager.SutBuilder);
    }

    [Fact]
    public void It_gets_constructed_with_Title_with_10_characters()
    {
        // Arrange
        _manager.WithName("1234567890");

        // Act
        _sut = _manager.Build();

        // Assert
        _sut.Should().BeEquivalentTo<IPartyOptions>(_manager.SutBuilder);
    }

    #endregion

    #region Exceptional Path

    [Fact]
    public void It_throws_exception_constructing_with_name_greater_than_10_characters()
    {
        // Arrange
        _manager.WithInvalidLengthName();

        // Act
        var act = () => _manager.Build();

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
        _manager.WithName(name);

        // Act
        var act = () => _manager.Build();

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
        _manager.WithName("name1");
    
        // Act
        _manager.Update(_sut);
    
        // Assert
        _sut.Should().BeEquivalentTo<IPartyOptions>(_manager.SutBuilder);
    }
    
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Update_Should_Throw_Exception_When_Name_Is_Null_Or_Empty(string name)
    {
        //Arrange
        It_gets_constructed_without_optional_references();
        _manager.WithName(name);
    
        //Act
        Action act = () => _manager.Update(_sut);
    
        //Assert
        act.Should().Throw<NullReferenceException>();
    }
    
    [Fact]
    public void Update_Should_Throw_Exception_When_Name_Is_Greater_Than_10_Characters()
    {
        //Arrange
        It_gets_constructed_without_optional_references();
        _manager.WithInvalidLengthName();
    
        //Act
        Action act = () => _manager.Update(_sut);
    
        //Assert
        act.Should().Throw<ArgumentOutOfRangeException>();
    }
    
    #endregion
}

public class PartyTests : PartyTests<PartyTestManger, PartyTestBuilder, TestParty>
{
    protected override PartyTestManger<PartyTestManger, PartyTestBuilder, TestParty> CreateTestManager()
    {
        _manager = new PartyTestManger();
        return _manager;
    }
}