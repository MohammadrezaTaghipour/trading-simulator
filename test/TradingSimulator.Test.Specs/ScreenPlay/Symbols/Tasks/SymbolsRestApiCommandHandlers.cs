using TradingSimulator.Infrastructure.Application;
using Suzianna.Core.Screenplay;
using TradingSimulator.Test.Specs.ScreenPlay.Symbols.Commands.Symbols;

namespace TradingSimulator.Test.Specs.ScreenPlay.Symbols.Tasks;

public class SymbolsRestApiCommandHandlers : ICommandHandler<DefineSymbolCommand, ITask>
{
    public Task<ITask> Handle(DefineSymbolCommand command, CancellationToken token)
    {
        var task = new DefineSymbolByRestApiTask(command);
        return Task.FromResult<ITask>(task);
    }
}