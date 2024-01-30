using System.Collections;

namespace TradingSimulator.Test.Domain.Contracts.Fixtures.TestData;

public class PeriodWithOverlap : IEnumerable<object[]>
{
    private const int SomeDay = 1;

    public IEnumerator<object[]> GetEnumerator()
    {
        // first period     ( )
        // second period    [ ]

        yield return new object[] { 0, SomeDay, SomeDay - 1, SomeDay + 1 };  //    [    (---]   )
        yield return new object[] { null, SomeDay, SomeDay-1, SomeDay + 1 }; //   <[    (---]   )
        yield return new object[] { null, SomeDay, SomeDay-1, null };        //   <[    (---]   )>
        yield return new object[] { 0, SomeDay, SomeDay -1, null };          //    [    (---]   )>
        yield return new object[] { 0, SomeDay, SomeDay, SomeDay + 1 };      //    [       (]    )
        yield return new object[] { null, SomeDay, SomeDay, SomeDay + 1 };   //   <[       (]    )
        yield return new object[] { null, SomeDay, SomeDay, null };          //   <[       (]    )>
        yield return new object[] { 0, SomeDay, SomeDay, null };             //    [       (]    )>
        // Reverse of the previous
        yield return new object[] { SomeDay + 1, SomeDay + 2, 0, SomeDay };  //    (      )  [      ]
        yield return new object[] { SomeDay, SomeDay + 1, null, 0 };         //    (      ) <[      ]
        yield return new object[] { SomeDay, null, null, 0 };                //    (      )><[      ]
        yield return new object[] { SomeDay + 1, null, 0, SomeDay };         //    (      )> [      ]
        yield return new object[] { SomeDay, SomeDay + 1, 0, SomeDay };      //    (       [)       ]
        yield return new object[] { SomeDay, SomeDay + 1, null, SomeDay };   //   <(       [)       ]
        yield return new object[] { SomeDay, null, null, SomeDay };          //   <(       [)       ]>
        yield return new object[] { SomeDay, null, 0, SomeDay };             //    (       [)       ]>
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}