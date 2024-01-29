using TradingSimulator.Domain.Models.OrderBooks.V2;
using TradingSimulator.Domain.Models.OrderBooks.V2.Orders;
using TradingSimulator.Test.Domain.OrderBooks.V3.Fixtures;
using Xunit;

namespace TradingSimulator.Test.Domain.OrderBooks.V3;

public class When_enqueueing_order
{
    public readonly TestOrderBookManager SutTestBuilder = new();
    public readonly IOrderBook Sut;

    public When_enqueueing_order()
    {
        Sut = SutTestBuilder.Build();
    }

    [Theory]
    [InlineData(500, 100, OrderType.Buy)]
    [InlineData(500, 100, OrderType.Sell)]
    public void It_gets_enqueued_when_there_is_no_other_orders_queued_yet(decimal price,
        int volume, OrderType orderType)
    {
        // Arrange
        SutTestBuilder.AddOrder(o => o.WithOrderType(orderType)
            .WithPrice(price)
            .WithVolume(volume));

        // Act
        SutTestBuilder.EnqueueOrder(Sut);

        // Assert
        SutTestBuilder.AssertOrderEnqueued(Sut);
    }

    [Theory]
    [InlineData(1000, 500, OrderType.Buy)]
    [InlineData(1000, 500, OrderType.Sell)]
    public void It_gets_enqueued_alongside_the_queued_orders(decimal price,
        int volume, OrderType orderType)
    {
        // Arrange
        It_gets_enqueued_when_there_is_no_other_orders_queued_yet(price, volume, orderType);
        SutTestBuilder.AddOrder(o => o.WithOrderType(orderType)
            .WithPrice(price)
            .WithVolume(volume));

        // Act
        SutTestBuilder.EnqueueOrder(Sut);

        // Assert
        SutTestBuilder.AssertOrderEnqueued(Sut);
    }
}