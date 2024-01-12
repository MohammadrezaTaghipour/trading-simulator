using TradingSimulator.Infrastructure.Application;
using Suzianna.Core.Screenplay;
using TradingSimulator.Test.Specs.ScreenPlay.OrderBooks.Commands;

namespace TradingSimulator.Test.Specs.ScreenPlay.OrderBooks.Tasks;

public class OrdersRestApiCommandHandlers :
    ICommandHandler<DefineOrderBookCommand, ITask>,
    ICommandHandler<PlaceOrderCommand, ITask>
{
    public Task<ITask> Handle(DefineOrderBookCommand command, CancellationToken token)
    {
        var task = new DefineOrderBookByRestApiTask(command);
        return Task.FromResult<ITask>(task);
    }

    public Task<ITask> Handle(PlaceOrderCommand command, CancellationToken token)
    {
        var task = new PlaceOrderByRestApiTask(command);
        return Task.FromResult<ITask>(task);
    }
}