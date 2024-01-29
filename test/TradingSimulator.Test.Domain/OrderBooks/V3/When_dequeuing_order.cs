using TradingSimulator.Domain.Models.OrderBooks.V2.Orders;
using Xunit;

namespace TradingSimulator.Test.Domain.OrderBooks.V3;

public class When_dequeuing_order
{
    private readonly When_enqueueing_order _fixture;

    public When_dequeuing_order()
    {
        _fixture = new();
    }

    [Theory]
    [InlineData(500, 100, OrderType.Buy)]
    [InlineData(500, 100, OrderType.Sell)]
    public void It_gets_dequeued(decimal price,
        int volume, OrderType orderType)
    {
        // Arrange
        _fixture.It_gets_enqueued_alongside_the_queued_orders(price, volume, orderType);
        _fixture.SutTestBuilder.AddOrder(o => o.WithOrderType(orderType)
            .WithPrice(price)
            .WithVolume(volume));
        var order = _fixture.SutTestBuilder.EnqueueOrder(_fixture.Sut);

        // Act
        _fixture.SutTestBuilder.DequeOrder(_fixture.Sut, order.Id);

        // Assert
        _fixture.SutTestBuilder.AssertOrderDequeued(_fixture.Sut, order);
    }
}