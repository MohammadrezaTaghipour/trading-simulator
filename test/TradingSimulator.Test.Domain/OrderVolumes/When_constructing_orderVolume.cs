using FluentAssertions;
using Xunit;

namespace TradingSimulator.Test.Domain.OrderVolumes;

public class When_constructing_orderVolume
{
    private readonly OrderVolumeTestBuilder _sutTestBuilder = new();

    [Fact]
    public void It_gets_constructed_with_required_references()
    {
        var sut = _sutTestBuilder.Build();

        sut.Should().BeEquivalentTo(_sutTestBuilder);
    }
}