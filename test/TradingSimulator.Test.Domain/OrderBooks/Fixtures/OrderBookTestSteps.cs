using FluentAssertions;
using NSubstitute;
using TradingSimulator.Domain.Models.OrderBooks;
using TradingSimulator.Domain.Models.OrderBooks.Args;
using TradingSimulator.Domain.Models.OrderBooks.Orders;
using TradingSimulator.Infrastructure.Domain;
using TradingSimulator.Infrastructure.Utils;

namespace TradingSimulator.Test.Domain.OrderBooks.Fixtures;

public class OrderBookTestSteps : BaseTestStep
{
    private readonly Dictionary<OrderBookId, OrderBook> _orderBooks = new();
    private readonly IDateTimeProvider _dateTimeProvider;

    public OrderBookTestSteps()
    {
        _dateTimeProvider = Substitute.For<IDateTimeProvider>();
    }

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

    public void ThereIsADefinedOrderBookWithTheFollowingArguments(DefineOrderBookArg arg)
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

    public void TheCurrentDateTimeIs(DateTime dateTime)
    {
        _dateTimeProvider.Now().Returns(dateTime);
    }

    public void IPlaceAnOrderWithFollowingProperties(PlaceOrderArg arg)
    {
        try
        {
            var sut = _orderBooks[arg.OrderBookId];

            sut.PlaceOrder(arg, _dateTimeProvider);
        }
        catch (BusinessException e)
        {
            Exception = e;
        }
    }

    public void ICanFindThePlacedOrderBookWithAbovePropertiesWithTheOrderBook(PlaceOrderArg arg)
    {
        var actual = _orderBooks[arg.OrderBookId];
        var expected = new Order(arg.OrderId, arg.TraderId,
            arg.SessionId, arg.SymbolId, arg.Cmd, arg.Volume, arg.Price);

        actual.Orders.Should().ContainEquivalentOf(expected);
    }
}