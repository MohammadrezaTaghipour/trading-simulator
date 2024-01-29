using TradingSimulator.Application.OrderBooks.V2.Commands;
using TradingSimulator.Domain.Models.OrderBooks.V2;
using TradingSimulator.Domain.Models.OrderBooks.V2.Orders;
using TradingSimulator.Infrastructure.Application;

namespace TradingSimulator.Application.OrderBooks.V2;

public class OrderCommandHandlersV2 :
    ICommandHandler<EnqueueOrderCommand, EnqueueOrderCommandResult>
{
    private readonly IOrderBookRepository _repository;

    public OrderCommandHandlersV2(IOrderBookRepository repository)
    {
        _repository = repository;
    }

    public async Task<EnqueueOrderCommandResult> Handle(EnqueueOrderCommand command,
        CancellationToken token)
    {
        var orderBook = await _repository.GetBy(new OrderBookId(command.SymbolId), token);
        if (orderBook is null)
            throw new Exception($"OrderBook with id: {command.SymbolId.ToString()} not found");

        var builder = makeOrderBuilder(command);

        var enqueuedOrder = orderBook.EnqueueOrder(builder.Build());

        await _repository.Add(orderBook, token);

        return new EnqueueOrderCommandResult
        {
            OrderId = enqueuedOrder.Id.Id
        };
    }

    private static OrderBuilder makeOrderBuilder(EnqueueOrderCommand command)
    {
        return new OrderBuilder()
            .WithOrderType(command.CommandType)
            .WithPrice(command.Price)
            .WithVolume(command.Volume);
    }
}