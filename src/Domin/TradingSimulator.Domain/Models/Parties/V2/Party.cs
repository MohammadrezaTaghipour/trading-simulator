namespace TradingSimulator.Domain.Models.Parties.V2;

public  abstract class Party : IPartyOptions
{
    protected Party(IPartyOptions options)
    {
        if (string.IsNullOrWhiteSpace(options.Name))
            throw new NullReferenceException();
        
        if (options.Name.Length > 10)
            throw new ArgumentOutOfRangeException();
        
        Name = options.Name;
    }

    public string Name { get; }
}