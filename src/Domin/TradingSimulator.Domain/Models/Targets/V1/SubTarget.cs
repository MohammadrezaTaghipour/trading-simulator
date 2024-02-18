namespace TradingSimulator.Domain.Models.Targets.V1;

public class SubTarget : Target, ISubTargetOptions
{
    public SubTarget(ISubTargetOptions options) : base(options)
    {
        GuardAgainstNullOrEmptyName(options.SubTargetName);
        SubTargetName = options.SubTargetName;
    }

    private void GuardAgainstNullOrEmptyName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentNullException();
    }

    public string SubTargetName { get; private set; }

    internal void Update(ISubTargetOptions options)
    {
        GuardAgainstNullOrEmptyName(options.SubTargetName);
        base.Update(options);
        this.SubTargetName = options.SubTargetName;
    }
}