using FluentAssertions;
using TradingSimulator.Domain.Models.OrderBooks.V2;
using TradingSimulator.Domain.Models.OrderBooks.V2.Exceptions;
using TradingSimulator.Test.Domain.OrderBooks.V2.Fixtures;
using Xunit;

namespace TradingSimulator.Test.Domain.OrderBooks.V2;

public class When_constructing_orderBook
{
    private readonly OrderBookTestBuilder _sutBuilder = new();

    [Fact]
    public void It_gets_defined_without_optional_references()
    {
        var actual = _sutBuilder.Build();

        actual.Should().BeEquivalentTo<IOrderBookOptions>(_sutBuilder);
    }

    [Fact]
    public void Throws_exception_constructing_with_NullOrEmpty_Title()
    {
        // Arrange
        _sutBuilder.WithTitle(string.Empty); 

        // Act
        var act = () => _sutBuilder.Build();

        // Assert
        act.Should().Throw<OrderBookTitleIsRequired>();
    }

    [Fact]
    public void Throws_exception_constructing_with_NullOrEmpty_SymbolId()
    {
        // Arrange
        _sutBuilder.WithSymbolId(Guid.Empty); 

        // Act
        var act = () => _sutBuilder.Build();

        // Assert
        act.Should().Throw<OrderBookSymbolIdIsRequired>();
    }
}