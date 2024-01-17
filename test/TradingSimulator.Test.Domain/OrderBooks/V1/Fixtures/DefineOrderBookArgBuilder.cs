using FizzWare.NBuilder;
using TradingSimulator.Domain.Models.OrderBooks.V1.Args;

namespace TradingSimulator.Test.Domain.OrderBooks.V1.Fixtures;

public class DefineOrderBookArgBuilder : PlaceOrderArg
{
    public static ISingleObjectBuilder<DefineOrderBookArg> Builder
        => new Builder().CreateNew<DefineOrderBookArg>();
}