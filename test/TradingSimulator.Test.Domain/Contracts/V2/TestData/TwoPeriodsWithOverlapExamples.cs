using System.Collections;

namespace TradingSimulator.Test.Domain.Contracts.V2.TestData;

public class TwoPeriodsWithOverlapExamples : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        //-------------Patterns-----------------

        //  [ (..] )                  means [0,2](1,3)
        yield return new object[] { 0, Constants.Some_Day + 1, Constants.Some_Day, Constants.Some_Day + 2 };

        //  [    (..]    )>           means [0,2](1,null)
        //  [    (..]>...)            means [0,null](1,3)
        //  [...<(..]    )            means [0,2](null,3)
        // <[    (..]   )             means [null,2](1,3)
        yield return new object[] { 0, Constants.Some_Day + 1, Constants.Some_Day, null };
        yield return new object[] { 0, null, Constants.Some_Day, Constants.Some_Day + 2 };
        yield return new object[] { 0, Constants.Some_Day + 1, null, Constants.Some_Day + 2 };
        yield return new object[] { null, Constants.Some_Day + 1, Constants.Some_Day, Constants.Some_Day + 2 };


        //  [    (..]>...)>            means [0,null](1,null)
        //  [...<(..]    )>            means [0,1](null,null)
        // <[    (..]    )>            means [null,1](0,null)
        // <[...<(..]    )             means [null,2](null,3)
        // <[    (..]>...)             means [null,null](0,1)
        //  [...<(..]>...)             means [0,null](null,1)
        yield return new object[] { 0, null, Constants.Some_Day, Constants.Some_Day + 2 };
        yield return new object[] { 0, Constants.Some_Day, null, null };
        yield return new object[] { null, Constants.Some_Day, 0, null };
        yield return new object[] { null, Constants.Some_Day + 1, null, Constants.Some_Day + 2 };
        yield return new object[] { null, null, Constants.Some_Day, Constants.Some_Day + 2 };
        yield return new object[] { 0, null, null, Constants.Some_Day + 2 };

        //  [...<(..]>...)>            means [0,null](null,null)
        // <[    (..]>...)>            means [null,null](0,null)
        // <[...<(..]    )>            means [null,0](null,null)
        // <[...<(..]>...)             means [null,null](null,0)
        yield return new object[] { Constants.Some_Day, null, null, null };
        yield return new object[] { null, null, Constants.Some_Day, null };
        yield return new object[] { null, Constants.Some_Day, null, null };
        yield return new object[] { null, null, null, Constants.Some_Day };

        // <[...<(..]>...)>           means [null,null](null,null)
        yield return new object[] { null, null, null, null };


        //-------------Reverted Patterns-----------------

        //  ( [..) ]                  means (1,3)[0,2]
        yield return new object[] { Constants.Some_Day, Constants.Some_Day + 2, 0, Constants.Some_Day + 1 };

        //  (    [  )>   ]           means (1,null)[0,2]
        //  (    [  )    ]>          means (1,3)[0,null]
        // <(    [  )    ]           means (null,3)[0,2]
        //  (   <[  ]    )           means (1,3)[null,2]
        yield return new object[] { Constants.Some_Day, null, 0, Constants.Some_Day + 1 };
        yield return new object[] { Constants.Some_Day, Constants.Some_Day + 2, 0, null };
        yield return new object[] { null, Constants.Some_Day + 2, 0, Constants.Some_Day + 1 };
        yield return new object[] { Constants.Some_Day, Constants.Some_Day + 2, null, Constants.Some_Day + 1 };

        //  (    [  )>   ]>           means (1,null)[0,null]
        // <(    [  )>   ]            means (null,null)[0,1]
        //  (   <[  )>   ]            means (0,null)[null,1]
        // <(   <[  )    ]            means (null,3)[null,2]
        //  (   <[  )    ]>           means (0,1)[null,null]
        // <(   <[  )    ]>           means (null,1)[0,null]
        yield return new object[] { Constants.Some_Day, Constants.Some_Day + 2, 0, null };
        yield return new object[] { null, null, 0, Constants.Some_Day };
        yield return new object[] { 0, null, null, Constants.Some_Day };
        yield return new object[] { null, Constants.Some_Day + 2, null, Constants.Some_Day + 1 };
        yield return new object[] { Constants.Some_Day, Constants.Some_Day + 2, null, null };
        yield return new object[] { null, Constants.Some_Day + 2, 0, null };

        // <(    [  )>   ]>            means (null,null)[0,null]
        //  (   <[  )>   ]>            means (0,null)[null,null]
        // <(   <[  )>   ]             means (null,null)[null,0]
        // <(   <[  )    ]>            means (null,0)[null,null]
        yield return new object[] { null, null, Constants.Some_Day, null };
        yield return new object[] { Constants.Some_Day, null, null, null };
        yield return new object[] { null, null, null, Constants.Some_Day };
        yield return new object[] { null, Constants.Some_Day, null, null };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}