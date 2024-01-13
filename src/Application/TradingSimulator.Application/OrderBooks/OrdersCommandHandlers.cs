using TradingSimulator.Domain.Models.OrderBooks;
using TradingSimulator.Domain.Models.OrderBooks.Args;
using TradingSimulator.Domain.Models.OrderBooks.Orders;
using TradingSimulator.Domain.Models.Sessions;
using TradingSimulator.Domain.Models.Symbols;
using TradingSimulator.Domain.Models.Traders;
using TradingSimulator.Infrastructure.Application;

namespace TradingSimulator.Application.OrderBooks;

public class OrdersCommandHandlers :
    ICommandHandler<DefineOrderBookCommand>,
    ICommandHandler<PlaceOrderCommand>
{
    private readonly IOrderBookRepository _repository;

    public OrdersCommandHandlers(IOrderBookRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(DefineOrderBookCommand command, CancellationToken token)
    {
        var arg = CreateArgFrom(command);
        var orderBook = new OrderBook(arg);
        await _repository.Add(orderBook, token);
    }

    public async Task Handle(PlaceOrderCommand command, CancellationToken token)
    {
        var orderBook = await _repository.GetBy(new OrderBookId(command.OrderBookId), token);
        var arg = CreateArgFrom(command);
        orderBook.PlaceOrder(arg);
        await _repository.Add(orderBook, token);
    }

    private DefineOrderBookArg CreateArgFrom(DefineOrderBookCommand command)
    {
        return new DefineOrderBookArg
        {
            Id = new OrderBookId(new SymbolId(command.SymbolId), new SessionId(command.SessionId)),
            Title = command.Title,
            SessionId = new SessionId(command.SessionId),
            SymbolId = new SymbolId(command.SymbolId)
        };
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