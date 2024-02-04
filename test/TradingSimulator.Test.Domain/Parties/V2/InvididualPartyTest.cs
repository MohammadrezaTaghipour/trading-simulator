using FluentAssertions;
using TradingSimulator.Domain.Models.Parties.V2;
using Xunit;

namespace TradingSimulator.Test.Domain.Parties.V2;

public class IndividualPartyTest : PartyTests<IndividualPartyTestBuilder>
{
    protected override IndividualPartyTestBuilder CreateTestBuilder()
    {
        return new IndividualPartyTestBuilder();
    }

    [Fact]
    public void It_gets_constructed_with_NationCode_with_10_characters()
    {
        // Arrange
        SutBuilder = CreateTestBuilder()
            .WithName("some name")
            .WithNationalCode("01555487");

        // Act
        var sut = SutBuilder.Build();

        // Assert
        sut.Should().BeEquivalentTo<IIndividualPartyOptions>(SutBuilder);
    }
}