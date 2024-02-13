﻿using TradingSimulator.Domain.Models.Parties.V4;

namespace TradingSimulator.Test.Domain.Parties.V4.Parties;

public class PartyTestManager : IPartyOptions
{
    protected readonly IPartyManager<TempPartyManager, TestParty> Manager;
    
    
    public PartyTestManager()
    {
        Manager = new TempPartyManager();
        Manager.WithName("sample");
    }
    
    public Party Build()
    {
        return Manager.Build();
    }

    public string Name => Manager.Name;

    public PartyTestManager WithName(string name)
    {
        Manager.WithName(name);
        return this;
    }
}

public class TempPartyManager : PartyManager<TempPartyManager, TestParty>
{
    
}