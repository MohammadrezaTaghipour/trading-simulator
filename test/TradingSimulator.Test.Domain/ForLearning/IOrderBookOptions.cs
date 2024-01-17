
namespace TradingSimulator.Test.Domain.ForLearning;

public interface IOrderBookOptions
{
    Guid Id { get; }
}

public class OrderBookOptions : IOrderBookOptions
{
    public OrderBookOptions(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; }
}