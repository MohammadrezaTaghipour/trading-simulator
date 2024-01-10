using OrderBookManagement.Infrastructure.Application;
using OrderBookManagement.Test.Specs.ScreenPlay.Traders.Commands;
using Suzianna.Core.Screenplay;

namespace OrderBookManagement.Test.Specs.ScreenPlay.Traders.Tasks;

public class TradersRestApiCommandHandlers: ICommandHandler<DefineTraderCommand, ITask>
{
    public Task<ITask> Handle(DefineTraderCommand command, CancellationToken token)
    {
        var task = new DefineTraderByRestApiTask(command);
        return Task.FromResult<ITask>(task);
    }
}