using FluentAssertions;
using TradingSimulator.Test.Domain.OrderBooks.V2.Fixtures;
using Xunit;

namespace TradingSimulator.Test.Domain.OrderBooks.V2;

public class When_constructing_order
{
    private readonly OrderTestBuilder _sutBuilder = new();

    [Fact]
    public void It_gets_constructed_with_all_required_options()
    {
        var actual = _sutBuilder.Build();

        actual.Should().BeEquivalentTo(_sutBuilder, opt => opt.Excluding(a => a.CreatedOn));
    }
}