using FluentAssertions;
using NSubstitute;
using Xunit;

namespace TradingSimulator.Test.Domain.ForLearning;

public class DecoratorTest
{
    [Fact]
    public async Task Test2()
    {
        var fixture = Substitute.For<IMatchEngine>();
        
        var sut = new MatchEngineQueueingDecorator(fixture);
        
        IOrder incomingOrder = new Order(Guid.NewGuid(), 100, 100);

       var actual =  await sut.Process(incomingOrder, new PriorityQueue<IOrder, IOrder>());
       
       await fixture.Received(1).Process(Arg.Any<IOrder>(), Arg.Any<PriorityQueue<IOrder, IOrder>>());

       actual.Should().BeEquivalentTo("ok");
    }
}