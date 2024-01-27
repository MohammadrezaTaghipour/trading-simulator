using TradingSimulator.Domain.Models.Shared.Monies;
using TradingSimulator.Domain.Models.Shared.OrderVolumes;

namespace TradingSimulator.Domain.Models.OrderBooks.V2.Entities;

public interface IOrderOptions
{
    OrderType OrderType { get; }
    IOrderVolume Volume { get; }
    IMoneyOptions Price { get; }
    DateTime CreatedOn { get; }
}