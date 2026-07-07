using MediatR;
using Microsoft.AspNetCore.Mvc;
using EnterpriseMdmSolution.Application.Modules.CustomerContact.Commands;
using EnterpriseMdmSolution.Application.Modules.CustomerContact.DTOs;
using EnterpriseMdmSolution.Application.Modules.CustomerContact.Queries;

namespace EnterpriseMdmSolution.API.Controllers;

[ApiController]
[Route("api/customercontacts")]
public sealed class CustomerContactsController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerContactDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetCustomerContactByIdQuery(id), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult> Get(CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchCustomerContactsQuery(new SearchCustomerContactDto()), cancellationToken));

    [HttpPost("search")]
    public async Task<ActionResult> Search(SearchCustomerContactDto search, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchCustomerContactsQuery(search), cancellationToken));

    [HttpPost]
    public async Task<ActionResult<CustomerContactDto>> Create(CreateCustomerContactDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new CreateCustomerContactCommand(input), cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<CustomerContactDto>> Update(int id, UpdateCustomerContactDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new UpdateCustomerContactCommand(id, input), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var deleted = await mediator.Send(new DeleteCustomerContactCommand(id), cancellationToken);
        return deleted ? NoContent() : NotFound();
    }
}