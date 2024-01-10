using OrderBookManagement.Infrastructure.Application;
using OrderBookManagement.Test.Specs.ScreenPlay.Symbols.Commands.Symbols;
using Suzianna.Core.Screenplay;

namespace OrderBookManagement.Test.Specs.ScreenPlay.Symbols.Tasks;

public class SymbolsRestApiCommandHandlers : ICommandHandler<DefineSymbolCommand, ITask>
{
    public Task<ITask> Handle(DefineSymbolCommand command, CancellationToken token)
    {
        var task = new DefineSymbolByRestApiTask(command);
        return Task.FromResult<ITask>(task);
    }
}