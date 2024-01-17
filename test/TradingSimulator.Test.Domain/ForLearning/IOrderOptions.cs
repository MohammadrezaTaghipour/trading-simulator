namespace TradingSimulator.Test.Domain.ForLearning;

public interface IOrderOptions
{
    Guid Id { get; }
    decimal Price { get; }
    int Volume { get; }
}