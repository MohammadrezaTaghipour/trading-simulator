using FluentAssertions;
using TradingSimulator.Domain.Models.Parties;
using Xunit;

namespace TradingSimulator.Test.Domain.Parties;

public class PartyTest
{

    [Fact]
    public void Test1()
    {
        // Arrange
        var sutBuilder = new PartyTestBuilder();
        // Act
        var sut = sutBuilder.Build();
        
        // Assert
        sut.Should().BeEquivalentTo<IPartyOptions>(sutBuilder);
    }
}