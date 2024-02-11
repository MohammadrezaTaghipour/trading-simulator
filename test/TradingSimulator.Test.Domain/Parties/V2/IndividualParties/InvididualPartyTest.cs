using FluentAssertions;
using TradingSimulator.Domain.Models.Parties.V2;
using Xunit;

namespace TradingSimulator.Test.Domain.Parties.V2.IndividualParties;

public class IndividualPartyTest :
    PartyTests<IndividualPartyTestManager, IndividualPartyTestBuilder, IndividualParty>
{
    protected override PartyTestManger<IndividualPartyTestManager, IndividualPartyTestBuilder, IndividualParty>
        CreateTestManager()
    {
        _manager = new IndividualPartyTestManager();
        return _manager;
    }
    
    [Fact]
    public void It_gets_constructed_with_NationCode_with_10_characters()
    {
        // Arrange
        _manager
            .WithName("some name")
            .WithNationalCode("01555487");

        // Act
        var sut = _manager.Build();

        // Assert
        sut.Should().BeEquivalentTo<IIndividualPartyOptions>(_manager.SutBuilder);
    }

    #region Update Method

    [Fact]
    public override void Update_modifies_all_references()
    {
        //Arrange
        base.Update_modifies_all_references();
        _manager
            .WithName("name2")
            .WithNationalCode("change national code");
    
        //Act
        _manager.Update(_sut);
    
        //Assert
        _sut.Should().BeEquivalentTo(_manager.SutBuilder);
    }

    #endregion
}