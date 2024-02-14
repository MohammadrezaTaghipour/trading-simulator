namespace TradingSimulator.Domain.Models.Targets.V1;

public abstract class Target : ITargetOptions
{
    protected Target(ITargetOptions options)
    {
        if (string.IsNullOrWhiteSpace(options.TargetName))
            throw new ArgumentNullException();
        
        TargetName = options.TargetName;
    }
    
    public string TargetName { get; private set; }
}