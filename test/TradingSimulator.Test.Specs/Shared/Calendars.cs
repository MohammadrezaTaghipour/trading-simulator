using TechTalk.SpecFlow;

namespace TradingSimulator.Test.Specs.Shared;

[Binding]
public class Calendars
{
    [Given("The day of week is '(.*)' with date '(.*)'")]
    public void Func(string dayOffWeek, DateTime date)
    {
        CalenderService.Set(dayOffWeek, date);
    }
}