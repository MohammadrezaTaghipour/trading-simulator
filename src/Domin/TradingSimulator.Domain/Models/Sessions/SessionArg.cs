namespace TradingSimulator.Domain.Models.Sessions;

public class SessionArg
{
    public SessionId Id { get; set; }
    public string Code { get; set; }
    public DateTime OpeningDate { get; set; }
    public DateTime ClosingDate { get; set; }
}