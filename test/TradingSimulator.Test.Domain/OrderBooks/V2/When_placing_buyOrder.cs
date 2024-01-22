using FluentAssertions;
using TradingSimulator.Domain.Models.OrderBooks.V2;
using TradingSimulator.Domain.Models.OrderBooks.V2.Entities;
using TradingSimulator.Domain.Models.OrderBooks.V2.Events;
using TradingSimulator.Test.Domain.OrderBooks.V2.Fixtures;
using Xunit;

namespace TradingSimulator.Test.Domain.OrderBooks.V2;

public class When_placing_buyOrder
{
    private readonly OrderBookTestBuilder _sutBuilder = new();
    private readonly OrderTestBuilder _orderBuilder = new();

    private readonly IOrderBook _sut;

    public When_placing_buyOrder()
    {
        _sut = _sutBuilder.Build();
    }

    [Fact]
    public void Enqueueing_buyOrder_when_buyQueue_and_sellQueue_are_empty_results_buyQueue_to_get_locked()
    {
        var buyOrder = _orderBuilder.WithOrderType(OrderType.Buy);

        _sut.EnqueueOrder(buyOrder);

        _sut.Orders.Should().HaveCount(1);
        _sut.Orders.Should().ContainEquivalentOf(buyOrder);
        _sut.Changes.OfType<OrderMatchedEventV2>().Should().BeNullOrEmpty();
    }

    [Fact]
    public void Placing_buyOrder_when_buyQueue_is_not_empty_but_sellQueue_is_empty_results_buyQueue_to_get_locked()
    {
        Enqueueing_buyOrder_when_buyQueue_and_sellQueue_are_empty_results_buyQueue_to_get_locked();

        var buyOrder = _orderBuilder.WithOrderType(OrderType.Buy);

        _sut.EnqueueOrder(buyOrder);

        _sut.Orders.Should().HaveCount(2);
        _sut.Orders.Should().ContainEquivalentOf(buyOrder);
        _sut.Changes.OfType<OrderMatchedEventV2>().Should().HaveCount(0);
    }
}