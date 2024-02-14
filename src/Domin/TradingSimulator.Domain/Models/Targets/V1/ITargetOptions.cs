
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TradingSimulator.Test.Domain")]

namespace TradingSimulator.Domain.Models.Targets.V1;

public interface ITargetOptions
{
    string TargetName { get; }
}