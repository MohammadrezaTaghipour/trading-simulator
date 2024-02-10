namespace TradingSimulator.Domain.Models.Parties.V2;

public  abstract class Party : IPartyOptions
{
    protected Party(IPartyOptions options)
    {
        GuardAgainstNullOrEmptyName(options.Name);
        
        GuardAgainstInvalidNameLength(options.Name);
        
        Name = options.Name;
    }

    private static void GuardAgainstInvalidNameLength(string name)
    {
        if (name.Length > 10)   
            throw new ArgumentOutOfRangeException();
    }

    private static void GuardAgainstNullOrEmptyName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new NullReferenceException();
    }

    public string Name { get; private set; }

    public  void Update(IPartyOptions options)
    {
        GuardAgainstNullOrEmptyName(options.Name);
        GuardAgainstInvalidNameLength(options.Name);
        Name = options.Name;
    }
    
    
}