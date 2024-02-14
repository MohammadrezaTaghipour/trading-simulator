namespace TradingSimulator.Domain.Models.Targets.V1.Builders;

public interface ITargetManager<TSelf, TTarget> : ITargetOptions
    where TSelf : ITargetManager<TSelf, TTarget>
    where TTarget : ITargetOptions
{
    TTarget Build();
    TSelf WithTargetName(string value);
}

public abstract class TargetManager<TSelf, TTarget> : ITargetManager<TSelf, TTarget>
    where TSelf : ITargetManager<TSelf, TTarget>
    where TTarget : ITargetOptions
{
    public string TargetName { get; private set; }

    public TTarget Build()
    {
        try
        {
            return (TTarget)Activator.CreateInstance(typeof(TTarget), this)!;
        }
        catch (Exception e)
        {
            throw e.InnerException!;
        }
    }

    public TSelf WithTargetName(string value)
    {
        TargetName = value;
        return this;
    }

    public static implicit operator TSelf(TargetManager<TSelf, TTarget> manager)
    {
        //TODO: ask the deep reason of the following
        return (TSelf)(ITargetManager<TSelf, TTarget>)manager;
    }
}