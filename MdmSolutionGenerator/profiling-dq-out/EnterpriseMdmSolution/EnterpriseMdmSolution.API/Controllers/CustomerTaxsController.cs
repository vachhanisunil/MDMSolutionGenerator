using MediatR;
using Microsoft.AspNetCore.Mvc;
using EnterpriseMdmSolution.Application.Modules.CustomerTax.Commands;
using EnterpriseMdmSolution.Application.Modules.CustomerTax.DTOs;
using EnterpriseMdmSolution.Application.Modules.CustomerTax.Queries;

namespace EnterpriseMdmSolution.API.Controllers;

[ApiController]
[Route("api/customertaxs")]
public sealed class CustomerTaxsController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerTaxDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetCustomerTaxByIdQuery(id), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult> Get(CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchCustomerTaxsQuery(new SearchCustomerTaxDto()), cancellationToken));

    [HttpPost("search")]
    public async Task<ActionResult> Search(SearchCustomerTaxDto search, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchCustomerTaxsQuery(search), cancellationToken));

    [HttpPost]
    public async Task<ActionResult<CustomerTaxDto>> Create(CreateCustomerTaxDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new CreateCustomerTaxCommand(input), cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<CustomerTaxDto>> Update(int id, UpdateCustomerTaxDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new UpdateCustomerTaxCommand(id, input), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var deleted = await mediator.Send(new DeleteCustomerTaxCommand(id), cancellationToken);
        return deleted ? NoContent() : NotFound();
    }
}