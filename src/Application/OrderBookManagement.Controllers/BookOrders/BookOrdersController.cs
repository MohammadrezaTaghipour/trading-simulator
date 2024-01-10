using Microsoft.AspNetCore.Mvc;
using OrderBookManagement.Domain.Models.OrderBooks.Args;
using OrderBookManagement.Infrastructure.Application;

namespace OrderBookManagement.Controllers.BookOrders;

[ApiController]
[Route("api/[controller]")]
public class BookOrdersController : ControllerBase
{
    private readonly ICommandBus _bus;
    
    public BookOrdersController(ICommandBus bus)
    {
        _bus = bus;
    }
    
    [HttpPatch]
    public async Task<IActionResult> PlaceOrder(PlaceOrderArg command,
        CancellationToken token)
    {
        await _bus.Send(command, token);
        return Accepted();
    }
}