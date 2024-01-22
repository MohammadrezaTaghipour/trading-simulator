using FizzWare.NBuilder;
using TestStack.BDDfy;
using TradingSimulator.Domain.Models.OrderBooks.V1.Orders;
using TradingSimulator.Domain.Models.Sessions;
using TradingSimulator.Domain.Models.Traders;
using TradingSimulator.Test.Domain.OrderBooks.V1.Fixtures;
using Xunit;

namespace TradingSimulator.Test.Domain.OrderBooks.V1;

public class When_placing_order
{
    private readonly OrderBookTestSteps _ = new();

    [Fact]
    public void Order_Gets_Placed_With_Valid_Properties()
    {
        var orderBookArguments = DefineOrderBookArgBuilder.Builder
            .With(a => a.Title, "order-book-A")
            .With(a => a.SessionId, SessionId.New())
            .With(a => a.SymbolId, Guid.NewGuid())
            .Build();

        var placeOrderArguments = PlaceOrderArgBuilder.Builder
            .With(a => a.OrderBookId, orderBookArguments.Id)
            .With(a => a.TraderId, TraderId.New())
            .With(a => a.SessionId, orderBookArguments.SessionId)
            .With(a => a.SymbolId, orderBookArguments.SymbolId)
            .With(a => a.Cmd, OrderType.Buy)
            .With(a => a.Volume, new OrderVolume(100))
            // .With(a => a.Price, new MoneyOptions(500))
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