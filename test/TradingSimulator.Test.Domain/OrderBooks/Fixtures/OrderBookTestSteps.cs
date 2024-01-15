using FluentAssertions;
using NSubstitute;
using TradingSimulator.Domain.Models.OrderBooks;
using TradingSimulator.Domain.Models.OrderBooks.Args;
using TradingSimulator.Domain.Models.OrderBooks.Events.OrderBooks;
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

    public void IPlaceAnOrderWithFollowingArguments(PlaceOrderArg arg)
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

    public void ICanFindThePlacedOrderWithAboveArgumentsWithTheOrderBook(PlaceOrderArg arg)
    {
        var sut = _orderBooks[arg.OrderBookId];

        var expected = new Order(arg.OrderId, arg.OrderBookId, arg.TraderId,
            arg.SessionId, arg.SymbolId, arg.Cmd, arg.Volume, arg.Price,
            _dateTimeProvider.Now(), OrderStateEnum.Pending);

        var actual = sut.Orders.Single(a => a.Id == expected.Id);
        actual.Should().BeEquivalentTo(expected);
    }

    public void ICanFindAPublishedEventNameOrderPlacedWithFollowingArguments(PlaceOrderArg arg)
    {
        var actual = _orderBooks[arg.OrderBookId];

        var expected = new OrderPlacedEvent(arg.OrderId, arg.OrderBookId,
            arg.TraderId, arg.SessionId, arg.SymbolId, arg.Cmd,
            arg.Volume, arg.Price, actual.CurrentVersion);

        actual.Changes.OfType<OrderPlacedEvent>().Single()
            .Should()
            .BeEquivalentTo(expected, opt => opt
                .Excluding(x => x.EventId)
                .Excluding(x => x.CreatedOn));
    }

    public void ThereIsAPlacedOrderBookWithTheFollowingArguments(PlaceOrderArg arg)
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

    public void ICanSeeThatMatchOrdersIsOccuredByRaisingTheFollowingEvent(OrderMatchedEvent expected)
    {
        var sut = _orderBooks[expected.OrderBookId];

        var actualSell = sut.Orders.Single(a => a.Id == expected.SellOrder);
        var actualBuy = sut.Orders.Single(a => a.Id == expected.BuyOrder);

        actualSell.State.Should().Be(OrderStateEnum.Matched);
        actualBuy.State.Should().Be(OrderStateEnum.Matched);

        sut.Changes.OfType<OrderMatchedEvent>()
            .Should()
            .ContainEquivalentOf(expected, opt => opt
                .Excluding(x => x.CreatedOn)
                .Excluding(x => x.EventId));
    }

    public void ICanSeeThatMatchOrdersIsOccuredByRaisingTheFollowingEvents(OrderMatchedEvent[] expectations)
    {
        foreach (var expected in expectations)
        {
            var sut = _orderBooks[expected.OrderBookId];
            
            var actualSell = sut.Orders.Single(a => a.Id == expected.SellOrder);
            var actualBuy = sut.Orders.Single(a => a.Id == expected.BuyOrder);

            actualSell.State.Should().Be(OrderStateEnum.Matched);
            actualBuy.State.Should().Be(OrderStateEnum.Matched);

            sut.Changes.OfType<OrderMatchedEvent>()
                .Should()
                .ContainEquivalentOf(expected, opt => opt
                    .Excluding(x => x.CreatedOn)
                    .Excluding(x => x.EventId));
        }

    }
}