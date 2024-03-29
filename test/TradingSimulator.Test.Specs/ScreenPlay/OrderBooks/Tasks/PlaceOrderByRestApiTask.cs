﻿using Suzianna.Core.Screenplay;
using Suzianna.Core.Screenplay.Actors;
using Suzianna.Rest.Screenplay.Interactions;
using TradingSimulator.Test.Specs.ScreenPlay.OrderBooks.Commands;

namespace TradingSimulator.Test.Specs.ScreenPlay.OrderBooks.Tasks;

public class PlaceOrderByRestApiTask: ITask
{
    private readonly PlaceOrderCommand _command;

    public PlaceOrderByRestApiTask(PlaceOrderCommand command)
    {
        _command = command;
    }

    public void PerformAs<T>(T actor) where T : Actor
    {
        actor.AttemptsTo(Patch.DataAsJson(_command)
            .To($"/api/OrderBooks"));
    }
}