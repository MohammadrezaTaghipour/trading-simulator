using FizzWare.NBuilder;
using TestStack.BDDfy;
using TradingSimulator.Domain.Models.OrderBooks.V1.Events;
using TradingSimulator.Domain.Models.OrderBooks.V1.Orders;
using TradingSimulator.Domain.Models.Sessions;
using TradingSimulator.Domain.Models.Traders;
using TradingSimulator.Test.Domain.OrderBooks.V1.Fixtures;
using Xunit;

namespace TradingSimulator.Test.Domain.OrderBooks.V1;

public class When_matching_buyOrder
{
    private readonly OrderBookTestSteps _ = new();

    [Fact]
    public void BuyOrder_gets_matched_with_sellOrder_when_buyPrice_is_greaterThan_sellPrice()
    {
        var orderBookArguments = DefineOrderBookArgBuilder.Builder
            .With(a => a.Title, "order-book-A")
            .With(a => a.SessionId, SessionId.New())
            .With(a => a.SymbolId, Guid.NewGuid())
            .Build();

        var sellOrderArguments = PlaceOrderArgBuilder.Builder
            .With(a => a.OrderId, OrderId.New())
            .With(a => a.OrderBookId, orderBookArguments.Id)
            .With(a => a.TraderId, TraderId.New())
            .With(a => a.SessionId, orderBookArguments.SessionId)
            .With(a => a.SymbolId, orderBookArguments.SymbolId)
            .With(a => a.Cmd, OrderType.Sell)
            .With(a => a.Volume, new OrderVolume(100))
            // .With(a => a.Price, new Money(300))
            .Build();

        var buyOrderArguments = PlaceOrderArgBuilder.Builder
            .With(a => a.OrderId, OrderId.New())
            .With(a => a.OrderBookId, orderBookArguments.Id)
            .With(a => a.TraderId, TraderId.New())
            .With(a => a.SessionId, orderBookArguments.SessionId)
            .With(a => a.SymbolId, orderBookArguments.SymbolId)
            .With(a => a.Cmd, OrderType.Buy)
            .With(a => a.Volume, new OrderVolume(100))
            // .With(a => a.Price, new Money(500))
            .Build();

        var expected = new OrderMatchedEvent(orderBookArguments.Id,
            buyOrderArguments.OrderId, sellOrderArguments.OrderId,
            sellOrderArguments.Price, buyOrderArguments.Volume);

        this
            .Given(__ => _.TheCurrentDateTimeIs(DateTime.Now))
            .And(__ => _.ThereIsADefinedOrderBookWithTheFollowingArguments(orderBookArguments))
            .And(__ => _.ThereIsAPlacedOrderBookWithTheFollowingArguments(sellOrderArguments))
            .When(__ => _.IPlaceAnOrderWithFollowingArguments(buyOrderArguments))
            .Then(__ => _.ICanSeeThatMatchOrdersIsOccuredByRaisingTheFollowingEvent(expected))
            .BDDfy();
    }

    [Fact]
    public void BuyOrder_also_gets_matched_with_sellOrder_when_buyPrice_is_equal_to_sellPrice()
    {
        var orderBookArguments = DefineOrderBookArgBuilder.Builder
            .With(a => a.Title, "order-book-A")
            .With(a => a.SessionId, SessionId.New())
            .With(a => a.SymbolId, Guid.NewGuid())
            .Build();

        var sellOrderArguments = PlaceOrderArgBuilder.Builder
            .With(a => a.OrderId, OrderId.New())
            .With(a => a.OrderBookId, orderBookArguments.Id)
            .With(a => a.TraderId, TraderId.New())
            .With(a => a.SessionId, orderBookArguments.SessionId)
            .With(a => a.SymbolId, orderBookArguments.SymbolId)
            .With(a => a.Cmd, OrderType.Sell)
            .With(a => a.Volume, new OrderVolume(100))
            // .With(a => a.Price, new Money(500))
            .Build();

        var buyOrderArguments = PlaceOrderArgBuilder.Builder
            .With(a => a.OrderId, OrderId.New())
            .With(a => a.OrderBookId, orderBookArguments.Id)
            .With(a => a.TraderId, TraderId.New())
            .With(a => a.SessionId, orderBookArguments.SessionId)
            .With(a => a.SymbolId, orderBookArguments.SymbolId)
            .With(a => a.Cmd, OrderType.Buy)
            .With(a => a.Volume, new OrderVolume(100))
            // .With(a => a.Price, new Money(500))
            .Build();

        var expected = new OrderMatchedEvent(orderBookArguments.Id,
            buyOrderArguments.OrderId, sellOrderArguments.OrderId,
            buyOrderArguments.Price, buyOrderArguments.Volume);

        this
            .Given(__ => _.TheCurrentDateTimeIs(DateTime.Now))
            .And(__ => _.ThereIsADefinedOrderBookWithTheFollowingArguments(orderBookArguments))
            .And(__ => _.ThereIsAPlacedOrderBookWithTheFollowingArguments(sellOrderArguments))
            .When(__ => _.IPlaceAnOrderWithFollowingArguments(buyOrderArguments))
            .Then(__ => _.ICanSeeThatMatchOrdersIsOccuredByRaisingTheFollowingEvent(expected))
            .BDDfy();
    }

    [Fact]
    public void BuyOrder_gets_matched_with_multiple_sellOrders_when_it_has_greater_volume_than_sellOrder_volume()
    {
        var orderBookArguments = DefineOrderBookArgBuilder.Builder
            .With(a => a.Title, "order-book-A")
            .With(a => a.SessionId, SessionId.New())
            .With(a => a.SymbolId, Guid.NewGuid())
            .Build();

        var sellOrderArguments1 = PlaceOrderArgBuilder.Builder
            .With(a => a.OrderId, OrderId.New())
            .With(a => a.OrderBookId, orderBookArguments.Id)
            .With(a => a.TraderId, TraderId.New())
            .With(a => a.SessionId, orderBookArguments.SessionId)
            .With(a => a.SymbolId, orderBookArguments.SymbolId)
            .With(a => a.Cmd, OrderType.Sell)
            .With(a => a.Volume, new OrderVolume(100))
            // .With(a => a.Price, new Money(400))
            .Build();

        var sellOrderArguments2 = PlaceOrderArgBuilder.Builder
            .With(a => a.OrderId, OrderId.New())
            .With(a => a.OrderBookId, orderBookArguments.Id)
            .With(a => a.TraderId, TraderId.New())
            .With(a => a.SessionId, orderBookArguments.SessionId)
            .With(a => a.SymbolId, orderBookArguments.SymbolId)
            .With(a => a.Cmd, OrderType.Sell)
            .With(a => a.Volume, new OrderVolume(100))
            // .With(a => a.Price, new Money(400))
            .Build();

        var buyOrderArguments = PlaceOrderArgBuilder.Builder
            .With(a => a.OrderId, OrderId.New())
            .With(a => a.OrderBookId, orderBookArguments.Id)
            .With(a => a.TraderId, TraderId.New())
            .With(a => a.SessionId, orderBookArguments.SessionId)
            .With(a => a.SymbolId, orderBookArguments.SymbolId)
            .With(a => a.Cmd, OrderType.Buy)
            .With(a => a.Volume, new OrderVolume(200))
            // .With(a => a.Price, new Money(500))
            .Build();

        var expected = new[]
        {
            new OrderMatchedEvent(orderBookArguments.Id,
                buyOrderArguments.OrderId, sellOrderArguments1.OrderId,
                sellOrderArguments1.Price, buyOrderArguments.Volume - sellOrderArguments1.Volume),
            new OrderMatchedEvent(orderBookArguments.Id,
                buyOrderArguments.OrderId, sellOrderArguments2.OrderId,
                sellOrderArguments2.Price, sellOrderArguments2.Volume),
        };

        this
            .Given(__ => _.TheCurrentDateTimeIs(DateTime.Now))
            .And(__ => _.ThereIsADefinedOrderBookWithTheFollowingArguments(orderBookArguments))
            .And(__ => _.ThereIsAPlacedOrderBookWithTheFollowingArguments(sellOrderArguments1))
            .And(__ => _.ThereIsAPlacedOrderBookWithTheFollowingArguments(sellOrderArguments2))
            .When(__ => _.IPlaceAnOrderWithFollowingArguments(buyOrderArguments))
            .Then(__ => _.ICanSeeThatMatchOrdersIsOccuredByRaisingTheFollowingEvents(expected))
            .BDDfy();
    }
}