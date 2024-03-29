﻿using System.Collections;

namespace TradingSimulator.Test.Domain.Contracts.V2.TestData;

public class ThreePeriodsWithOverlapExamples : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        //  [  (..] )  { }
        //  []    ( {..) }
        // <[  ( ] )  { }
        // <[]    ( { ) }
        // <[  (  ] ) { }>
        // <[]    ( { ) }>
        //  [  (  ] ) { }>
        //  []    ( { ) }>

        yield return new object[]
        {
            0, Constants.Some_Day + 1,
            Constants.Some_Day, Constants.Some_Day + 3,
            Constants.Some_Day + 4, Constants.Some_Day + 5
        };


        // yield return new object[]
        // {
        //     0, Constants.Some_Day,
        //     Constants.Some_Day + 1, Constants.Some_Day + 2,
        //     Constants.Some_Day + 2, Constants.Some_Day + 4
        // };
        // yield return new object[]
        // {
        //     null, Constants.Some_Day,
        //     Constants.Some_Day, Constants.Some_Day + 2,
        //     Constants.Some_Day + 3, Constants.Some_Day + 4
        // };
        // yield return new object[]
        // {
        //     null, Constants.Some_Day,
        //     Constants.Some_Day + 1, Constants.Some_Day + 2,
        //     Constants.Some_Day + 2, Constants.Some_Day + 4
        // };
        // yield return new object[]
        // {
        //     null, Constants.Some_Day,
        //     Constants.Some_Day, Constants.Some_Day + 2,
        //     Constants.Some_Day + 3, null
        // };
        // yield return new object[]
        // {
        //     null, Constants.Some_Day,
        //     Constants.Some_Day + 1, Constants.Some_Day + 2,
        //     Constants.Some_Day + 2, null
        // };
        // yield return new object[]
        // {
        //     0, Constants.Some_Day,
        //     Constants.Some_Day, Constants.Some_Day + 2,
        //     Constants.Some_Day + 3, null
        // };
        // yield return new object[]
        // {
        //     0, Constants.Some_Day,
        //     Constants.Some_Day + 1, Constants.Some_Day + 2,
        //     Constants.Some_Day + 2, null
        // };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}