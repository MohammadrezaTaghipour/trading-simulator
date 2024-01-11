using OrderBookManagement.Test.Specs.ScreenPlay.OrderBooks.Commands;
using Suzianna.Core.Screenplay;
using Suzianna.Core.Screenplay.Actors;
using Suzianna.Rest.Screenplay.Interactions;

namespace OrderBookManagement.Test.Specs.ScreenPlay.OrderBooks.Tasks;

public class DefineOrderBookByRestApiTask: ITask
{
    private readonly DefineOrderBookCommand _command;

    public DefineOrderBookByRestApiTask(DefineOrderBookCommand command)
    {
        _command = command;
    }

    public void PerformAs<T>(T actor) where T : Actor
    {
        actor.AttemptsTo(Post.DataAsJson(_command)
            .To($"/api/OrderBooks"));
    }
}