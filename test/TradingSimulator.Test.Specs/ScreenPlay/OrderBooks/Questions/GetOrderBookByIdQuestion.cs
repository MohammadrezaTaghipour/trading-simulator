using Suzianna.Core.Screenplay.Actors;
using Suzianna.Core.Screenplay.Questions;
using Suzianna.Rest.Screenplay.Interactions;
using Suzianna.Rest.Screenplay.Questions;

namespace TradingSimulator.Test.Specs.ScreenPlay.OrderBooks.Questions;

public class GetOrderBookByIdQuestion: IQuestion<OrderBookQueryResponse>
{
    private readonly Guid _id;

    public GetOrderBookByIdQuestion(Guid id)
    {
        _id = id;
    }

    public OrderBookQueryResponse AnsweredBy(Actor actor)
    {
        actor.AttemptsTo(Get.ResourceAt($"/api/OrderBooks/{_id}"));
        var response = actor.AsksFor(LastResponse.Content<OrderBookQueryResponse>());
        return response;
    }
}