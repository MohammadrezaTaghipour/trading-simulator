﻿using TradingSimulator.Domain.Models.Contracts.V2;
using TradingSimulator.Test.Domain.Contracts.V2.ContractPeriods;

namespace TradingSimulator.Test.Domain.Contracts.V2.Contracts;

public class ContractTestBuilder : IContractOptions
{
    private readonly List<IContractPeriodOptions> _periods = new();
    public IReadOnlyList<IContractPeriodOptions> Periods => _periods;

    public Contract Build()
    {
        return new Contract(this);
    }

    public ContractTestBuilder WithOptionalReferences()
    {
        ContractPeriodTestBuilder periodTestBuilder = new();
        _periods.Add(periodTestBuilder);
        return this;
    }

    public ContractTestBuilder AddPeriod(DateTime? fromDate, DateTime? toDate)
    {
        var periodTestBuilder = new ContractPeriodTestBuilder()
            .WithFromDate(fromDate)
            .WithToDate(toDate);
        _periods.Add(periodTestBuilder);
        return this;
    }

    public ContractTestBuilder AddPeriods(List<Tuple<DateTime?, DateTime?>> periods)
    {
        var periodTestBuilder = new ContractPeriodTestBuilder();
        periods.ForEach(p =>
        {
            periodTestBuilder
                .WithFromDate(p.Item1)
                .WithToDate(p.Item2);
            _periods.Add(periodTestBuilder);
        });
        return this;
    }
}