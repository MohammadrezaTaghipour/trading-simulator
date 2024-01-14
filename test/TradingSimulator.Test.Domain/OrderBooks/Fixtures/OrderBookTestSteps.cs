using FluentAssertions;
using TradingSimulator.Domain.Models.OrderBooks;
using TradingSimulator.Domain.Models.OrderBooks.Args;
using TradingSimulator.Infrastructure.Domain;

namespace TradingSimulator.Test.Domain.OrderBooks.Fixtures;

public class OrderBookTestSteps : BaseTestStep
{
    private readonly Dictionary<OrderBookId, OrderBook> _orderBooks = new();

    public void IDefineANewOrderBookWithTheFollowingArguments(DefineOrderBookArg arg)
    {
        try
        {
            _orderBooks[arg.Id] = new OrderBook(arg);
        }
        catch (BusinessException e)
        {
            Exception = e;
        }
    }

    public void ICanFindTheDefinedOrderBookWithAbovePropertiesWithinTheSystem(DefineOrderBookArg arg)
    {
        var actual = _orderBooks[arg.Id];

        actual.Id.Should().Be(arg.Id);
        actual.Title.Should().Be(arg.Title);
        actual.SessionId.Should().Be(arg.SessionId);
        actual.SymbolId.Should().Be(arg.SymbolId);
    }
}