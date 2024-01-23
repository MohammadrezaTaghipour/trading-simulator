namespace TradingSimulator.Domain.Models.Shared.OrderVolumes;

public interface IOrderVolumeOptions
{
    int Value { get; }


    // static virtual bool operator ==(IOrderVolumeOptions left, IOrderVolumeOptions right)
    // {
    //     return left.Value == right.Value;
    // }
    //
    // static virtual bool operator !=(IOrderVolumeOptions left, IOrderVolumeOptions right)
    // {
    //     return !(left == right);
    // }


    // public static bool operator >(IOrderVolumeOptions left, IOrderVolumeOptions right)
    // {
    //     return left.Value > right.Value;
    // }
    //
    // public static bool operator <(IOrderVolumeOptions left, IOrderVolumeOptions right)
    // {
    //     return left.Value < right.Value;
    // }
    //
    // public static bool operator >=(IOrderVolumeOptions left, IOrderVolumeOptions right)
    // {
    //     return left.Value >= right.Value;
    // }
    //
    // public static bool operator <=(IOrderVolumeOptions left, IOrderVolumeOptions right)
    // {
    //     return left.Value <= right.Value;
    // }
}