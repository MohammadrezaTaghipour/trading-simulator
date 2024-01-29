using FluentAssertions;
using TradingSimulator.Domain.Models.OrderBooks.V2;
using TradingSimulator.Domain.Models.OrderBooks.V2.Orders;
using TradingSimulator.Infrastructure.Domain;
using TradingSimulator.Test.Domain.OrderBooks.V2.Fixtures;

namespace TradingSimulator.Test.Domain.OrderBooks.V3.Fixtures;

public class TestOrderBookManager 
{
    public readonly OrderBookBuilder SutBuilder = new();
    
    public TestOrderBookManager()
    {
        SutBuilder.WithTitle("some title");
        SutBuilder.WithSymbolId(Guid.NewGuid());
    }

    public TestOrderBookManager WithTitle(string value)
    {
        SutBuilder.WithTitle(value);
        return this;
    }

    public TestOrderBookManager WithSymbolId(Guid value)
    {
        SutBuilder.WithSymbolId(value);
        return this;
    }

    public TestOrderBookManager AddOrder(Action<OrderTestBuilder> orderBuilder)
    {
        var localBuilder = new OrderTestBuilder();
        orderBuilder(localBuilder);
        SutBuilder.AddOrder(localBuilder);
        return this;
    }

    public IOrder EnqueueOrder(IOrderBook orderBook)
    {
        return orderBook.EnqueueOrder(SutBuilder.Orders.Last());
    }
    
    public OrderBook Build()
    {
        return (SutBuilder.Build() as OrderBook)!;
    }

    public void AssertOrderEnqueued(IOrderBook orderBook)
    {
        orderBook.Orders.ToList().ForEach(o => o.Id.Should().NotBe(default(OrderId)));
        orderBook.Should().BeEquivalentTo<IOrderBookOptions>(SutBuilder,
            options => options.AllowingInfiniteRecursion());
    }
    
    public void AssertEventRaised<TEvent>(IOrderBook target)
        where TEvent : IDomainEvent
    {
        var actual = target.Changes.OfType<TEvent>().LastOrDefault();

        actual.Should().NotBeNull();
        actual.EventId.Should().NotBe(default(Guid));
        actual.CreatedOn.Should().NotBe(default);
    }
    
    public void AssertEventRaised<TEvent>(IOrderBook target, TEvent expectedEvent)
        where TEvent : IDomainEvent
    {
        var actual = target.Changes.OfType<TEvent>().LastOrDefault();

        actual.Should().NotBeNull();
        actual.EventId.Should().NotBe(default(Guid));
        actual.CreatedOn.Should().NotBe(default);
    }
}