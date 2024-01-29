using FluentAssertions;
using TradingSimulator.Domain.Models.OrderBooks.V2;
using TradingSimulator.Domain.Models.OrderBooks.V2.Events;
using TradingSimulator.Domain.Models.OrderBooks.V2.Orders;
using TradingSimulator.Domain.Models.Shared.Monies;
using TradingSimulator.Domain.Models.Shared.OrderVolumes;
using TradingSimulator.Test.Domain.OrderBooks.V2.Fixtures;
using TradingSimulator.Test.Domain.OrderBooks.V3.Fixtures;
using Xunit;

namespace TradingSimulator.Test.Domain.OrderBooks.V3;

public class When_matching_incoming_order
{
    private readonly TestOrderBookManager _sutTestBuilder = new();
    private readonly IOrderBook _sut;

    public When_matching_incoming_order()
    {
        _sut = _sutTestBuilder.Build();
    }

    [Theory]
    [InlineData(500, 100, OrderType.Buy)]
    [InlineData(500, 100, OrderType.Sell)]
    public void Incoming_order_locks_order_queues_when_bothSide_queues_are_empty(decimal price,
        int volume, OrderType orderType)
    {
        // Arrange
        _sutTestBuilder.AddOrder(o => o.WithOrderType(orderType)
            .WithPrice(price)
            .WithVolume(volume));

        // Act
        _sutTestBuilder.EnqueueOrder(_sut);

        // Assert
        _sut.Changes.OfType<OrderMatchedEventV2>().Should().HaveCount(0);
    }

    [Theory]
    [InlineData(1000, 500, OrderType.Buy)]
    [InlineData(1000, 500, OrderType.Sell)]
    public void Incoming_order_locks_order_queues_when_only_otherSide_queue_is_empty(decimal price,
        int volume, OrderType orderType)
    {
        // Arrange
        Incoming_order_locks_order_queues_when_bothSide_queues_are_empty(price, volume, orderType);
        _sutTestBuilder.AddOrder(o => o.WithOrderType(orderType)
            .WithPrice(price)
            .WithVolume(volume));

        // Act
        _sutTestBuilder.EnqueueOrder(_sut);

        // Assert
        _sut.Changes.OfType<OrderMatchedEventV2>().Should().HaveCount(0);
    }

    [Theory]
    [InlineData(1000, 100, OrderType.Sell, 999, 100, OrderType.Buy)]
    [InlineData(999, 100, OrderType.Buy, 1000, 100, OrderType.Sell)]
    public void
        Incoming_order_locks_otherSide_queue_when_price_condition_is_not_meet_with_otherSide_price(
            decimal price, int volume, OrderType orderType, decimal otherSidePrice, int otherSideVolume,
            OrderType otherSideOrderType)
    {
        // Arrange
        Incoming_order_locks_order_queues_when_bothSide_queues_are_empty(otherSidePrice,
            otherSideVolume, otherSideOrderType);
        _sutTestBuilder.AddOrder(o => o.WithOrderType(orderType)
            .WithPrice(price)
            .WithVolume(volume));

        // Act
        _sutTestBuilder.EnqueueOrder(_sut);

        // Assert
        _sut.Changes.OfType<OrderMatchedEventV2>().Should().HaveCount(0);
    }

    [Theory]
    [InlineData(1000, 100, OrderType.Sell, 1000, 100, OrderType.Buy)]
    [InlineData(1000, 100, OrderType.Sell, 1001, 100, OrderType.Buy)]
    [InlineData(1000, 100, OrderType.Buy, 1000, 100, OrderType.Sell)]
    [InlineData(1000, 100, OrderType.Buy, 999, 100, OrderType.Sell)]
    public void Incoming_order_gets_matched_with_order_of_otherSide_when_its_Price_condition_is_meet(
        decimal price, int volume, OrderType orderType, decimal otherSidePrice, int otherSideVolume,
        OrderType otherSideOrderType)
    {
        // Arrange
        Incoming_order_locks_order_queues_when_bothSide_queues_are_empty(otherSidePrice,
            otherSideVolume, otherSideOrderType);
        _sutTestBuilder.AddOrder(o => o.WithOrderType(orderType)
            .WithPrice(price)
            .WithVolume(volume));

        // Act
        _sutTestBuilder.EnqueueOrder(_sut);

        // Assert
        _sut.Changes.OfType<OrderMatchedEventV2>().Should().HaveCount(1);
        _sutTestBuilder.AssertEventRaised<OrderMatchedEventV2>(_sut);
    }

    [Theory]
    [InlineData(1000, 100, OrderType.Sell, 1000, 50, OrderType.Buy)]
    [InlineData(999, 100, OrderType.Sell, 1000, 50, OrderType.Buy)]
    [InlineData(1000, 100, OrderType.Buy, 1000, 50, OrderType.Sell)]
    [InlineData(1000, 100, OrderType.Buy, 999, 50, OrderType.Sell)]
    public void
        Incoming_order_gets_matched_with_multiple_orders_of_otherSide_when_Volume_condition_is_meet_partially(
            decimal price, int volume, OrderType orderType,
            decimal otherSidePrice, int otherSideVolume, OrderType otherSideOrderType)
    {
        // Arrange
        Incoming_order_locks_order_queues_when_only_otherSide_queue_is_empty(otherSidePrice,
            otherSideVolume, otherSideOrderType);
        _sutTestBuilder.AddOrder(o => o.WithOrderType(orderType)
            .WithPrice(price)
            .WithVolume(volume));

        // Act
        _sutTestBuilder.EnqueueOrder(_sut);

        // Assert
        _sut.Changes.OfType<OrderMatchedEventV2>().Should().HaveCount(2);
        _sutTestBuilder.AssertEventRaised<OrderMatchedEventV2>(_sut);
    }


    private OrderMatchedEventV2 createOrderMatchedEvent(
        OrderBookId orderBookId,
        OrderId incomingOrderId, OrderType incomingOrderType,
        OrderId otherSideOrderId, OrderType otherSideOrderType,
        IMoney otherSidePrice,
        IOrderVolume matchedVolume)
    {
        var sellOrderId = incomingOrderType is OrderType.Sell
            ? incomingOrderId
            : otherSideOrderId;
        var buyOrderId = otherSideOrderType is OrderType.Buy
            ? otherSideOrderId
            : incomingOrderId;

        return new OrderMatchedEventV2(orderBookId, buyOrderId,
            sellOrderId, otherSidePrice, matchedVolume);
    }
}