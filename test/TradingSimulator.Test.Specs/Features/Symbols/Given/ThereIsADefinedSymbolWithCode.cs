﻿using TradingSimulator.Infrastructure.Application;
using TechTalk.SpecFlow;
using TradingSimulator.Test.Specs.ScreenPlay.Symbols.Commands.Symbols;

namespace TradingSimulator.Test.Specs.Features.Symbols.Given;

[Binding]
public class ThereIsADefinedSymbolWithCode
{
    private readonly ICommandBus _commandBus;
    private readonly ScenarioContext _context;

    public ThereIsADefinedSymbolWithCode(ICommandBus commandBus, ScenarioContext context)
    {
        _commandBus = commandBus;
        _context = context;
    }
    
    [Given("There is a defined symbol with code '(.*)'")]
    public void Func(string code, DefineSymbolCommand command)
    {
        _commandBus.Send(command);
        _context.Set(command, code);
    }
}