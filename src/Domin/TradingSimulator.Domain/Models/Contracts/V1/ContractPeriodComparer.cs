using TradingSimulator.Domain.Models.Contracts.V1.Periods;

namespace TradingSimulator.Domain.Models.Contracts.V1;

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