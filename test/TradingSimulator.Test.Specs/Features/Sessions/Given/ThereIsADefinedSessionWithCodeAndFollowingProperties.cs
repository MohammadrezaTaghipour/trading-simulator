using TradingSimulator.Infrastructure.Application;
using TechTalk.SpecFlow;
using TradingSimulator.Test.Specs.ScreenPlay.Sessions.Commands;

namespace TradingSimulator.Test.Specs.Features.Sessions.Given;

[Binding]
public class ThereIsADefinedSessionWithCodeAndFollowingProperties
{
    private readonly ICommandBus _commandBus;
    private readonly ScenarioContext _context;

    public ThereIsADefinedSessionWithCodeAndFollowingProperties(
        ICommandBus commandBus,
        ScenarioContext context)
    {
        _commandBus = commandBus;
        _context = context;
    }

    [Given("There is a defined session with code '(.*)' and following properties")]
    public void Func(string code, DefineSessionCommand command)
    {
        _commandBus.Send(command);
        _context.Set(command, code);
    }
}