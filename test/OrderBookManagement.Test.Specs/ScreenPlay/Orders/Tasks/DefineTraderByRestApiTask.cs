using OrderBookManagement.Test.Specs.ScreenPlay.Orders.Commands;
using Suzianna.Core.Screenplay;
using Suzianna.Core.Screenplay.Actors;
using Suzianna.Rest.Screenplay.Interactions;

namespace OrderBookManagement.Test.Specs.ScreenPlay.Orders.Tasks;

public class PlaceOrderByRestApiTask: ITask
{
    private readonly PlaceOrderCommand _command;

    public PlaceOrderByRestApiTask(PlaceOrderCommand command)
    {
        _command = command;
    }

    public void PerformAs<T>(T actor) where T : Actor
    {
        actor.AttemptsTo(Post.DataAsJson(_command)
            .To($"/api/Orders"));
    }
}