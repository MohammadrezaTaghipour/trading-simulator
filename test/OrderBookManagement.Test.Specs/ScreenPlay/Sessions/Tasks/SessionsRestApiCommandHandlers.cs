using OrderBookManagement.Infrastructure.Application;
using OrderBookManagement.Test.Specs.ScreenPlay.Sessions.Commands;
using Suzianna.Core.Screenplay;

namespace OrderBookManagement.Test.Specs.ScreenPlay.Sessions.Tasks;

public class SessionsRestApiCommandHandlers: ICommandHandler<DefineSessionCommand, ITask>
{
    public Task<ITask> Handle(DefineSessionCommand command, CancellationToken token)
    {
        var task = new DefineSessionByRestApiTask(command);
        return Task.FromResult<ITask>(task);
    }
}