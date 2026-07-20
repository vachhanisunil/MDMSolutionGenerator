using MediatR;
using Microsoft.AspNetCore.Mvc;
using EnterpriseMdmSolution.Application.Modules.MaterialBarcode.Commands;
using EnterpriseMdmSolution.Application.Modules.MaterialBarcode.DTOs;
using EnterpriseMdmSolution.Application.Modules.MaterialBarcode.Queries;

namespace EnterpriseMdmSolution.API.Controllers;

[ApiController]
[Route("api/materialbarcodes")]
public sealed class MaterialBarcodesController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<MaterialBarcodeDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetMaterialBarcodeByIdQuery(id), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult> Get(CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchMaterialBarcodesQuery(new SearchMaterialBarcodeDto()), cancellationToken));

    [HttpPost("search")]
    public async Task<ActionResult> Search(SearchMaterialBarcodeDto search, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchMaterialBarcodesQuery(search), cancellationToken));

    [HttpPost]
    public async Task<ActionResult<MaterialBarcodeDto>> Create(CreateMaterialBarcodeDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new CreateMaterialBarcodeCommand(input), cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<MaterialBarcodeDto>> Update(int id, UpdateMaterialBarcodeDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new UpdateMaterialBarcodeCommand(id, input), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var deleted = await mediator.Send(new DeleteMaterialBarcodeCommand(id), cancellationToken);
        return deleted ? NoContent() : NotFound();
    }

}