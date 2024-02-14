using TradingSimulator.Domain.Models.Targets.V1;

namespace TradingSimulator.Test.Domain.Targets.V1.Fixtures;

public class TestTarget : Target
{
    public TestTarget(ITargetOptions options) : base(options)
    {
    }
}