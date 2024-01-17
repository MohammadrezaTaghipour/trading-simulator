using FizzWare.NBuilder;
using TestStack.BDDfy;
using TradingSimulator.Domain.Models.Sessions;
using TradingSimulator.Domain.Models.Symbols;
using TradingSimulator.Test.Domain.OrderBooks.V1.Fixtures;
using Xunit;

namespace TradingSimulator.Test.Domain.OrderBooks.V1;

public class When_defining_order_book
{
    private readonly OrderBookTestSteps _ = new();

    [Fact]
    public void OrderBook_gets_defined_with_valid_properties()
    {
        var arguments = DefineOrderBookArgBuilder.Builder
            .With(a => a.Title, "order-book-A")
            .With(a => a.SessionId, SessionId.New())
            .With(a => a.SymbolId, SymbolId.New())
            .Build();

        this
            .When(__ => _.IDefineANewOrderBookWithTheFollowingArguments(arguments))
            .Then(__ => _.ICanFindTheDefinedOrderBookWithAbovePropertiesWithinTheSystem(arguments))
            .BDDfy();
    }
}