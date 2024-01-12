using TradingSimulator.Domain.Models.OrderBooks;
using TradingSimulator.Domain.Models.OrderBooks.Args;
using TradingSimulator.Domain.Models.Sessions;
using TradingSimulator.Domain.Models.Symbols;
using TradingSimulator.Domain.Models.Traders;
using TradingSimulator.Infrastructure.Application;

namespace TradingSimulator.Application.Orders;

public class OrdersCommandHandlers : ICommandHandler<PlaceOrderCommand>
{
    private readonly IOrderBookRepository _repository;

    public OrdersCommandHandlers(IOrderBookRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(PlaceOrderCommand command, CancellationToken token)
    {
        var orderBook = await _repository.GetBy(new OrderBookId(command.OrderBookId), token);
        var arg = CreateArgFrom(command);
        orderBook.PlaceOrder(arg);
        await _repository.Add(orderBook, token);
    }

    private PlaceOrderArg CreateArgFrom(PlaceOrderCommand command)
    {
        return new PlaceOrderArg
        {
            TraderId = new TraderId(command.TraderId),
            SessionId = new SessionId(command.SessionId),
            SymbolId = new SymbolId(command.SymbolId),
            Cmd = Enum.Parse<OrderCommandType>(command.Cmd),
            Volume = command.Volume,
            Price = command.Price
        };
    }
}