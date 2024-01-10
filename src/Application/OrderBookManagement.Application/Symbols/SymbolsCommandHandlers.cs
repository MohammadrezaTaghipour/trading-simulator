using OrderBookManagement.Domain.Models.Symbols;
using OrderBookManagement.Infrastructure.Application;

namespace OrderBookManagement.Application.Symbols;

public class SymbolsCommandHandlers : ICommandHandler<DefineSymbolCommand>
{
    private readonly ISymbolRepository _repository;

    public SymbolsCommandHandlers(ISymbolRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(DefineSymbolCommand command, CancellationToken token)
    {
        var symbol = new Symbol(SymbolId.New(), command.Code);
        await _repository.Add(symbol, token);
    }
}