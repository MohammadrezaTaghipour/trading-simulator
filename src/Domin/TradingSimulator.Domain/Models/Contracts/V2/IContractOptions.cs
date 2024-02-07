using TradingSimulator.Domain.Models.Parties.V2;

namespace TradingSimulator.Domain.Models.Contracts.V2;

public interface IContractOptions
{
    IReadOnlyList<IContractPeriodOptions> Periods { get; }
}

public class Contract : IContractOptions
{
    public Contract(IContractOptions options)
    {
        options.Periods.ToList().ForEach(p =>
        {
            var period = new ContractPeriod(p);
            _periods.Add(period);
        });
        GuardAgainstPeriodsOverlap(_periods);
    }

    private readonly List<ContractPeriod> _periods = new();
    public IReadOnlyList<IContractPeriodOptions> Periods => _periods;

    static void GuardAgainstPeriodsOverlap(List<ContractPeriod> periods)
    {
        foreach (var key in periods)
        {
            var currentIndex = periods.IndexOf(key);
            var overlapFound = periods.Where(p => periods.IndexOf(p) > currentIndex)
                .Any(term =>
                {
                    var starting1 = key.FromDate ?? DateTime.MinValue;
                    var ending1 = key.ToDate ?? DateTime.MaxValue;

                    var starting2 = term.FromDate ?? DateTime.MinValue;
                    var ending2 = term.ToDate ?? DateTime.MaxValue;

                    return (starting2 < ending1 && starting1 < ending2);
                });
            if (overlapFound)
                throw new InvalidDataException();
        }
    }
}