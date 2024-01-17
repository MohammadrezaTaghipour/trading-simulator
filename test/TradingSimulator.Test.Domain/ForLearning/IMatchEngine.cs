namespace TradingSimulator.Test.Domain.ForLearning;

public interface IMatchEngine
{
    Task<string> Process(IOrder incomingOrder, PriorityQueue<IOrder, IOrder> matchingQueue);
}