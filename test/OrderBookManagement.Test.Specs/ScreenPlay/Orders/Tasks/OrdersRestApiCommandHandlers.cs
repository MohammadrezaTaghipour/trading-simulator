using OrderBookManagement.Infrastructure.Application;
using OrderBookManagement.Test.Specs.ScreenPlay.Orders.Commands;
using Suzianna.Core.Screenplay;

namespace OrderBookManagement.Test.Specs.ScreenPlay.Orders.Tasks;

public class OrdersRestApiCommandHandlers : ICommandHandler<PlaceOrderCommand, ITask>
{
    public Task<ITask> Handle(PlaceOrderCommand command, CancellationToken token)
    {
        var task = new PlaceOrderByRestApiTask(command);
        return Task.FromResult<ITask>(task);
    }
}