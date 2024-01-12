using Microsoft.AspNetCore.Mvc;
using TradingSimulator.Application.Traders;
using TradingSimulator.Infrastructure.Application;
using TradingSimulator.Query.Traders;

namespace TradingSimulator.Controllers.Traders;

public class TradersController : ControllerBase
{
    private readonly ICommandBus _bus;
    private readonly ITraderQueryService _queryService;

    public TradersController(ICommandBus bus, ITraderQueryService queryService)
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
    public async Task<IActionResult> Post(DefineTraderCommand command,
        CancellationToken token)
    {
        await _bus.Send(command, token);
        return Accepted();
    }
}