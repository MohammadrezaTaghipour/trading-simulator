using FluentAssertions;
using TradingSimulator.Domain.Models.Parties.V2;
using TradingSimulator.Test.Domain.Parties.V2.Parties;
using Xunit;

namespace TradingSimulator.Test.Domain.Parties.V2.IndividualParties;

public class IndividualPartyTest :
    PartyTests<IndividualPartyTestManager, IndividualPartyTestBuilder, IndividualParty>
{
    protected override PartyTestManger<IndividualPartyTestManager, IndividualPartyTestBuilder, IndividualParty>
        CreateTestManager()
    {
        return new IndividualPartyTestManager();
    }

    [Fact]
    public void It_gets_constructed_with_NationCode_with_10_characters()
    {
        // Arrange
        Manager
            .WithName("some name")
            .WithNationalCode("01555487");

        // Act
        Sut = Manager.Build();

        // Assert
        Sut.Should().BeEquivalentTo<IIndividualPartyOptions>(Manager.SutBuilder);
    }

    #region Update Method

    [Fact]
    public override void Update_modifies_all_references()
    {
        //Arrange
        base.Update_modifies_all_references();
        Manager
            .WithName("name2")
            .WithNationalCode("change national code");

        //Act
        Manager.Update(Sut);

        //Assert
        Sut.Should().BeEquivalentTo(Manager.SutBuilder);
    }

    #endregion
}