namespace TradingSimulator.Domain.Models.Parties.V4;
public abstract class Party : IPartyOptions
{
    protected Party(IPartyOptions options)
    {
        GuardAgainstNullOrEmptyName(options.Name);
        Name = options.Name;
    }

    public string Name { get; private set; }

    private void GuardAgainstNullOrEmptyName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentNullException();
    }
}