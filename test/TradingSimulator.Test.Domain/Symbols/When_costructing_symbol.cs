using FluentAssertions;
using Xunit;

namespace TradingSimulator.Test.Domain.Symbols;

public class When_costructing_symbol
{
    private readonly SymbolTestBuilder _sutBuilder= new();
    
    [Fact]
    public void It_gets_constructed_with_valid_options()
    {
        var actual = _sutBuilder.Build();
        actual.Should().BeEquivalentTo(_sutBuilder);
    }
}