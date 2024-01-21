using TradingSimulator.Infrastructure.Domain;

namespace TradingSimulator.Domain.Models.OrderBooks.V2.Entities;

public interface IOrder : IOrderOptions, IEntity<OrderId>
{
    
}