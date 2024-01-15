using TechTalk.SpecFlow;
using TradingSimulator.Infrastructure.Application;
using TradingSimulator.Test.Specs.ScreenPlay.OrderBooks.Commands;

namespace TradingSimulator.Test.Specs.Features.OrderBooks.Given;

[Binding]
public class ThereIsADefinedOrderBookWithTitleAndTheFollowingInfo
{
    private readonly ICommandBus _commandBus;
    private readonly ScenarioContext _context;

    public ThereIsADefinedOrderBookWithTitleAndTheFollowingInfo(
        ICommandBus commandBus,
        ScenarioContext context)
    {
        _commandBus = commandBus;
        _context = context;
    }

    [Given("There Is a defined order book with title '(.*)' and the following info")]
    public void Func(string title, DefineOrderBookCommand command)
    {
        _commandBus.Send(command);
        _context.Set(command, title);
    }
}