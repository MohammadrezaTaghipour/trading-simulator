using FluentAssertions;
using TradingSimulator.Domain.Models.OrderBooks.V2;
using TradingSimulator.Domain.Models.OrderBooks.V2.Events;
using TradingSimulator.Domain.Models.OrderBooks.V2.Orders;
using TradingSimulator.Test.Domain.OrderBooks.V2.Fixtures;
using Xunit;

namespace TradingSimulator.Test.Domain.OrderBooks.V2;

public class When_enqueueing_order
{
    private readonly OrderBookTestBuilder _sutBuilder = new();
    private readonly OrderBook _sut;

    public When_enqueueing_order()
    {
        _sut = _sutBuilder.Build();
    }

    [Theory]
    [InlineData(500, 100, OrderType.Buy)]
    [InlineData(500, 100, OrderType.Sell)]
    public void Enqueueing_order_locks_orders_queues_when_bothSide_queues_are_empty(decimal price,
        int volume, OrderType orderType)
    {
        // Arrange
        var order = new OrderTestBuilder()
            .WithOrderType(orderType)
            .WithPrice(price)
            .WithVolume(volume);

        // Act
        _sut.EnqueueOrder(order);

        // Assert
        _sut.Orders.Should().HaveCount(1);
        _sut.Orders.Should().ContainEquivalentOf(order);
        _sut.Changes.OfType<OrderMatchedEventV2>().Should().HaveCount(0);
    }

    [Theory]
    [InlineData(1000, 500, OrderType.Buy)]
    [InlineData(1000, 500, OrderType.Sell)]
    public void Enqueueing_order_locks_order_queues_when_only_otherSide_queue_is_empty(decimal price,
        int volume, OrderType orderType)
    {
        // Arrange
        Enqueueing_order_locks_orders_queues_when_bothSide_queues_are_empty(1000, 500, orderType);
        var order = new OrderTestBuilder()
            .WithOrderType(orderType)
            .WithPrice(price)
            .WithVolume(volume);

        // Act
        _sut.EnqueueOrder(order);

        // Assert
        _sut.Orders.Should().HaveCount(2);
        _sut.Orders.Should().ContainEquivalentOf(order);
        _sut.Changes.OfType<OrderMatchedEventV2>().Should().HaveCount(0);
    }

    [Theory]
    [InlineData(1000, 100, OrderType.Sell, 999, 100, OrderType.Buy)]
    [InlineData(999, 100, OrderType.Buy, 1000, 100, OrderType.Sell)]
    public void
        Enqueueing_order_locks_order_queues_when_price_condition_is_not_meet_with_otherSide_price(
            decimal price, int volume, OrderType orderType, decimal otherSidePrice, int otherSideVolume,
            OrderType otherSideOrderType)
    {
        // Arrange
        Enqueueing_order_locks_orders_queues_when_bothSide_queues_are_empty(otherSidePrice,
            otherSideVolume, otherSideOrderType);
        var incomingOrder = new OrderTestBuilder()
            .WithOrderType(orderType)
            .WithPrice(price)
            .WithVolume(volume);

        // Act
        _sut.EnqueueOrder(incomingOrder);

        // Assert
        _sut.Orders.Should().HaveCount(2);
        _sut.Orders.Should().ContainEquivalentOf(incomingOrder);
        _sut.Changes.OfType<OrderMatchedEventV2>().Should().HaveCount(0);
    }

    [Theory]
    [InlineData(1000, 100, OrderType.Sell, 1000, 100, OrderType.Buy)]
    [InlineData(1000, 100, OrderType.Sell, 1001, 100, OrderType.Buy)]
    [InlineData(1000, 100, OrderType.Buy, 1000, 100, OrderType.Sell)]
    [InlineData(1000, 100, OrderType.Buy, 999, 100, OrderType.Sell)]
    public void order_gets_matched_with_order_in_otherSide_queue_when_its_price_condition_is_meet(
        decimal price, int volume, OrderType orderType, decimal otherSidePrice, int otherSideVolume,
        OrderType otherSideOrderType)
    {
        // Arrange
        Enqueueing_order_locks_orders_queues_when_bothSide_queues_are_empty(otherSidePrice,
            otherSideVolume, otherSideOrderType);
        var incomingOrder = new OrderTestBuilder()
            .WithOrderType(orderType)
            .WithPrice(price)
            .WithVolume(volume);

        // Act
        _sut.EnqueueOrder(incomingOrder);

        // Assert
        _sut.Orders.Should().HaveCount(2);
        _sut.Orders.Should().ContainEquivalentOf<IOrderOptions>(incomingOrder,
            opt => opt
                .Excluding(a => a.Price)
                .Excluding(a => a.Volume)
        );
        _sut.Orders.ToList().ForEach(o => o.Id.Should().NotBe(new OrderId(default)));
        _sut.Changes.OfType<OrderMatchedEventV2>().Should().HaveCount(1);
    }
}