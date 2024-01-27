namespace TradingSimulator.Domain.Models.Shared.OrderVolumes;

public interface IOrderVolume : IOrderVolumeOptions
{
    void Decrease(int value);
}