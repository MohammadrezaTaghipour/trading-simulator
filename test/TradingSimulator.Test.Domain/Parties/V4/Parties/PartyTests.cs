using FluentAssertions;
using TradingSimulator.Domain.Models.Parties.V4;
using Xunit;

namespace TradingSimulator.Test.Domain.Parties.V4.Parties;

public class PartyTests
{
    protected PartyTestManager Manager;
    protected Party Sut;
    [Fact]
    public virtual void Constructor_Should_Create_Without_Optional_References_Successfully()
    {
        //Arrange
        Manager = new PartyTestManager();
        
        //Act
        Sut = Manager.Build();
        
        //Arrange
        Sut.Should().BeEquivalentTo<IPartyOptions>(Manager);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Constructor_Should_Throw_Exception_When_Name_Is_Null_Or_Empty(string name)
    {
        //Arrange
        Manager = new PartyTestManager().WithName(name);
        
        //Act
        Action action  =()=> Manager.Build();
        
        //Arrange
        action.Should().Throw<ArgumentNullException>();
    }
    
    
}