using MediatR;
using Microsoft.AspNetCore.Mvc;
using EnterpriseMdmSolution.Application.Modules.Currency.Commands;
using EnterpriseMdmSolution.Application.Modules.Currency.DTOs;
using EnterpriseMdmSolution.Application.Modules.Currency.Queries;

namespace EnterpriseMdmSolution.API.Controllers;

[ApiController]
[Route("api/currencies")]
public sealed class CurrenciesController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<CurrencyDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetCurrencyByIdQuery(id), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult> Get(CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchCurrenciesQuery(new SearchCurrencyDto()), cancellationToken));

    [HttpPost("search")]
    public async Task<ActionResult> Search(SearchCurrencyDto search, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchCurrenciesQuery(search), cancellationToken));

    [HttpPost]
    public async Task<ActionResult<CurrencyDto>> Create(CreateCurrencyDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new CreateCurrencyCommand(input), cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<CurrencyDto>> Update(int id, UpdateCurrencyDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new UpdateCurrencyCommand(id, input), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var deleted = await mediator.Send(new DeleteCurrencyCommand(id), cancellationToken);
        return deleted ? NoContent() : NotFound();
    }

    [HttpPost("bulk-create")]
    public async Task<ActionResult<BulkCurrencyOperationResultDto>> BulkCreate(BulkCreateCurrencyDto input, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new BulkCreateCurrencyCommand(input), cancellationToken));

    [HttpPut("bulk-update")]
    public async Task<ActionResult<BulkCurrencyOperationResultDto>> BulkUpdate(BulkUpdateCurrencyDto input, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new BulkUpdateCurrencyCommand(input), cancellationToken));

    [HttpPost("bulk-upsert")]
    public async Task<ActionResult<BulkCurrencyOperationResultDto>> BulkUpsert(BulkUpsertCurrencyDto input, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new BulkUpsertCurrencyCommand(input), cancellationToken));

    [HttpPost("bulk-delete")]
    public async Task<ActionResult<BulkCurrencyOperationResultDto>> BulkDelete(BulkDeleteCurrencyDto input, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new BulkDeleteCurrencyCommand(input), cancellationToken));
}