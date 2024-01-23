using TradingSimulator.Domain.Models.Contracts;
using TradingSimulator.Domain.Models.Contracts.Periods;

namespace TradingSimulator.Test.Domain.Contracts.Fixtures;

public class ContractPeriodTestBuilder : IContractPeriod
{
    public ContractPeriodTestBuilder()
    {
        StartingDateTime = DateTime.Today;
    }
    
    public DateTime StartingDateTime { get; private set; }
    public DateTime? EndingDateTime { get; private set;}


    public ContractPeriodTestBuilder WithStartingDateTime(DateTime value)
    {
        StartingDateTime = value;
        return this;
    }
    
    public ContractPeriodTestBuilder WithEndingDateTime(DateTime? value)
    {
        EndingDateTime = value;
        return this;
    }

    public ContractPeriodTestBuilder WithAllOptionalOptions()
    {
        EndingDateTime = DateTime.Today;
        return this;
    }
    
    public ContractPeriod Build()
    {
        return new ContractPeriod(StartingDateTime, EndingDateTime);
    }
}