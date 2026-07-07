using MediatR;
using Microsoft.AspNetCore.Mvc;
using EnterpriseMdmSolution.Application.Modules.CustomerSalesArea.Commands;
using EnterpriseMdmSolution.Application.Modules.CustomerSalesArea.DTOs;
using EnterpriseMdmSolution.Application.Modules.CustomerSalesArea.Queries;

namespace EnterpriseMdmSolution.API.Controllers;

[ApiController]
[Route("api/customersalesareas")]
public sealed class CustomerSalesAreasController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerSalesAreaDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetCustomerSalesAreaByIdQuery(id), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult> Get(CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchCustomerSalesAreasQuery(new SearchCustomerSalesAreaDto()), cancellationToken));

    [HttpPost("search")]
    public async Task<ActionResult> Search(SearchCustomerSalesAreaDto search, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchCustomerSalesAreasQuery(search), cancellationToken));

    [HttpPost]
    public async Task<ActionResult<CustomerSalesAreaDto>> Create(CreateCustomerSalesAreaDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new CreateCustomerSalesAreaCommand(input), cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<CustomerSalesAreaDto>> Update(int id, UpdateCustomerSalesAreaDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new UpdateCustomerSalesAreaCommand(id, input), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var deleted = await mediator.Send(new DeleteCustomerSalesAreaCommand(id), cancellationToken);
        return deleted ? NoContent() : NotFound();
    }
}