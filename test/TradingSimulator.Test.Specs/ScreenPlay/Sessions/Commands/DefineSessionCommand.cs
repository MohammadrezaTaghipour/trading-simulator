namespace TradingSimulator.Test.Specs.ScreenPlay.Sessions.Commands;

public class DefineSessionCommand
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public DateTime OpeningDate { get; set; }
    public DateTime ClosingDate { get; set; }
}