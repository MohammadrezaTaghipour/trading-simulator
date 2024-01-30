using TradingSimulator.Domain.Models.Contracts.Periods;

namespace TradingSimulator.Domain.Models.Contracts;

public class ContractPeriodComparer : IComparer<ContractPeriod>
{
    public int Compare(ContractPeriod firstPeriod, ContractPeriod secondPeriod)
    {
        if (ReferenceEquals(firstPeriod, secondPeriod)) return 0;

        if (firstPeriod.StartingDateTime is not null && secondPeriod.StartingDateTime is null) 
            return 1;
        if (firstPeriod.StartingDateTime is null && secondPeriod.StartingDateTime is not null) 
            return -1;

        if (firstPeriod.StartingDateTime.Value > secondPeriod.StartingDateTime.Value) return 1;

        return -1;
    }
}