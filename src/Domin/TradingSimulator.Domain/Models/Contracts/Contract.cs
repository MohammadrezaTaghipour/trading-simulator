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

        if (periods != null && periods.Count(p => p.EndingDateTime is null) > 1)
            throw new ArgumentException("Only one period with openEnding is allowed at a time");

        Id = Guid.NewGuid();
        Title = title;
        if (periods is not null)
            _periods = periods.Select(p =>
                new ContractPeriod(p.StartingDateTime, p.EndingDateTime)).ToList();
    }

    public Guid Id { get; private set; }
    public string Title { get; private set; }
    private readonly List<ContractPeriod>? _periods;
    IReadOnlyList<IContractPeriod>? IContract.Periods => _periods;
    public IReadOnlyList<ContractPeriod>? Periods => _periods;

    public IReadOnlyCollection<IDomainEvent> Changes { get; }
}