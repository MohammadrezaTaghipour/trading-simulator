using OrderBookManagement.Domain.Models.Traders;
using OrderBookManagement.Infrastructure.Application;

namespace OrderBookManagement.Application.Traders;

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