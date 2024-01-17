namespace TradingSimulator.Test.Domain.ForLearning;

public interface IOrderBook : IOrderBookOptions
{
    Task AddOrder(IOrderOptions options, IMatchEngine matchEngine);
}