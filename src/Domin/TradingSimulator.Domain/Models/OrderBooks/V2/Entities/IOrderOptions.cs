namespace TradingSimulator.Domain.Models.OrderBooks.V2.Entities;

public interface IOrderOptions
{
    public OrderId Id { get; }
    public OrderType OrderType { get; }
    public OrderVolume Volume { get; }
    public Money Price { get; }
    public DateTime CreatedOn { get; }
}