using Suzianna.Core.Screenplay.Actors;
using Suzianna.Core.Screenplay.Questions;
using Suzianna.Rest.Screenplay.Interactions;
using Suzianna.Rest.Screenplay.Questions;

namespace OrderBookManagement.Test.Specs.ScreenPlay.Sessions.Questions;

public class GetSessionByIdQuestion: IQuestion<SessionQueryResponse>
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