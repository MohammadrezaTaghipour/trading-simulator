using OrderBookManagement.Infrastructure.Domain;

namespace OrderBookManagement.Domain.Models.Traders;

public class Trader : AggregateRoot<TraderId>
{
    private Trader()
    {
    }

    public Trader(TraderId id, string name)
    {
        Id = id;
        Name = name;
    }

    public string Name { get; private set; }
}