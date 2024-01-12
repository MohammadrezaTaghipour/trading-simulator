using TechTalk.SpecFlow;

namespace TradingSimulator.Test.Specs.Shared;

public static class CalenderService
{
    //TODO: this data structure is wrong to represent natural calendar 
    private static readonly Dictionary<string, Calendar> Calendars = new();

    public static void Set(string dayOfWeek, DateTime date)
    {
        if (!Calendars.ContainsKey(dayOfWeek))
            Calendars.Add(dayOfWeek, new Calendar(dayOfWeek, date));
    }

    public static Calendar? Get(string dayOfWeek)
    {
        Calendars.TryGetValue(dayOfWeek, out var calendar);
        return calendar;
    }
}