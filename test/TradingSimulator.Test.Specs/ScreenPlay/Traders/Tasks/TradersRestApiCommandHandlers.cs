using TradingSimulator.Infrastructure.Application;
using Suzianna.Core.Screenplay;
using TradingSimulator.Test.Specs.ScreenPlay.Traders.Commands;

namespace TradingSimulator.Test.Specs.ScreenPlay.Traders.Tasks;

public class TradersRestApiCommandHandlers: ICommandHandler<DefineTraderCommand, ITask>
{
    public Task<ITask> Handle(DefineTraderCommand command, CancellationToken token)
    {
        var task = new DefineTraderByRestApiTask(command);
        return Task.FromResult<ITask>(task);
    }
}