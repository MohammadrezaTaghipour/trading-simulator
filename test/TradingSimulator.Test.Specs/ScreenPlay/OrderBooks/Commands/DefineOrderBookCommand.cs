﻿namespace TradingSimulator.Test.Specs.ScreenPlay.OrderBooks.Commands;

public class DefineOrderBookCommand
{
    public string Title { get; set; }
    public Guid SessionId { get; set; }
    public Guid SymbolId { get; set; }
}