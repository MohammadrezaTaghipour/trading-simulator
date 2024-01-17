using FizzWare.NBuilder;
using TradingSimulator.Domain.Models.OrderBooks.V1.Args;

namespace TradingSimulator.Test.Domain.OrderBooks.V1.Fixtures;

public class PlaceOrderArgBuilder : PlaceOrderArg
{
    public static ISingleObjectBuilder<PlaceOrderArg> Builder
        => new Builder().CreateNew<PlaceOrderArg>();
}