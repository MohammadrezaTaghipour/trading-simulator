using OrderBookManagement.Test.Specs.ScreenPlay.Traders.Commands;
using Suzianna.Core.Screenplay;
using Suzianna.Core.Screenplay.Actors;
using Suzianna.Rest.Screenplay.Interactions;

namespace OrderBookManagement.Test.Specs.ScreenPlay.Traders.Tasks;

public class DefineTraderByRestApiTask: ITask
{
    private readonly DefineTraderCommand _command;

    public DefineTraderByRestApiTask(DefineTraderCommand command)
    {
        _command = command;
    }

    public void PerformAs<T>(T actor) where T : Actor
    {
        actor.AttemptsTo(Post.DataAsJson(_command)
            .To($"/api/Traders"));
    }
}