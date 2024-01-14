namespace TradingSimulator.Domain.Models.OrderBooks;

public class BuyOrderQueueComparer : IComparer<MatchOrderItem>
{
    public int Compare(MatchOrderItem current, MatchOrderItem old)
    {
        if (ReferenceEquals(current, old)) return 0;

        if (current.Price > old.Price) return -1;

        return 1;
    }
}