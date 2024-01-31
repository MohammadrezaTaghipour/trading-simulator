using System.Collections;

namespace TradingSimulator.Test.Domain.Contracts.V2.TestData;

public class SinglePeriodExamples : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        //  ()
        //  <()
        //  ()>
        //  <()>

        yield return new object[] { Constants.Some_Day, Constants.Some_Day };
        yield return new object[] { null, Constants.Some_Day };
        yield return new object[] { Constants.Some_Day, null };
        yield return new object[] { null, null };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class TwoPeriodsExamples : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        //  []  ()
        //  <[] ()
        //  []  ()>
        //  <[] ()>
        
        // ()  []
        // ()  []>
        // <() []
        // <() []>
        
        // [    (]  ]
        //  

        yield return new object[] { Constants.Some_Day, Constants.Some_Day };
        yield return new object[] { null, Constants.Some_Day };
        yield return new object[] { Constants.Some_Day, null };
        yield return new object[] { null, null };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}