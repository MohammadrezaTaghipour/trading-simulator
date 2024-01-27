using FluentAssertions;
using Xunit;

namespace TradingSimulator.Test.Domain.OrderVolumes;

public class When_constructing_orderVolume
{
    private readonly OrderVolumeOptionsTestBuilder _sutOptionsTestBuilder = new();

    [Fact]
    public void It_gets_constructed_with_required_references()
    {
        var sut = _sutOptionsTestBuilder.Build();

        sut.Should().BeEquivalentTo(_sutOptionsTestBuilder);
    }
}