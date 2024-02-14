namespace TradingSimulator.Domain.Models.Targets.V1;

public class SubTarget : Target, ISubTargetOptions
{
    internal SubTarget(ISubTargetOptions options) : base(options)
    {
        if (string.IsNullOrWhiteSpace(options.TargetName))
            throw new ArgumentNullException();
        
        SubTargetName = options.SubTargetName;
    }

    public string SubTargetName { get; private set; }
}