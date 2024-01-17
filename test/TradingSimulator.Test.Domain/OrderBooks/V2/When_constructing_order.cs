using FluentAssertions;
using TradingSimulator.Domain.Models.OrderBooks.V2.Entities;
using TradingSimulator.Domain.Models.OrderBooks.V2.Exceptions;
using TradingSimulator.Test.Domain.OrderBooks.V2.Fixtures;
using Xunit;

namespace TradingSimulator.Test.Domain.OrderBooks.V2;

public class When_constructing_order
{
    [Fact]
    public void It_gets_constructed_with_all_required_options()
    {
        var options = new OrderOptionsTestBuilder().Build();

        var sut = new Order(options);

        sut.Should().BeEquivalentTo(options);
    }

    [Fact]
    public void Price_is_always_greaterThan_zero()
    {
        var options = new OrderOptionsTestBuilder()
            .WithPrice(0)
            .Build();

        var act = () => { new Order(options); };

        act.Should().Throw<OrderPriceIsLessThanOrEqualToZero>();
    }
    
    [Fact]
    public void Volume_is_always_greaterThan_zero()
    {
        var options = new OrderOptionsTestBuilder()
            .WithVolume(0)
            .Build();

        var act = () => { new Order(options); };

        act.Should().Throw<OrderVolumeIsLessThanOrEqualToZero>();
    }
}