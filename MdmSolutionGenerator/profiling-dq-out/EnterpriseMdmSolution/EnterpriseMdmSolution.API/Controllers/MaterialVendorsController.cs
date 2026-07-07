using MediatR;
using Microsoft.AspNetCore.Mvc;
using EnterpriseMdmSolution.Application.Modules.MaterialVendor.Commands;
using EnterpriseMdmSolution.Application.Modules.MaterialVendor.DTOs;
using EnterpriseMdmSolution.Application.Modules.MaterialVendor.Queries;

namespace EnterpriseMdmSolution.API.Controllers;

[ApiController]
[Route("api/materialvendors")]
public sealed class MaterialVendorsController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<MaterialVendorDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetMaterialVendorByIdQuery(id), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult> Get(CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchMaterialVendorsQuery(new SearchMaterialVendorDto()), cancellationToken));

    [HttpPost("search")]
    public async Task<ActionResult> Search(SearchMaterialVendorDto search, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchMaterialVendorsQuery(search), cancellationToken));

    [HttpPost]
    public async Task<ActionResult<MaterialVendorDto>> Create(CreateMaterialVendorDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new CreateMaterialVendorCommand(input), cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<MaterialVendorDto>> Update(int id, UpdateMaterialVendorDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new UpdateMaterialVendorCommand(id, input), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var deleted = await mediator.Send(new DeleteMaterialVendorCommand(id), cancellationToken);
        return deleted ? NoContent() : NotFound();
    }
}