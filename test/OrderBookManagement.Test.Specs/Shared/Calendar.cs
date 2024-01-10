using TechTalk.SpecFlow;

namespace OrderBookManagement.Test.Specs.Shared;

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

[Binding]
public class Calendars
{
    [Given("The day of week is '(.*)' with date '(.*)'")]
    public void Func(string dayOffWeek, DateTime date)
    {
        CalenderService.Set(dayOffWeek, date);
    }
}