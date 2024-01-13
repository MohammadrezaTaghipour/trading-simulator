using TradingSimulator.Infrastructure.Application;
using TechTalk.SpecFlow;
using TradingSimulator.Test.Specs.ScreenPlay.OrderBooks.Commands;

namespace TradingSimulator.Test.Specs.Features.OrderBooks.When;

[Binding]
public class IDefineANewOrderBookWithTitleAndTheFollowingInfo
{
    private readonly ICommandBus _commandBus;
    private readonly ScenarioContext _context;

    public IDefineANewOrderBookWithTitleAndTheFollowingInfo(
        ICommandBus commandBus,
        ScenarioContext context)
    {
        _commandBus = commandBus;
        _context = context;
    }

    [When("I define a new order book with title '(.*)' and the following info")]
    public void Func(string title, DefineOrderBookCommand command)
    {
        _commandBus.Send(command);
        _context.Set(command, title);
    }
}