namespace TradingSimulator.Domain.Models.Targets.V1;

public abstract class Target : ITargetOptions
{
    protected Target(ITargetOptions options)
    {
        GuardAgainstNullOrEmptyName(options.TargetName);

        TargetName = options.TargetName;
    }

    public string TargetName { get; private set; }

    internal void Update(ITargetOptions options)
    {
        GuardAgainstNullOrEmptyName(options.TargetName);
        this.TargetName = options.TargetName;
    }

    private void GuardAgainstNullOrEmptyName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentNullException();
    }
}