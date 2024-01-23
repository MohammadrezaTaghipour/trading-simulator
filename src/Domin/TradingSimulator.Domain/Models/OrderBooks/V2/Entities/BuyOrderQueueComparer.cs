namespace TradingSimulator.Domain.Models.OrderBooks.V2.Entities
{
    public class BuyOrderQueueComparer : IComparer<IOrder>
    {
        public int Compare(IOrder current, IOrder old)
        {
            if (ReferenceEquals(current, old)) return 0;

            if (current.Price > old.Price) return -1;

            return 1;
        }
    }
}