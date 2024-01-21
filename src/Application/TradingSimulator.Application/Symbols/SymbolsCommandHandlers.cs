using TradingSimulator.Domain.Models.Symbols;
using TradingSimulator.Infrastructure.Application;

namespace TradingSimulator.Application.Symbols;

public class SymbolsCommandHandlers : ICommandHandler<DefineSymbolCommand>
{
    private readonly ISymbolRepository _repository;

    public SymbolsCommandHandlers(ISymbolRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(DefineSymbolCommand command, CancellationToken token)
    {
        var symbol = new SymbolBuilder()
            .WithCode(command.Code)
            .Build();
        await _repository.Add(symbol, token);
    }
}