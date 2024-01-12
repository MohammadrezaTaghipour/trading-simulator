using TradingSimulator.Domain.Models.Traders;
using TradingSimulator.Infrastructure.Application;

namespace TradingSimulator.Application.Traders;

public class TradersCommandHandlers : ICommandHandler<DefineTraderCommand>
{
    private readonly ITraderRepository _repository;

    public TradersCommandHandlers(ITraderRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(DefineTraderCommand command, CancellationToken token)
    {
        var trader = new Trader(new TraderId(command.Id), command.Name);
        await _repository.Add(trader, token);
    }
}