using Microsoft.AspNetCore.Mvc;
using OrderBookManagement.Application.Orders;
using OrderBookManagement.Infrastructure.Application;

namespace OrderBookManagement.Controllers.OrderBooks;

[ApiController]
[Route("api/[controller]")]
public class OrderBooksController : ControllerBase
{
    private readonly ICommandBus _bus;
    
    public OrderBooksController(ICommandBus bus)
    {
        _bus = bus;
    }
    
    [HttpPatch]
    public async Task<IActionResult> PlaceOrder(PlaceOrderCommand command,
        CancellationToken token)
    {
        await _bus.Send(command, token);
        return Accepted();
    }
}