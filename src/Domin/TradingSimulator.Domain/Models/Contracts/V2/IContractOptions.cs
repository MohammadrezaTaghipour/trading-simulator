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
    }

    private readonly List<ContractPeriod> _periods = new();
    public IReadOnlyList<IContractPeriodOptions> Periods => _periods;
}