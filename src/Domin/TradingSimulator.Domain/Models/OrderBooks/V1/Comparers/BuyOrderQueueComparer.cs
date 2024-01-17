using TradingSimulator.Domain.Models.OrderBooks.V1.Orders;

namespace TradingSimulator.Domain.Models.OrderBooks.V1.Comparers
{
    public class BuyOrderQueueComparer : IComparer<Order>
    {
        public int Compare(Order current, Order old)
        {
            if (ReferenceEquals(current, old)) return 0;

            if (current.Price > old.Price) return -1;

            return 1;
        }
    }
}