namespace TradingSimulator.Application.Sessions;

public class DefineSessionCommand
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public DateTime OpeningDate { get; set; }
    public DateTime ClosingDate { get; set; }
}