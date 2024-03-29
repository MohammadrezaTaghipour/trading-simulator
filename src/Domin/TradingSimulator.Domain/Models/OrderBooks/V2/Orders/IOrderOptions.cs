using TradingSimulator.Domain.Models.Shared.Monies;
using TradingSimulator.Domain.Models.Shared.OrderVolumes;

namespace TradingSimulator.Domain.Models.OrderBooks.V2.Orders;

public interface IOrderOptions
{
    OrderType OrderType { get; }
    IOrderVolume Volume { get; }
    IMoney Price { get; }
    DateTime CreatedOn { get; }
    bool IsCanceled { get; }
}