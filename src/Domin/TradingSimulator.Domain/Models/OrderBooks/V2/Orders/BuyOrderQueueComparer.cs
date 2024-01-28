namespace TradingSimulator.Domain.Models.OrderBooks.V2.Orders
{
    public class BuyOrderQueueComparer : IComparer<IOrder>
    {
        public int Compare(IOrder current, IOrder old)
        {
            if (ReferenceEquals(current, old)) return 0;

            if (current.Price.Value > old.Price.Value) return -1;

            return 1;
        }
    }
}