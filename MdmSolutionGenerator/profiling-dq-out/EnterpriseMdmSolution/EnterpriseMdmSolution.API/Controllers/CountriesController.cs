using MediatR;
using Microsoft.AspNetCore.Mvc;
using EnterpriseMdmSolution.Application.Modules.Country.Commands;
using EnterpriseMdmSolution.Application.Modules.Country.DTOs;
using EnterpriseMdmSolution.Application.Modules.Country.Queries;

namespace EnterpriseMdmSolution.API.Controllers;

[ApiController]
[Route("api/countries")]
public sealed class CountriesController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<CountryDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetCountryByIdQuery(id), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult> Get(CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchCountriesQuery(new SearchCountryDto()), cancellationToken));

    [HttpPost("search")]
    public async Task<ActionResult> Search(SearchCountryDto search, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchCountriesQuery(search), cancellationToken));

    [HttpPost]
    public async Task<ActionResult<CountryDto>> Create(CreateCountryDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new CreateCountryCommand(input), cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<CountryDto>> Update(int id, UpdateCountryDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new UpdateCountryCommand(id, input), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var deleted = await mediator.Send(new DeleteCountryCommand(id), cancellationToken);
        return deleted ? NoContent() : NotFound();
    }

    [HttpPost("bulk-create")]
    public async Task<ActionResult<BulkCountryOperationResultDto>> BulkCreate(BulkCreateCountryDto input, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new BulkCreateCountryCommand(input), cancellationToken));

    [HttpPut("bulk-update")]
    public async Task<ActionResult<BulkCountryOperationResultDto>> BulkUpdate(BulkUpdateCountryDto input, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new BulkUpdateCountryCommand(input), cancellationToken));

    [HttpPost("bulk-upsert")]
    public async Task<ActionResult<BulkCountryOperationResultDto>> BulkUpsert(BulkUpsertCountryDto input, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new BulkUpsertCountryCommand(input), cancellationToken));

    [HttpPost("bulk-delete")]
    public async Task<ActionResult<BulkCountryOperationResultDto>> BulkDelete(BulkDeleteCountryDto input, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new BulkDeleteCountryCommand(input), cancellationToken));
}