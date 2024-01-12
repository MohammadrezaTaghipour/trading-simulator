using FluentAssertions;
using Suzianna.Core.Screenplay.Actors;
using TechTalk.SpecFlow;
using TradingSimulator.Test.Specs.ScreenPlay.Sessions.Commands;
using TradingSimulator.Test.Specs.ScreenPlay.Sessions.Questions;

namespace TradingSimulator.Test.Specs.Features.Sessions.Then;

[Binding]
public class ICanFindTheDefinedSessionWithCodeAndAbovePropertiesWithinTheSystem
{
    private readonly ScenarioContext _context;
    private readonly Actor _actor;

    public ICanFindTheDefinedSessionWithCodeAndAbovePropertiesWithinTheSystem(
        ScenarioContext context, Actor actor)
    {
        _context = context;
        _actor = actor;
    }

    [Then("I can find the defined session with code '(.*)' and above properties within the system")]
    public void Func(string code)
    {
        var expected = _context.Get<DefineSessionCommand>(code);
        var actual = _actor.AsksFor(new GetSessionByIdQuestion(expected.Id));

        actual.Should().BeEquivalentTo(expected);
    }
}