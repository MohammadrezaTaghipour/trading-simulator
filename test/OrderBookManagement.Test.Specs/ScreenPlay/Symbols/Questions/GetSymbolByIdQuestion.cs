using Suzianna.Core.Screenplay.Actors;
using Suzianna.Core.Screenplay.Questions;
using Suzianna.Rest.Screenplay.Interactions;
using Suzianna.Rest.Screenplay.Questions;

namespace OrderBookManagement.Test.Specs.ScreenPlay.Symbols.Questions;

public class GetSymbolByIdQuestion : IQuestion<SymbolQueryResponse>
{
    private readonly Guid _id;

    public GetSymbolByIdQuestion(Guid id)
    {
        _id = id;
    }

    public SymbolQueryResponse AnsweredBy(Actor actor)
    {
        actor.AttemptsTo(Get.ResourceAt($"/api/Symbols/{_id}"));
        var response = actor.AsksFor(LastResponse.Content<SymbolQueryResponse>());
        return response;
    }
}