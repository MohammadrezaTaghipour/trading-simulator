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
    private readonly IOrderBook _sut;

    public When_enqueueing_order()
    {
        _sut = _sutBuilder.Build();
    }
    
    [Theory]
    [InlineData(500, 100, OrderType.Buy)]
    [InlineData(500, 100, OrderType.Sell)]
    public void It_gets_enqueued_when_there_is_no_other_orders_queued_yet(decimal price,
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
        _sut.Orders.ToList().ForEach(o => o.Id.Should().NotBe(default(OrderId)));
        _sut.Orders.Should().ContainEquivalentOf<IOrderOptions>(order);
    }
    
    [Theory]
    [InlineData(1000, 500, OrderType.Buy)]
    [InlineData(1000, 500, OrderType.Sell)]
    public void It_gets_enqueued_alongside_the_queued_orders(decimal price,
        int volume, OrderType orderType)
    {
        // Arrange
        It_gets_enqueued_when_there_is_no_other_orders_queued_yet(price, volume, orderType);
        var order = new OrderTestBuilder()
            .WithOrderType(orderType)
            .WithPrice(price)
            .WithVolume(volume);

        // Act
        _sut.EnqueueOrder(order);

        // Assert
        _sut.Orders.Should().HaveCount(2);
        _sut.Orders.ToList().ForEach(o => o.Id.Should().NotBe(default(OrderId)));
        _sut.Orders.Should().ContainEquivalentOf(order);
    }
}