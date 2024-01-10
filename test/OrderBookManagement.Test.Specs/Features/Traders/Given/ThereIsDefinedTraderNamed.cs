using OrderBookManagement.Infrastructure.Application;
using OrderBookManagement.Test.Specs.ScreenPlay.Traders.Commands;
using TechTalk.SpecFlow;

namespace OrderBookManagement.Test.Specs.Features.Traders.Given;

[Binding]
public class ThereIsDefinedTraderNamed
{
    private readonly ICommandBus _commandBus;
    private readonly ScenarioContext _context;

    public ThereIsDefinedTraderNamed(
        ICommandBus commandBus,
        ScenarioContext context)
    {
        _commandBus = commandBus;
        _context = context;
    }

    [Given("There is defined trader named '(.*)'")]
    public void Func(string trader, DefineTraderCommand command)
    {
        _commandBus.Send(command);
        _context.Set(command, trader);
    }
}