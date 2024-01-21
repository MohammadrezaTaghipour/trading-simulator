using FluentAssertions;
using TradingSimulator.Domain.Models.OrderBooks.V2.Events;
using TradingSimulator.Test.Domain.OrderBooks.V2.Fixtures;
using Xunit;

namespace TradingSimulator.Test.Domain.OrderBooks.V2;

public class When_placing_buyOrder
{
    private readonly OrderBookTestBuilder _builder = new();

    [Fact]
    public void Enqueueing_buyOrder_when_buyQueue_and_sellQueue_are_empty_results_buyQueue_to_get_locked()
    {
        var expected = _builder.WithBuyOrder();
        var sut = _builder.Build();

        sut.EnqueueOrder(expected.Orders.First());

        sut.Should().BeEquivalentTo(expected);
        sut.Changes.OfType<OrderMatchedEventV2>().Should().BeNullOrEmpty();
    }

    [Fact]
    public void Placing_buyOrder_when_buyQueue_is_not_empty_sellQueue_is_empty_results_buyQueue_to_get_locked()
    {
    }
}