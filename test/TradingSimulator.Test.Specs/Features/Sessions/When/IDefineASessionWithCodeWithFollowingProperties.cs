using TradingSimulator.Infrastructure.Application;
using TechTalk.SpecFlow;
using TradingSimulator.Test.Specs.ScreenPlay.Sessions.Commands;

namespace TradingSimulator.Test.Specs.Features.Sessions.When;

[Binding]
public class IDefineASessionWithCodeWithFollowingProperties
{
    private readonly ICommandBus _commandBus;
    private readonly ScenarioContext _context;

    public IDefineASessionWithCodeWithFollowingProperties(
        ICommandBus commandBus, 
        ScenarioContext context)
    {
        _commandBus = commandBus;
        _context = context;
    }
    
    [When("I define a session with code '(.*)' and with following properties")]
    public void Func(string code, DefineSessionCommand command)
    {
        _commandBus.Send(command);
        _context.Set(command, code);
    }
}