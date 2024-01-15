using FizzWare.NBuilder;
using TestStack.BDDfy;
using TradingSimulator.Domain.Models;
using TradingSimulator.Domain.Models.OrderBooks.Orders;
using TradingSimulator.Domain.Models.Sessions;
using TradingSimulator.Domain.Models.Symbols;
using TradingSimulator.Domain.Models.Traders;
using TradingSimulator.Test.Domain.OrderBooks.Fixtures;
using Xunit;

namespace TradingSimulator.Test.Domain.OrderBooks;

public class When_placing_order
{
    private readonly OrderBookTestSteps _ = new();

    [Fact]
    public void Order_Gets_Placed_With_Valid_Properties()
    {
        var orderBookArguments = DefineOrderBookArgBuilder.Builder
            .With(a => a.Title, "order-book-A")
            .With(a => a.SessionId, SessionId.New())
            .With(a => a.SymbolId, SymbolId.New())
            .Build();

        var placeOrderArguments = PlaceOrderArgBuilder.Builder
            .With(a => a.OrderBookId, orderBookArguments.Id)
            .With(a => a.TraderId, TraderId.New())
            .With(a => a.SessionId, orderBookArguments.SessionId)
            .With(a => a.SymbolId, orderBookArguments.SymbolId)
            .With(a => a.Cmd, OrderCommandType.Buy)
            .With(a => a.Volume, new OrderVolume(100))
            .With(a => a.Price, new Money(500))
            .Build();

        this
            .Given(__ => _.TheCurrentDateTimeIs(DateTime.Now))
            .And(__ => _.ThereIsADefinedOrderBookWithTheFollowingArguments(orderBookArguments))
            .When(__ => _.IPlaceAnOrderWithFollowingArguments(placeOrderArguments))
            .Then(__ => _.ICanFindThePlacedOrderWithAboveArgumentsWithTheOrderBook(placeOrderArguments))
            .And(__ => _.ICanFindAPublishedEventNameOrderPlacedWithFollowingArguments(placeOrderArguments))
            .BDDfy();
    }
}