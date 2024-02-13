using FluentAssertions;
using TradingSimulator.Domain.Models.Parties.V4;
using Xunit;

namespace TradingSimulator.Test.Domain.Parties.V4.Parties;

public abstract class PartyTests<TManager, TParty, TTargetManager>
    where TManager : PartyTestManager<TManager, TParty, TTargetManager>
    where TTargetManager : IPartyManager<TTargetManager, TParty>
    where TParty : IPartyOptions
{
    protected TManager Manager;
    protected TParty Sut;

    protected PartyTests()
    {
        Manager = Activator.CreateInstance<TManager>();
    }

    [Fact]
    public virtual void Constructor_Should_Create_Without_Optional_References_Successfully()
    {
        //Arrange
        Sut = Manager.Build();

        //Assert
        Sut.Should().BeEquivalentTo(Manager.SutBuilder);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Constructor_Should_Throw_Exception_When_Name_Is_Null_Or_Empty(string name)
    {
        //Arrange
        Manager.WithName(name);

        //Act
        Action action = () => Manager.Build();

        //Arrange
        action.Should().Throw<ArgumentNullException>();
    }
}