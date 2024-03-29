﻿using FizzWare.NBuilder;
using TestStack.BDDfy;
using TradingSimulator.Domain.Models.OrderBooks.V1.Events;
using TradingSimulator.Domain.Models.OrderBooks.V1.Orders;
using TradingSimulator.Domain.Models.Sessions;
using TradingSimulator.Domain.Models.Traders;
using TradingSimulator.Test.Domain.Monies;
using TradingSimulator.Test.Domain.OrderBooks.V1.Fixtures;
using Xunit;

namespace TradingSimulator.Test.Domain.OrderBooks.V1;

public class When_matching_sellOrder
{
    private readonly OrderBookTestSteps _ = new();

    [Fact]
    public void SellOrder_gets_matched_with_buyOrder_when_sellPrice_is_lessThan_buyPrice()
    {
        var orderBookArguments = DefineOrderBookArgBuilder.Builder
            .With(a => a.Title, "order-book-A")
            .With(a => a.SessionId, SessionId.New())
            .With(a => a.SymbolId, Guid.NewGuid())
            .Build();

        var buyOrderArguments = PlaceOrderArgBuilder.Builder
            .With(a => a.OrderId, OrderId.New())
            .With(a => a.OrderBookId, orderBookArguments.Id)
            .With(a => a.TraderId, TraderId.New())
            .With(a => a.SessionId, orderBookArguments.SessionId)
            .With(a => a.SymbolId, orderBookArguments.SymbolId)
            .With(a => a.Cmd, OrderType.Buy)
            .With(a => a.Volume, new OrderVolume(100))
            .With(a => a.Price, new MoneyTestBuilder().WithValue(500).Build())
            .Build();

        var sellOrderArguments = PlaceOrderArgBuilder.Builder
            .With(a => a.OrderId, OrderId.New())
            .With(a => a.OrderBookId, orderBookArguments.Id)
            .With(a => a.TraderId, TraderId.New())
            .With(a => a.SessionId, orderBookArguments.SessionId)
            .With(a => a.SymbolId, orderBookArguments.SymbolId)
            .With(a => a.Cmd, OrderType.Sell)
            .With(a => a.Volume, new OrderVolume(100))
            .With(a => a.Price, new MoneyTestBuilder().WithValue(300).Build())
            .Build();

        var expected = new OrderMatchedEvent(orderBookArguments.Id,
            buyOrderArguments.OrderId, sellOrderArguments.OrderId,
            buyOrderArguments.Price, buyOrderArguments.Volume);

        this
            .Given(__ => _.TheCurrentDateTimeIs(DateTime.Now))
            .And(__ => _.ThereIsADefinedOrderBookWithTheFollowingArguments(orderBookArguments))
            .And(__ => _.ThereIsAPlacedOrderBookWithTheFollowingArguments(buyOrderArguments))
            .When(__ => _.IPlaceAnOrderWithFollowingArguments(sellOrderArguments))
            .Then(__ => _.ICanSeeThatMatchOrdersIsOccuredByRaisingTheFollowingEvent(expected))
            .BDDfy();
    }

    [Fact]
    public void SellOrder_also_gets_matched_with_buyOrder_when_sellPrice_is_equal_to_buyPrice()
    {
        var orderBookArguments = DefineOrderBookArgBuilder.Builder
            .With(a => a.Title, "order-book-A")
            .With(a => a.SessionId, SessionId.New())
            .With(a => a.SymbolId, Guid.NewGuid())
            .Build();

        var buyOrderArguments = PlaceOrderArgBuilder.Builder
            .With(a => a.OrderId, OrderId.New())
            .With(a => a.OrderBookId, orderBookArguments.Id)
            .With(a => a.TraderId, TraderId.New())
            .With(a => a.SessionId, orderBookArguments.SessionId)
            .With(a => a.SymbolId, orderBookArguments.SymbolId)
            .With(a => a.Cmd, OrderType.Buy)
            .With(a => a.Volume, new OrderVolume(100))
            .With(a => a.Price, new MoneyTestBuilder().WithValue(500).Build())
            .Build();

        var sellOrderArguments = PlaceOrderArgBuilder.Builder
            .With(a => a.OrderId, OrderId.New())
            .With(a => a.OrderBookId, orderBookArguments.Id)
            .With(a => a.TraderId, TraderId.New())
            .With(a => a.SessionId, orderBookArguments.SessionId)
            .With(a => a.SymbolId, orderBookArguments.SymbolId)
            .With(a => a.Cmd, OrderType.Sell)
            .With(a => a.Volume, new OrderVolume(100))
            .With(a => a.Price, new MoneyTestBuilder().WithValue(500).Build())
            .Build();

        var expected = new OrderMatchedEvent(orderBookArguments.Id,
            buyOrderArguments.OrderId, sellOrderArguments.OrderId,
            buyOrderArguments.Price, buyOrderArguments.Volume);

        this
            .Given(__ => _.TheCurrentDateTimeIs(DateTime.Now))
            .And(__ => _.ThereIsADefinedOrderBookWithTheFollowingArguments(orderBookArguments))
            .And(__ => _.ThereIsAPlacedOrderBookWithTheFollowingArguments(buyOrderArguments))
            .When(__ => _.IPlaceAnOrderWithFollowingArguments(sellOrderArguments))
            .Then(__ => _.ICanSeeThatMatchOrdersIsOccuredByRaisingTheFollowingEvent(expected))
            .BDDfy();
    }

    [Fact]
    public void SellOrder_gets_matched_with_multiple_buyOrders_when_it_has_greater_volume_than_buyOrder_volume()
    {
        var orderBookArguments = DefineOrderBookArgBuilder.Builder
            .With(a => a.Title, "order-book-A")
            .With(a => a.SessionId, SessionId.New())
            .With(a => a.SymbolId, Guid.NewGuid())
            .Build();

        var buyOrderArguments1 = PlaceOrderArgBuilder.Builder
            .With(a => a.OrderId, OrderId.New())
            .With(a => a.OrderBookId, orderBookArguments.Id)
            .With(a => a.TraderId, TraderId.New())
            .With(a => a.SessionId, orderBookArguments.SessionId)
            .With(a => a.SymbolId, orderBookArguments.SymbolId)
            .With(a => a.Cmd, OrderType.Buy)
            .With(a => a.Volume, new OrderVolume(100))
            .With(a => a.Price, new MoneyTestBuilder().WithValue(400).Build())
            .Build();

        var buyOrderArguments2 = PlaceOrderArgBuilder.Builder
            .With(a => a.OrderId, OrderId.New())
            .With(a => a.OrderBookId, orderBookArguments.Id)
            .With(a => a.TraderId, TraderId.New())
            .With(a => a.SessionId, orderBookArguments.SessionId)
            .With(a => a.SymbolId, orderBookArguments.SymbolId)
            .With(a => a.Cmd, OrderType.Buy)
            .With(a => a.Volume, new OrderVolume(100))
            .With(a => a.Price, new MoneyTestBuilder().WithValue(400).Build())
            .Build();

        var sellOrderArguments = PlaceOrderArgBuilder.Builder
            .With(a => a.OrderId, OrderId.New())
            .With(a => a.OrderBookId, orderBookArguments.Id)
            .With(a => a.TraderId, TraderId.New())
            .With(a => a.SessionId, orderBookArguments.SessionId)
            .With(a => a.SymbolId, orderBookArguments.SymbolId)
            .With(a => a.Cmd, OrderType.Sell)
            .With(a => a.Volume, new OrderVolume(200))
            .With(a => a.Price, new MoneyTestBuilder().WithValue(300).Build())
            .Build();

        var expected = new[]
        {
            new OrderMatchedEvent(orderBookArguments.Id,
                buyOrderArguments1.OrderId, sellOrderArguments.OrderId,
                buyOrderArguments1.Price, sellOrderArguments.Volume - buyOrderArguments1.Volume),
            new OrderMatchedEvent(orderBookArguments.Id,
                buyOrderArguments2.OrderId, sellOrderArguments.OrderId,
                buyOrderArguments2.Price, buyOrderArguments2.Volume),
        };

        this
            .Given(__ => _.TheCurrentDateTimeIs(DateTime.Now))
            .And(__ => _.ThereIsADefinedOrderBookWithTheFollowingArguments(orderBookArguments))
            .And(__ => _.ThereIsAPlacedOrderBookWithTheFollowingArguments(buyOrderArguments1))
            .And(__ => _.ThereIsAPlacedOrderBookWithTheFollowingArguments(buyOrderArguments2))
            .When(__ => _.IPlaceAnOrderWithFollowingArguments(sellOrderArguments))
            .Then(__ => _.ICanSeeThatMatchOrdersIsOccuredByRaisingTheFollowingEvents(expected))
            .BDDfy();
    }
}