using System.Collections;

namespace TradingSimulator.Test.Domain.Contracts.V2.TestData;

public class TwoPeriodsWithOverlapExamples : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        //  Patterns:
        //  [ (..] )
        // <[ (..] )
        //  [ (..] )>
        // <[ (..] )>

        //  [ (..]>...)     means (0,null)[1,3]
        //  [...<(..] )     

        yield return new object[] { 0, Constants.Some_Day + 1, Constants.Some_Day, Constants.Some_Day + 2 };
        yield return new object[] { null, Constants.Some_Day + 1, Constants.Some_Day, Constants.Some_Day + 2 };
        yield return new object[] { 0, Constants.Some_Day + 1, Constants.Some_Day, null };
        yield return new object[] { null, Constants.Some_Day + 1, Constants.Some_Day, null };

        yield return new object[] { 0, null, Constants.Some_Day, Constants.Some_Day + 2 };
        yield return new object[] { 0, Constants.Some_Day + 1, null, Constants.Some_Day + 2 };
        yield return new object[] { null, null, Constants.Some_Day, Constants.Some_Day + 1 };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}