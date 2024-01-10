using OrderBookManagement.Domain.Models.OrderBooks;
using OrderBookManagement.Domain.Models.OrderBooks.Args;
using OrderBookManagement.Domain.Models.Sessions;
using OrderBookManagement.Domain.Models.Symbols;
using OrderBookManagement.Domain.Models.Traders;
using OrderBookManagement.Infrastructure.Application;

namespace OrderBookManagement.Application.Orders;

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