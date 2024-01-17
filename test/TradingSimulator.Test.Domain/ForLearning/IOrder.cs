namespace TradingSimulator.Test.Domain.ForLearning;

public class IOrder : IOrderOptions
{
    public Guid Id { get; }
    public decimal Price { get; }
    public int Volume { get; }
}