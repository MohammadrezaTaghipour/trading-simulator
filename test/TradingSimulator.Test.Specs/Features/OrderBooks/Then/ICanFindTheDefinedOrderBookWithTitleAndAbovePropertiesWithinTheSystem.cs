using FluentAssertions;
using Suzianna.Core.Screenplay.Actors;
using Suzianna.Rest.Screenplay.Questions;
using TechTalk.SpecFlow;
using TradingSimulator.Test.Specs.ScreenPlay.OrderBooks.Commands;
using TradingSimulator.Test.Specs.ScreenPlay.OrderBooks.Questions;

namespace TradingSimulator.Test.Specs.Features.OrderBooks.Then;

[Binding]
public class ICanFindTheDefinedOrderBookWithTitleAndAbovePropertiesWithinTheSystem
{
    private readonly ScenarioContext _context;
    private readonly Actor _actor;

    public ICanFindTheDefinedOrderBookWithTitleAndAbovePropertiesWithinTheSystem(
        ScenarioContext context, Actor actor)
    {
        _context = context;
        _actor = actor;
    }

    [Then("I can find the defined order book with title '(.*)' and above properties within the system")]
    public void Func(string title)

    {
        var expected = _context.Get<DefineOrderBookCommand>(title);
        var expectedId = _actor.AsksFor(LastResponse.Content<Guid>());
        var actual = _actor.AsksFor(new GetOrderBookByIdQuestion(expectedId));

        actual.Should().BeEquivalentTo(expected);
    }
}