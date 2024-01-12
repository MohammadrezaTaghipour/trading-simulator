using Suzianna.Core.Screenplay;
using Suzianna.Core.Screenplay.Actors;
using Suzianna.Rest.Screenplay.Interactions;
using TradingSimulator.Test.Specs.ScreenPlay.Symbols.Commands.Symbols;

namespace TradingSimulator.Test.Specs.ScreenPlay.Symbols.Tasks;

public class DefineSymbolByRestApiTask : ITask
{
    private readonly DefineSymbolCommand _command;

    public DefineSymbolByRestApiTask(DefineSymbolCommand command)
    {
        _command = command;
    }

    public void PerformAs<T>(T actor) where T : Actor
    {
        actor.AttemptsTo(Post.DataAsJson(_command)
            .To($"/api/Symbols"));
    }
}