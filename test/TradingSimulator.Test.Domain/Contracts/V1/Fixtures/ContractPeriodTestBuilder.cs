using TradingSimulator.Domain.Models.Contracts.V1.Periods;

namespace TradingSimulator.Test.Domain.Contracts.V1.Fixtures;

public class ContractPeriodTestBuilder : IContractPeriod
{
    internal ContractPeriodTestBuilder()
    {
        StartingDateTime = DateTime.Today;
        EndingDateTime = null;
    }
    
    public DateTime? StartingDateTime { get; private set; }
    public DateTime? EndingDateTime { get; private set;}


    public ContractPeriodTestBuilder WithStartingDateTime(DateTime? value)
    {
        StartingDateTime = value;
        return this;
    }
    
    public ContractPeriodTestBuilder WithEndingDateTime(DateTime? value)
    {
        EndingDateTime = value;
        return this;
    }

    public ContractPeriodTestBuilder WithOptionalReferences()
    {
        EndingDateTime = DateTime.Today;
        return this;
    }
    
    public ContractPeriod Build()
    {
        return new ContractPeriod(StartingDateTime, EndingDateTime);
    }
}