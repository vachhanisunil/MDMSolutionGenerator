using MediatR;
using Microsoft.AspNetCore.Mvc;
using EnterpriseMdmSolution.Application.Modules.PaymentTerm.Commands;
using EnterpriseMdmSolution.Application.Modules.PaymentTerm.DTOs;
using EnterpriseMdmSolution.Application.Modules.PaymentTerm.Queries;

namespace EnterpriseMdmSolution.API.Controllers;

[ApiController]
[Route("api/paymentterms")]
public sealed class PaymentTermsController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<PaymentTermDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetPaymentTermByIdQuery(id), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult> Get(CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchPaymentTermsQuery(new SearchPaymentTermDto()), cancellationToken));

    [HttpPost("search")]
    public async Task<ActionResult> Search(SearchPaymentTermDto search, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchPaymentTermsQuery(search), cancellationToken));

    [HttpPost]
    public async Task<ActionResult<PaymentTermDto>> Create(CreatePaymentTermDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new CreatePaymentTermCommand(input), cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<PaymentTermDto>> Update(int id, UpdatePaymentTermDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new UpdatePaymentTermCommand(id, input), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var deleted = await mediator.Send(new DeletePaymentTermCommand(id), cancellationToken);
        return deleted ? NoContent() : NotFound();
    }

    [HttpPost("bulk-create")]
    public async Task<ActionResult<BulkPaymentTermOperationResultDto>> BulkCreate(BulkCreatePaymentTermDto input, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new BulkCreatePaymentTermCommand(input), cancellationToken));

    [HttpPut("bulk-update")]
    public async Task<ActionResult<BulkPaymentTermOperationResultDto>> BulkUpdate(BulkUpdatePaymentTermDto input, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new BulkUpdatePaymentTermCommand(input), cancellationToken));

    [HttpPost("bulk-upsert")]
    public async Task<ActionResult<BulkPaymentTermOperationResultDto>> BulkUpsert(BulkUpsertPaymentTermDto input, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new BulkUpsertPaymentTermCommand(input), cancellationToken));

    [HttpPost("bulk-delete")]
    public async Task<ActionResult<BulkPaymentTermOperationResultDto>> BulkDelete(BulkDeletePaymentTermDto input, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new BulkDeletePaymentTermCommand(input), cancellationToken));
}