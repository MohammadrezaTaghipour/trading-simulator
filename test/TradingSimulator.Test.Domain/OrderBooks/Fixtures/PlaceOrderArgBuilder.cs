using FizzWare.NBuilder;
using TradingSimulator.Domain.Models.OrderBooks.Args;

namespace TradingSimulator.Test.Domain.OrderBooks.Fixtures;

public class PlaceOrderArgBuilder : PlaceOrderArg
{
    public static ISingleObjectBuilder<PlaceOrderArg> Builder
        => new Builder().CreateNew<PlaceOrderArg>();
}