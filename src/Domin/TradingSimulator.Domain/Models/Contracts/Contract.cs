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

            if (periods.Count(p => p.EndingDateTime is null) > 1)
                throw new ArgumentException("Only one period with openEnding is allowed at a time");

            if (Overlaps(periods.Select(p => new ContractPeriod(p.StartingDateTime, p.EndingDateTime)).ToArray()))
                throw new ArgumentException("Periods can overlap each other");
        }
    }

    public Guid Id { get; private set; }
    public string Title { get; private set; }
    private readonly List<ContractPeriod>? _periods;
    IReadOnlyList<IContractPeriod>? IContract.Periods => _periods;
    public IReadOnlyList<ContractPeriod>? Periods => _periods;

    public IReadOnlyCollection<IDomainEvent> Changes { get; }

    private static bool Overlaps(ContractPeriod[] arr)
    {
        // Sort intervals in increasing order of start time
        Array.Sort(arr, (i1, i2) => i1.StartingDateTime.CompareTo(i2.EndingDateTime));

        var n = arr.Length;
        for (int i = 1; i < n; i++)
        {
            if (arr[i - 1].EndingDateTime > arr[i].StartingDateTime)
            {
                return true;
            }
        }

        // If we reach here, then no overlap
        return false;
    }
}