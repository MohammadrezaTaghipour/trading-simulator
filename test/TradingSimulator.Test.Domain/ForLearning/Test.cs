using NSubstitute;
using Xunit;

namespace TradingSimulator.Test.Domain.ForLearning;

public class Test
{
    [Fact]
    public async Task Test1()
    {
        var options = new OrderBookOptions(Guid.NewGuid());
        var sut = new OrderBook(options);

        IOrder incomingOrder = new Order(Guid.NewGuid(), 100, 100);

        var matchEngine = Substitute.For<IMatchEngine>();

        await sut.AddOrder(incomingOrder, matchEngine);

        await matchEngine.Received(1).Process(Arg.Any<IOrder>(), Arg.Any<PriorityQueue<IOrder, IOrder>>());
    }
}