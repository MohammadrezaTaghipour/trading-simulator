using FluentAssertions;
using OrderBookManagement.Test.Specs.ScreenPlay.Sessions.Commands;
using OrderBookManagement.Test.Specs.ScreenPlay.Sessions.Questions;
using Suzianna.Core.Screenplay.Actors;
using TechTalk.SpecFlow;

namespace OrderBookManagement.Test.Specs.Features.Sessions.Then;

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