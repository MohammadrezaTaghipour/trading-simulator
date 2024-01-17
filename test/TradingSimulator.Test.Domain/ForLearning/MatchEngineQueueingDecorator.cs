namespace TradingSimulator.Test.Domain.ForLearning;

public class MatchEngineQueueingDecorator : IMatchEngine
{
    private IMatchEngine _decoratee;
    private TaskCompletionSource<string> Complete = new();

    public MatchEngineQueueingDecorator(IMatchEngine decoratee)
    {
        _decoratee = decoratee;
    }

    public Task<string> Process(IOrder incomingOrder, PriorityQueue<IOrder, IOrder> matchingQueue)
    {
        Task.Delay(TimeSpan.FromSeconds(5))
            .ContinueWith(_ =>
            {
                _decoratee.Process(incomingOrder, matchingQueue);
                Complete.SetResult("ok");
            });
        return Complete.Task;
    }
}