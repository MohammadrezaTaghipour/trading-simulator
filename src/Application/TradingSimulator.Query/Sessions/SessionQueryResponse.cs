namespace TradingSimulator.Query.Sessions;

public class SessionQueryResponse
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public DateTime OpeningDate { get; set; }
    public DateTime ClosingDate { get; set; }
}