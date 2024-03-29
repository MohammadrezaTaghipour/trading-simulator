﻿namespace TradingSimulator.Domain.Models.Parties.V4.Parties;

public interface IPartyManager<TSelf, TParty> : IPartyOptions
    where TSelf : IPartyManager<TSelf, TParty>
    where TParty : IPartyOptions
{
    TParty Build();
    TSelf WithName(string value);
}