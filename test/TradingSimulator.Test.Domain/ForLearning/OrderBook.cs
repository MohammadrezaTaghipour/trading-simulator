using System.Collections;

namespace TradingSimulator.Test.Domain.ForLearning;

public class OrderBook : IOrderBook
{
    public Guid Id { get; }
    private readonly Hashtable _orders = new Hashtable();
    private readonly PriorityQueue<IOrder, IOrder> _incomingSellQueue = new();
    private readonly PriorityQueue<IOrder, IOrder> _incomingBuyQueue= new();
    

    public OrderBook(IOrderBookOptions options)
    {
        Id = options.Id;
    }
    
    public async Task AddOrder(IOrderOptions options, IMatchEngine matchEngine)
    {
        IOrder incomingOrder = new Order(options.Id, options.Price, options.Volume);
        _orders.Add(options.Id, incomingOrder);
        await matchEngine.Process(incomingOrder, _incomingSellQueue);
    }
}