﻿using Microsoft.AspNetCore.Mvc;
using TradingSimulator.Application.Orders;
using TradingSimulator.Infrastructure.Application;

namespace TradingSimulator.Controllers.OrderBooks;

[ApiController]
[Route("api/[controller]")]
public class OrderBooksController : ControllerBase
{
    private readonly ICommandBus _bus;

    public OrderBooksController(ICommandBus bus)
    {
        _bus = bus;
    }

    [HttpPost]
    public async Task<IActionResult> Define(DefineOrderBookCommand command,
        CancellationToken token)
    {
        var result = await _bus.Send<DefineOrderBookCommand, OrderBookCommandResult>(command, token);
        return Created(result.Item.OrderBookId, string.Empty);
    }

    [HttpPatch]
    public async Task<IActionResult> PlaceOrder(PlaceOrderCommand command,
        CancellationToken token)
    {
        await _bus.Send(command, token);
        return Accepted();
    }
}