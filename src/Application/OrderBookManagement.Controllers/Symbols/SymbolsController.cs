using Microsoft.AspNetCore.Mvc;
using OrderBookManagement.Application.Symbols;
using OrderBookManagement.Infrastructure.Application;
using OrderBookManagement.Query.Symbols;

namespace OrderBookManagement.Controllers.Symbols;

[ApiController]
[Route("api/[controller]")]
public class SymbolsController : ControllerBase
{
    private readonly ICommandBus _bus;
    private readonly ISymbolQueryService _queryService;

    public SymbolsController(ICommandBus bus, ISymbolQueryService queryService)
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
    public async Task<IActionResult> Post(DefineSymbolCommand command,
        CancellationToken token)
    {
        await _bus.Send(command, token);
        return Accepted();
    }
}