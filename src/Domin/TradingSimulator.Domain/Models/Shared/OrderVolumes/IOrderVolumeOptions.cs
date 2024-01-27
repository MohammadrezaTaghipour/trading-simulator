namespace TradingSimulator.Domain.Models.Shared.OrderVolumes;

public interface IOrderVolumeOptions
{
    int Value { get; }
    
    public static IOrderVolumeOptions operator -(IOrderVolumeOptions left, IOrderVolumeOptions right)
    {
        return new OrderVolumeBuilder().WithValue(left.Value - right.Value);
    }
    
    public static IOrderVolumeOptions operator +(IOrderVolumeOptions left, IOrderVolumeOptions right)
    {
        return new OrderVolumeBuilder().WithValue(left.Value + right.Value);
    }
}