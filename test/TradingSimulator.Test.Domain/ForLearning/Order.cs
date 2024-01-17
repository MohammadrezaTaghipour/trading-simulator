namespace TradingSimulator.Test.Domain.ForLearning;

public class Order : IOrder
{
    public Order(Guid id, decimal price, int volume)
    {
        Id = id;
        Price = price;
        Volume = volume;
    }

    public Guid Id { get; }
    public decimal Price { get; }
    public int Volume { get; }
}