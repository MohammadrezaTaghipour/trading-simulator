namespace TradingSimulator.Test.Domain.ForLearning;

public class StockMarketMatchEngine : IMatchEngine
{
    public Task<string> Process(IOrder incomingOrder, PriorityQueue<IOrder, IOrder> matchingQueue)
    {
        return Task.FromResult(string.Empty);
        //TODO: do mathcing logic
    }
}