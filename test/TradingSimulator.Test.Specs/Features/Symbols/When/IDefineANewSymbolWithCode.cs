using TradingSimulator.Infrastructure.Application;
using TechTalk.SpecFlow;
using TradingSimulator.Test.Specs.ScreenPlay.Symbols.Commands.Symbols;

namespace TradingSimulator.Test.Specs.Features.Symbols.When;

[Binding]
public class IDefineANewSymbolWithCode
{
    private readonly ICommandBus _commandBus;
    private readonly ScenarioContext _context;

    public IDefineANewSymbolWithCode(ICommandBus commandBus, ScenarioContext context)
    {
        _commandBus = commandBus;
        _context = context;
    }

    [When("I define a new symbol with code '(.*)'")]
    public void Func(string code, DefineSymbolCommand command)
    {
        _commandBus.Send(command);
        _context.Set(command, code);
    }
}