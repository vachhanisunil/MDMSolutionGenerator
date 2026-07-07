using MediatR;
using Microsoft.AspNetCore.Mvc;
using EnterpriseMdmSolution.Application.Modules.CustomerCreditProfile.Commands;
using EnterpriseMdmSolution.Application.Modules.CustomerCreditProfile.DTOs;
using EnterpriseMdmSolution.Application.Modules.CustomerCreditProfile.Queries;

namespace EnterpriseMdmSolution.API.Controllers;

[ApiController]
[Route("api/customercreditprofiles")]
public sealed class CustomerCreditProfilesController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerCreditProfileDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetCustomerCreditProfileByIdQuery(id), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult> Get(CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchCustomerCreditProfilesQuery(new SearchCustomerCreditProfileDto()), cancellationToken));

    [HttpPost("search")]
    public async Task<ActionResult> Search(SearchCustomerCreditProfileDto search, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchCustomerCreditProfilesQuery(search), cancellationToken));

    [HttpPost]
    public async Task<ActionResult<CustomerCreditProfileDto>> Create(CreateCustomerCreditProfileDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new CreateCustomerCreditProfileCommand(input), cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<CustomerCreditProfileDto>> Update(int id, UpdateCustomerCreditProfileDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new UpdateCustomerCreditProfileCommand(id, input), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var deleted = await mediator.Send(new DeleteCustomerCreditProfileCommand(id), cancellationToken);
        return deleted ? NoContent() : NotFound();
    }
}