﻿namespace TradingSimulator.Application.Symbols;

public class DefineSymbolCommand(Guid id, string code)
{
    public Guid Id { get; private set; } = id;
    public string Code { get; private set; } = code;
}