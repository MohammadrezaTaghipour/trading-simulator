using TradingSimulator.Domain.Models.Shared.Monies;
using TradingSimulator.Domain.Models.Shared.OrderVolumes;
using TradingSimulator.Infrastructure.Domain;

namespace TradingSimulator.Domain.Models.OrderBooks.V2.Entities;

public interface IOrder : IOrderOptions, IEntity<OrderId>
{
    OrderVolume Volume { get; }
    Money Price { get; }
    
    bool CanBeMatchedWith(IOrder order);
    bool IsCompletelyMatched();
    void ModifyVolume(IOrderVolumeOptions volume);
}