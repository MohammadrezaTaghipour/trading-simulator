using TradingSimulator.Domain.Models.Shared.Monies;
using TradingSimulator.Infrastructure.Domain;

namespace TradingSimulator.Domain.Models.OrderBooks.V2.Orders;

public interface IOrder : IOrderOptions, IEntity<OrderId>
{
    IMoney Price { get; } 
    
    bool CanBeMatchedWith(IOrder order);
    bool IsCompletelyMatched();
    void IncreaseMatchedVolume(int volume);
}