namespace OrderBookManagement.Test.Specs.ScreenPlay.Symbols.Commands.Symbols;

public class DefineSymbolCommand(Guid id, string code)
{
    public Guid Id { get; private set; } = id;
    public string Code { get; private set; } = code;
}