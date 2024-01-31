using TradingSimulator.Domain.Models.Contracts.V2;

namespace TradingSimulator.Test.Domain.Contracts.V2.ContractPeriods;

public class ContractPeriodTestBuilder : IContractPeriodOptions
{
    public DateTime? FromDate { get; private set; }
    public DateTime? ToDate { get; private set; }

    public ContractPeriod Build()
    {
        return new ContractPeriod(this);
    }

    public ContractPeriodTestBuilder WithOptionalReferences()
    {
        FromDate = Constants.From_Some_Day;
        ToDate = Constants.From_Some_Day;
        return this;
    }

    public ContractPeriodTestBuilder WithFromDate(DateTime? fromDate)
    {
        FromDate = fromDate;
        return this;
    }

    public ContractPeriodTestBuilder WithToDate(DateTime? toDate)
    {
        ToDate = toDate;
        return this;
    }
}