using Suzianna.Core.Screenplay.Actors;
using Suzianna.Core.Screenplay.Questions;
using Suzianna.Rest.Screenplay.Interactions;
using Suzianna.Rest.Screenplay.Questions;
using TradingSimulator.Test.Specs.ScreenPlay.Sessions.Questions;

namespace TradingSimulator.Test.Specs.ScreenPlay.Traders.Questions;

public class GetSessionByIdQuestion : IQuestion<SessionQueryResponse>
{
    private readonly Guid _id;

    public GetSessionByIdQuestion(Guid id)
    {
        _id = id;
    }

    public SessionQueryResponse AnsweredBy(Actor actor)
    {
        actor.AttemptsTo(Get.ResourceAt($"/api/Sessions/{_id}"));
        var response = actor.AsksFor(LastResponse.Content<SessionQueryResponse>());
        return response;
    }
}