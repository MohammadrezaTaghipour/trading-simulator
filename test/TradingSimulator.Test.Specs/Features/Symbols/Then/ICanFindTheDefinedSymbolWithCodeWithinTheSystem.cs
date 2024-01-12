using FluentAssertions;
using Suzianna.Core.Screenplay.Actors;
using TechTalk.SpecFlow;
using TradingSimulator.Test.Specs.ScreenPlay.Symbols.Commands.Symbols;
using TradingSimulator.Test.Specs.ScreenPlay.Symbols.Questions;

namespace TradingSimulator.Test.Specs.Features.Symbols.Then;

[Binding]
public class ICanFindTheDefinedSymbolWithCodeWithinTheSystem
{
    private readonly ScenarioContext _context;
    private readonly Actor _actor;

    public ICanFindTheDefinedSymbolWithCodeWithinTheSystem(ScenarioContext context, Actor actor)
    {
        _context = context;
        _actor = actor;
    }

    [Then("I can find the defined symbol with code '(.*)' within the system")]
    public void Func(string code)
    {
        var expected = _context.Get<DefineSymbolCommand>(code);
        var actual = _actor.AsksFor(new GetSymbolByIdQuestion(expected.Id));

        actual.Should().BeEquivalentTo(expected);
    }
}