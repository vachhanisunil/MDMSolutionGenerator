using MediatR;
using Microsoft.AspNetCore.Mvc;
using EnterpriseMdmSolution.Application.Modules.MaterialForecast.Commands;
using EnterpriseMdmSolution.Application.Modules.MaterialForecast.DTOs;
using EnterpriseMdmSolution.Application.Modules.MaterialForecast.Queries;

namespace EnterpriseMdmSolution.API.Controllers;

[ApiController]
[Route("api/materialforecasts")]
public sealed class MaterialForecastsController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<MaterialForecastDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetMaterialForecastByIdQuery(id), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult> Get(CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchMaterialForecastsQuery(new SearchMaterialForecastDto()), cancellationToken));

    [HttpPost("search")]
    public async Task<ActionResult> Search(SearchMaterialForecastDto search, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchMaterialForecastsQuery(search), cancellationToken));

    [HttpPost]
    public async Task<ActionResult<MaterialForecastDto>> Create(CreateMaterialForecastDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new CreateMaterialForecastCommand(input), cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<MaterialForecastDto>> Update(int id, UpdateMaterialForecastDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new UpdateMaterialForecastCommand(id, input), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var deleted = await mediator.Send(new DeleteMaterialForecastCommand(id), cancellationToken);
        return deleted ? NoContent() : NotFound();
    }
}