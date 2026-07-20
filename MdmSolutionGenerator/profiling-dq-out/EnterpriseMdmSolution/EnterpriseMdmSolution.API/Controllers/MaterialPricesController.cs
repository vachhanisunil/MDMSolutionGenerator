using MediatR;
using Microsoft.AspNetCore.Mvc;
using EnterpriseMdmSolution.Application.Modules.MaterialPrice.Commands;
using EnterpriseMdmSolution.Application.Modules.MaterialPrice.DTOs;
using EnterpriseMdmSolution.Application.Modules.MaterialPrice.Queries;

namespace EnterpriseMdmSolution.API.Controllers;

[ApiController]
[Route("api/materialprices")]
public sealed class MaterialPricesController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<MaterialPriceDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetMaterialPriceByIdQuery(id), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult> Get(CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchMaterialPricesQuery(new SearchMaterialPriceDto()), cancellationToken));

    [HttpPost("search")]
    public async Task<ActionResult> Search(SearchMaterialPriceDto search, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchMaterialPricesQuery(search), cancellationToken));

    [HttpPost]
    public async Task<ActionResult<MaterialPriceDto>> Create(CreateMaterialPriceDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new CreateMaterialPriceCommand(input), cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<MaterialPriceDto>> Update(int id, UpdateMaterialPriceDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new UpdateMaterialPriceCommand(id, input), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var deleted = await mediator.Send(new DeleteMaterialPriceCommand(id), cancellationToken);
        return deleted ? NoContent() : NotFound();
    }

}