using OrderBookManagement.Test.Specs.ScreenPlay.Sessions.Commands;
using Suzianna.Core.Screenplay;
using Suzianna.Core.Screenplay.Actors;
using Suzianna.Rest.Screenplay.Interactions;

namespace OrderBookManagement.Test.Specs.ScreenPlay.Sessions.Tasks;

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