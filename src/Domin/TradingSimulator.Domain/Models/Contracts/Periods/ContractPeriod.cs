using TradingSimulator.Infrastructure.Domain;

namespace TradingSimulator.Domain.Models.Contracts.Periods;

public class ContractPeriod : IContractPeriod, IEntity<Guid>
{
    internal ContractPeriod(DateTime? starting, DateTime? ending)
    {
        if (ending < starting)
            throw new PeriodEndingDateTimeIsLessThanStartingDateTime();
        
        Id = Guid.NewGuid();
        StartingDateTime = starting;
        EndingDateTime = ending;
    }

    public Guid Id { get; private set; }
    public DateTime? StartingDateTime { get; private set; }
    public DateTime? EndingDateTime { get; private set;}
}