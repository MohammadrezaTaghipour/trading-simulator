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

        var index = 0;
        while (index + 1 < _periods.Count && _periods.Count > 0)
        { var key = _periods[index];
            var term = _periods[index + 1];
            if ((key.FromDate is null && key.ToDate is null)
                ||
                (term.FromDate is null && term.ToDate is null)
                ||
                (key.FromDate is null && key.ToDate > term.FromDate)
                ||
                (key.ToDate is null && key.FromDate < term.ToDate)
                ||
                (key.ToDate > term.FromDate && term.ToDate is null)
                ||
                (key.ToDate < term.ToDate && term.FromDate is null)
                ||
                (key.FromDate < term.ToDate && key.ToDate > term.FromDate))
                throw new InvalidDataException();
            index += 1;
        }
    }

    private readonly List<ContractPeriod> _periods = new();
    public IReadOnlyList<IContractPeriodOptions> Periods => _periods;
}