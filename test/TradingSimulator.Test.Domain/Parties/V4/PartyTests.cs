using FluentAssertions;
using TradingSimulator.Domain.Models.Parties.V4;
using Xunit;

namespace TradingSimulator.Test.Domain.Parties.V4;

public class PartyTests
{
    [Fact]
    public void Constructor_Should_Create_Without_Optional_References_Successfully()
    {
        //Arrange
        var manager = new PartyTestManager();
        
        //Act
        var sut = manager.Build();
        
        //Arrange
        sut.Should().BeEquivalentTo<IPartyOptions>(manager);
    }
    
}