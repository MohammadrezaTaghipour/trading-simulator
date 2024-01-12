using Microsoft.AspNetCore.Mvc;
using TradingSimulator.Application.Sessions;
using TradingSimulator.Infrastructure.Application;
using TradingSimulator.Query.Sessions;

namespace TradingSimulator.Controllers.Sessions;

[ApiController]
[Route("api/[controller]")]
public class SessionsController : ControllerBase
{
    private readonly ICommandBus _bus;
    private readonly ISessionQueryService _queryService;

    public SessionsController(ICommandBus bus, ISessionQueryService queryService)
    {
        _bus = bus;
        _queryService = queryService;
    }

    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken token)
    {
        var response = await _queryService.GetAll(token);
        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id, CancellationToken token)
    {
        var response = await _queryService.GetById(id, token);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Post(DefineSessionCommand command,
        CancellationToken token)
    {
        await _bus.Send(command, token);
        return Accepted();
    }
}