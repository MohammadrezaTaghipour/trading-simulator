using Suzianna.Core.Screenplay;
using Suzianna.Core.Screenplay.Actors;
using Suzianna.Rest.Screenplay.Interactions;
using TradingSimulator.Test.Specs.ScreenPlay.Sessions.Commands;

namespace TradingSimulator.Test.Specs.ScreenPlay.Sessions.Tasks;

public class DefineSessionByRestApiTask: ITask
{
    private readonly DefineSessionCommand _command;

    public DefineSessionByRestApiTask(DefineSessionCommand command)
    {
        _command = command;
    }

    public void PerformAs<T>(T actor) where T : Actor
    {
        actor.AttemptsTo(Post.DataAsJson(_command)
            .To($"/api/Sessions"));
    }
}