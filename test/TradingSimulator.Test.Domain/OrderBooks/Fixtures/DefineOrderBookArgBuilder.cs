using FizzWare.NBuilder;
using TradingSimulator.Domain.Models.OrderBooks.Args;

namespace TradingSimulator.Test.Domain.OrderBooks.Fixtures;

public class DefineOrderBookArgBuilder : PlaceOrderArg
{
    public static ISingleObjectBuilder<DefineOrderBookArg> Builder
        => new Builder().CreateNew<DefineOrderBookArg>();
}