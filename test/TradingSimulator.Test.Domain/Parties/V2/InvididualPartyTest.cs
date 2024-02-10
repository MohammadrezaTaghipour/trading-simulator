using FluentAssertions;
using TradingSimulator.Domain.Models.Parties.V2;
using Xunit;

namespace TradingSimulator.Test.Domain.Parties.V2;

public class IndividualPartyTest :
    PartyTests<IndividualPartyTestBuilder, IndividualParty>
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

    #region Update Method

    [Fact]
    public override void Update_modifies_all_references()
    {
        //Arrange
        base.Update_modifies_all_references();
        SutBuilder
            .WithName("name2")
            .WithNationalCode("change national code");

        //Act
        _sut.Update(SutBuilder);

        //Assert
        _sut.Should().BeEquivalentTo(SutBuilder);
    }

    #endregion
}