using TradingSimulator.Domain.Models.Contracts;
using TradingSimulator.Domain.Models.Contracts.Periods;

namespace TradingSimulator.Test.Domain.Contracts.Fixtures;

public class ContractTestBuilder : IContract
{
    internal ContractTestBuilder()
    {
        Title = "some title";
    }

    public string Title { get; private set; }
    private readonly List<IContractPeriod> _periods = new();
    public IReadOnlyList<IContractPeriod> Periods => _periods;

    public ContractTestBuilder WithTitle(string value)
    {
        Title = value;
        return this;
    }

    public ContractTestBuilder WithOptionalOptions()
    {
        ContractPeriodTestBuilder periodBuilder = new();
        _periods.Add(periodBuilder);
        return this;
    }

    public ContractTestBuilder AddPeriod(IContractPeriod value)
    {
        _periods.Add(value);
        return this;
    }
    
    public Contract Build()
    {
        return new Contract(Title, _periods);
    }
}