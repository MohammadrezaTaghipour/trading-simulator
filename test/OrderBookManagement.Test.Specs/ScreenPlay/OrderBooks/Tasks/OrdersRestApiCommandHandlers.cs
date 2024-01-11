using OrderBookManagement.Infrastructure.Application;
using OrderBookManagement.Test.Specs.ScreenPlay.OrderBooks.Commands;
using Suzianna.Core.Screenplay;

namespace OrderBookManagement.Test.Specs.ScreenPlay.OrderBooks.Tasks;

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