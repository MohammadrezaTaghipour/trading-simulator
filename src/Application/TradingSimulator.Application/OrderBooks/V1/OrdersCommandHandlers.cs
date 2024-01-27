using TradingSimulator.Application.OrderBooks.V1.Commands;
using TradingSimulator.Domain.Models.OrderBooks.V1;
using TradingSimulator.Domain.Models.OrderBooks.V1.Args;
using TradingSimulator.Domain.Models.OrderBooks.V1.Orders;
using TradingSimulator.Domain.Models.Sessions;
using TradingSimulator.Domain.Models.Traders;
using TradingSimulator.Infrastructure.Application;
using TradingSimulator.Infrastructure.Utils;

namespace TradingSimulator.Application.OrderBooks.V1;

public class OrdersCommandHandlers :
    ICommandHandler<DefineOrderBookCommand>,
    ICommandHandler<PlaceOrderCommand>
{
    private readonly IOrderBookRepository _repository;
    private readonly IDateTimeProvider _dateTimeProvider;

    public OrdersCommandHandlers(IOrderBookRepository repository,
        IDateTimeProvider dateTimeProvider)
    {
        _repository = repository;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task Handle(DefineOrderBookCommand command, CancellationToken token)
    {
        var arg = CreateArgFrom(command);
        var orderBook = new OrderBook(arg);
        await _repository.Add(orderBook, token);
    }

    public async Task Handle(PlaceOrderCommand command, CancellationToken token)
    {
        var orderBookId = new OrderBookId(command.SymbolId,
            new SessionId(command.SessionId));
        var orderBook = await _repository.GetBy(orderBookId, token);
        var arg = CreateArgFrom(command);
        orderBook.PlaceOrder(arg, _dateTimeProvider);
        await _repository.Add(orderBook, token);
    }

    private DefineOrderBookArg CreateArgFrom(DefineOrderBookCommand command)
    {
        return new DefineOrderBookArg
        {
            Title = command.Title,
            SessionId = new SessionId(command.SessionId),
            SymbolId = command.SymbolId
        };
    }

    private PlaceOrderArg CreateArgFrom(PlaceOrderCommand command)
    {
        return new PlaceOrderArg
        {
            TraderId = new TraderId(command.TraderId),
            SessionId = new SessionId(command.SessionId),
            SymbolId = command.SymbolId,
            Cmd = Enum.Parse<OrderType>(command.Cmd),
            Volume = new OrderVolume(command.Volume),
            // Price = new Money(command.Price)
        };
    }
}