using FluentAssertions;
using TradingSimulator.Domain.Models.OrderBooks.V2.Entities;
using TradingSimulator.Test.Domain.OrderBooks.V2.Fixtures;
using Xunit;

namespace TradingSimulator.Test.Domain.OrderBooks.V2;

public class When_constructing_order
{
  [Fact]
  public void It_gets_constructed_with_all_required_options()
  {
      var options = new OrderOptionsTestBuilder().Build();

      var sut = new Order(options);

      sut.Should().BeEquivalentTo(options);
  }
}