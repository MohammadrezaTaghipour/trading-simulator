﻿namespace TradingSimulator.Domain.Models.Parties.V2;

public class IndividualParty : Party, IIndividualPartyOptions
{
    public IndividualParty(IIndividualPartyOptions options) : base(options)
    {
        NationCode = options.NationCode;
    }

    public string NationCode { get; private set; }

    internal void Update(IIndividualPartyOptions options)
    {
        base.Update(options);
        this.NationCode = options.NationCode;
    }
}