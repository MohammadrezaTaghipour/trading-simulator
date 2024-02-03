using System.Collections;

namespace TradingSimulator.Test.Domain.Contracts.V2.TestData;

public class TwoPeriodsWithoutOverlapExamples : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        //  Patterns:
        //  [] ()
        // <[] ()
        // <[] ()>
        //  [] ()>

        // ()  []
        // () <[]
        // ()><[]
        // ()> []

        //  [  (] ]
        // <[  (] )
        // <[  (] )>
        //  [  (] )>

        //  (  [)  ]
        //  ( <[)  ]>
        //  ( <[)> ]
        //  (  [)> ]

        yield return new object[] { 0, Constants.Some_Day, Constants.Some_Day + 1, Constants.Some_Day + 2 };
        yield return new object[] { null, 0, Constants.Some_Day, Constants.Some_Day + 1 };
        yield return new object[] { null, 0, Constants.Some_Day + 1, null };
        yield return new object[] { 0, Constants.Some_Day, Constants.Some_Day + 1, null };

        yield return new object[] { Constants.Some_Day + 1, Constants.Some_Day + 2, 0, Constants.Some_Day };
        yield return new object[] { Constants.Some_Day, Constants.Some_Day + 1, null, 0, };
        yield return new object[] { Constants.Some_Day + 1, null, null, 0 };
        yield return new object[] { Constants.Some_Day + 1, null, 0, Constants.Some_Day };

        yield return new object[] { 0, Constants.Some_Day, Constants.Some_Day, Constants.Some_Day + 1 };
        yield return new object[] { null, Constants.Some_Day, Constants.Some_Day, Constants.Some_Day + 1 };
        yield return new object[] { null, Constants.Some_Day, Constants.Some_Day, null };
        yield return new object[] { 0, Constants.Some_Day, Constants.Some_Day, null };

        yield return new object[] { 0, Constants.Some_Day, Constants.Some_Day + 1, Constants.Some_Day + 2 };
        yield return new object[] { null, 0, Constants.Some_Day, Constants.Some_Day + 1 };
        yield return new object[] { null, 0, Constants.Some_Day + 1, null };
        yield return
            new object[]
            {
                Constants.Some_Day, null, 0, Constants.Some_Day
            }; //{ 0, Constants.Some_Day, Constants.Some_Day, null }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}