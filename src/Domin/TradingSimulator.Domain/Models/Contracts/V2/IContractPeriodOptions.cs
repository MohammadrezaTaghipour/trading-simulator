namespace TradingSimulator.Domain.Models.Contracts.V2;

public interface IContractPeriodOptions
{
    DateTime? FromDate { get; }
    DateTime? ToDate { get; }
}

public class ContractPeriod : IContractPeriodOptions
{
    public ContractPeriod(IContractPeriodOptions options)
    {
        GuardAgainstInvalidDateRange(options);
        
        FromDate = options.FromDate;
        ToDate = options.ToDate;
    }

    public DateTime? FromDate { get; }
    public DateTime? ToDate { get; }

    void GuardAgainstInvalidDateRange(IContractPeriodOptions options)
    {
        if(options.FromDate is null || options.ToDate is null)
            return;
        if (options.FromDate > options.ToDate)
            throw new InvalidDateRangeException();
    }
}