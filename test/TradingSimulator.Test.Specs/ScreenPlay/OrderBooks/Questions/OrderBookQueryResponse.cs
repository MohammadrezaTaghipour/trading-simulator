namespace TradingSimulator.Test.Specs.ScreenPlay.OrderBooks.Questions;

public class OrderBookQueryResponse
{
    public string Id { get; set; }
    public string Title { get; set; }
    public Guid SessionId { get; set; }
    public Guid SymbolId { get; set; }
}