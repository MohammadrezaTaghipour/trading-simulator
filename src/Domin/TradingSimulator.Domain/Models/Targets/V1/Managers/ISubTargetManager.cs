namespace TradingSimulator.Domain.Models.Targets.V1.Managers;

public interface ISubTargetManager<TSelf, TTarget>
    : ITargetManager<TSelf, TTarget>,
        ISubTargetOptions
    where TSelf : ISubTargetManager<TSelf, TTarget>
    where TTarget : ISubTargetOptions
{
    public TSelf WithSubName(string value);
}

public abstract class SubTargetManager<TSelf, TTarget>
    : TargetManager<TSelf, TTarget>,
        ISubTargetManager<TSelf, TTarget>
    where TSelf : ISubTargetManager<TSelf, TTarget>
    where TTarget : ISubTargetOptions
{
    public TSelf WithSubName(string value)
    {
        SubTargetName = value;
        return this;
    }

    public string SubTargetName { get; private set; }
}