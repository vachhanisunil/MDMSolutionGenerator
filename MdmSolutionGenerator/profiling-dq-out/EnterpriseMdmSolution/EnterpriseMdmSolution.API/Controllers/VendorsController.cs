using MediatR;
using Microsoft.AspNetCore.Mvc;
using EnterpriseMdmSolution.Application.Modules.Vendor.Commands;
using EnterpriseMdmSolution.Application.Modules.Vendor.DTOs;
using EnterpriseMdmSolution.Application.Modules.Vendor.Queries;

namespace EnterpriseMdmSolution.API.Controllers;

[ApiController]
[Route("api/vendors")]
public sealed class VendorsController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<VendorDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetVendorByIdQuery(id), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult> Get(CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchVendorsQuery(new SearchVendorDto()), cancellationToken));

    [HttpPost("search")]
    public async Task<ActionResult> Search(SearchVendorDto search, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchVendorsQuery(search), cancellationToken));

    [HttpPost]
    public async Task<ActionResult<VendorDto>> Create(CreateVendorDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new CreateVendorCommand(input), cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<VendorDto>> Update(int id, UpdateVendorDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new UpdateVendorCommand(id, input), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var deleted = await mediator.Send(new DeleteVendorCommand(id), cancellationToken);
        return deleted ? NoContent() : NotFound();
    }

    [HttpPost("bulk-create")]
    public async Task<ActionResult<BulkVendorOperationResultDto>> BulkCreate(BulkCreateVendorDto input, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new BulkCreateVendorCommand(input), cancellationToken));

    [HttpPut("bulk-update")]
    public async Task<ActionResult<BulkVendorOperationResultDto>> BulkUpdate(BulkUpdateVendorDto input, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new BulkUpdateVendorCommand(input), cancellationToken));

    [HttpPost("bulk-upsert")]
    public async Task<ActionResult<BulkVendorOperationResultDto>> BulkUpsert(BulkUpsertVendorDto input, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new BulkUpsertVendorCommand(input), cancellationToken));

    [HttpPost("bulk-delete")]
    public async Task<ActionResult<BulkVendorOperationResultDto>> BulkDelete(BulkDeleteVendorDto input, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new BulkDeleteVendorCommand(input), cancellationToken));
}