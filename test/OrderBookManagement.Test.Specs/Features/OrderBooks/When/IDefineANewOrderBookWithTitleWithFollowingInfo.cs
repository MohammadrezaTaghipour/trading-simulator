using OrderBookManagement.Infrastructure.Application;
using OrderBookManagement.Test.Specs.ScreenPlay.OrderBooks.Commands;
using TechTalk.SpecFlow;

namespace OrderBookManagement.Test.Specs.Features.OrderBooks.When;

[Binding]
public class IDefineANewOrderBookWithTitleWithFollowingInfo
{
    private readonly ICommandBus _commandBus;
    private readonly ScenarioContext _context;

    public IDefineANewOrderBookWithTitleWithFollowingInfo(
        ICommandBus commandBus,
        ScenarioContext context)
    {
        _commandBus = commandBus;
        _context = context;
    }

    [When("I define a new order book with title '(.*)' with following info")]
    public void Func(string title, DefineOrderBookCommand command)
    {
        _commandBus.Send(command);
        _context.Set(command, title);
    }
}