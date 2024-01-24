using TradingSimulator.Domain.Models.Contracts.Periods;
using TradingSimulator.Infrastructure.Domain;

namespace TradingSimulator.Domain.Models.Contracts;

public class Contract : IContract, IAggregateRoot<Guid>
{
    public Contract(string title, IReadOnlyList<IContractPeriod>? periods)
    {
        if (string.IsNullOrEmpty(title) || string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title is required");

        if (title.Length > 32)
            throw new ArgumentException("Title length is required");

        Id = Guid.NewGuid();
        Title = title;
        if (periods is not null)
        {
            _periods = periods.Select(p =>
                new ContractPeriod(p.StartingDateTime, p.EndingDateTime)).ToList();

            GuardAgainstInvalidOpenEndings(_periods);

            GuardAgainstOverlap(_periods);
        }
    }

    public Guid Id { get; private set; }
    public string Title { get; private set; }
    private readonly List<ContractPeriod> _periods = [];
    IReadOnlyList<IContractPeriod>? IContract.Periods => _periods;
    public IReadOnlyList<ContractPeriod>? Periods => _periods;

    public IReadOnlyCollection<IDomainEvent> Changes { get; }


    public void AddPeriods(params IContractPeriod[] periods)
    {
        if (periods.Length == 0) return;
        
        periods.ToList().ForEach(p => { _periods
            .Add(new ContractPeriod(p.StartingDateTime, p.EndingDateTime)); });
        
        GuardAgainstInvalidOpenEndings(_periods);
        GuardAgainstOverlap(_periods);
    }

    private static void GuardAgainstInvalidOpenEndings(IEnumerable<ContractPeriod> periods)
    {
        if (periods.Count(p => p.EndingDateTime is null) > 1)
            throw new ArgumentException("Only one period with openEnding is allowed at a time");
    }
    
    private static void GuardAgainstOverlap(IEnumerable<ContractPeriod> periods)
    {
        if (Overlaps(periods))
            throw new ArgumentException("Periods can't overlap each other");
    }
    
    private static bool Overlaps(IEnumerable<ContractPeriod> periods)
    {
        // Sort intervals in increasing order of start time
        var arr = periods.ToArray();
        Array.Sort(arr, (i1, i2) => i1.StartingDateTime.CompareTo(i2.EndingDateTime));

        var n = arr.Length;
        for (int i = 1; i < n; i++)
        {
            if (arr[i - 1].EndingDateTime >= arr[i].StartingDateTime)
            {
                return true;
            }
        }

        // If we reach here, then no overlap
        return false;
    }
}