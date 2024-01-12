namespace TradingSimulator.Test.Specs.Shared;

public class Calendar
{
    public Calendar(string dayOfWeek, DateTime date)
    {
        DayOfWeek = dayOfWeek;
        Date = date;
    }

    public string DayOfWeek { get; private set; }
    public DateTime Date { get; private set; }
}