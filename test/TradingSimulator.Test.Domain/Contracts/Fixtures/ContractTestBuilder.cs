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

    public ContractTestBuilder WithSomePeriodsHavingMoreThanOneOpenEnding()
    {
        var today = DateTime.Today;
        var periods = new List<ContractPeriodTestBuilder>()
        {
            new ContractPeriodTestBuilder()
                .WithStartingDateTime(today)
                .WithEndingDateTime(null),
            new ContractPeriodTestBuilder()
                .WithStartingDateTime(today)
                .WithEndingDateTime(null),
        };
        periods.ForEach(p=> AddPeriod(p));
        return this;
    }
    
    public ContractTestBuilder WithSomeOverlappingPeriods()
    {
        var firstPeriod = Tuple.Create(DateTime.Today, DateTime.Today.AddDays(6));
        var secondPeriod = Tuple.Create(DateTime.Today.AddDays(1), DateTime.Today.AddDays(6));
        var thirdPeriod = Tuple.Create(DateTime.Today.AddDays(3), DateTime.Today.AddDays(4));
        var periods = new List<ContractPeriodTestBuilder>()
        {
            new ContractPeriodTestBuilder()
                .WithStartingDateTime(firstPeriod.Item1)
                .WithEndingDateTime(firstPeriod.Item2),
            new ContractPeriodTestBuilder()
                .WithStartingDateTime(secondPeriod.Item1)
                .WithEndingDateTime(secondPeriod.Item2),
            new ContractPeriodTestBuilder()
                .WithStartingDateTime(thirdPeriod.Item1)
                .WithEndingDateTime(thirdPeriod.Item2),
        };
        periods.ForEach(p=> AddPeriod(p));

        return this;
    }
    
    public Contract Build()
    {
        return new Contract(Title, _periods);
    }
}