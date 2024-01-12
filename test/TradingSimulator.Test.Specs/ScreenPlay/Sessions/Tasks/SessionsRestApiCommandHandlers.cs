using TradingSimulator.Infrastructure.Application;
using Suzianna.Core.Screenplay;
using TradingSimulator.Test.Specs.ScreenPlay.Sessions.Commands;

namespace TradingSimulator.Test.Specs.ScreenPlay.Sessions.Tasks;

public class SessionsRestApiCommandHandlers: ICommandHandler<DefineSessionCommand, ITask>
{
    public Task<ITask> Handle(DefineSessionCommand command, CancellationToken token)
    {
        var task = new DefineSessionByRestApiTask(command);
        return Task.FromResult<ITask>(task);
    }
}