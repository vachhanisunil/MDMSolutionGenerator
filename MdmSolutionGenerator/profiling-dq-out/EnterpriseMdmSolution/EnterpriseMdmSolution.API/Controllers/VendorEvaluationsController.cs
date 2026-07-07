using MediatR;
using Microsoft.AspNetCore.Mvc;
using EnterpriseMdmSolution.Application.Modules.VendorEvaluation.Commands;
using EnterpriseMdmSolution.Application.Modules.VendorEvaluation.DTOs;
using EnterpriseMdmSolution.Application.Modules.VendorEvaluation.Queries;

namespace EnterpriseMdmSolution.API.Controllers;

[ApiController]
[Route("api/vendorevaluations")]
public sealed class VendorEvaluationsController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<VendorEvaluationDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetVendorEvaluationByIdQuery(id), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult> Get(CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchVendorEvaluationsQuery(new SearchVendorEvaluationDto()), cancellationToken));

    [HttpPost("search")]
    public async Task<ActionResult> Search(SearchVendorEvaluationDto search, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchVendorEvaluationsQuery(search), cancellationToken));

    [HttpPost]
    public async Task<ActionResult<VendorEvaluationDto>> Create(CreateVendorEvaluationDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new CreateVendorEvaluationCommand(input), cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<VendorEvaluationDto>> Update(int id, UpdateVendorEvaluationDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new UpdateVendorEvaluationCommand(id, input), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var deleted = await mediator.Send(new DeleteVendorEvaluationCommand(id), cancellationToken);
        return deleted ? NoContent() : NotFound();
    }
}