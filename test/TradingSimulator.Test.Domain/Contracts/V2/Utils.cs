namespace TradingSimulator.Test.Domain.Contracts.V2;

public static class Utils
{
    public static Tuple<DateTime?, DateTime?> CreatePeriod(int? fromDate, int? toDate)
    {
        return new(
            fromDate.HasValue ? Constants.From_Some_Day.AddDays(fromDate.Value) : null,
            toDate.HasValue ? Constants.From_Some_Day.AddDays(toDate.Value) : null
        );
    }

    public static List<Tuple<DateTime?, DateTime?>> CreatePeriod(
        int? fromDate1, int? toDate1,
        int? fromDate2, int? toDate2)
    {
        return new List<Tuple<DateTime?, DateTime?>>
            {
                new(
                    fromDate1.HasValue ? Constants.From_Some_Day.AddDays(fromDate1.Value) : null,
                    toDate1.HasValue ? Constants.From_Some_Day.AddDays(toDate1.Value) : null
                ),
                new(
                    fromDate2.HasValue ? Constants.From_Some_Day.AddDays(fromDate2.Value) : null,
                    toDate2.HasValue ? Constants.From_Some_Day.AddDays(toDate2.Value) : null
                )
            };
    }
}