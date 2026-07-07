using MediatR;
using Microsoft.AspNetCore.Mvc;
using EnterpriseMdmSolution.Application.Modules.CustomerPartnerFunction.Commands;
using EnterpriseMdmSolution.Application.Modules.CustomerPartnerFunction.DTOs;
using EnterpriseMdmSolution.Application.Modules.CustomerPartnerFunction.Queries;

namespace EnterpriseMdmSolution.API.Controllers;

[ApiController]
[Route("api/customerpartnerfunctions")]
public sealed class CustomerPartnerFunctionsController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerPartnerFunctionDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetCustomerPartnerFunctionByIdQuery(id), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult> Get(CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchCustomerPartnerFunctionsQuery(new SearchCustomerPartnerFunctionDto()), cancellationToken));

    [HttpPost("search")]
    public async Task<ActionResult> Search(SearchCustomerPartnerFunctionDto search, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchCustomerPartnerFunctionsQuery(search), cancellationToken));

    [HttpPost]
    public async Task<ActionResult<CustomerPartnerFunctionDto>> Create(CreateCustomerPartnerFunctionDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new CreateCustomerPartnerFunctionCommand(input), cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<CustomerPartnerFunctionDto>> Update(int id, UpdateCustomerPartnerFunctionDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new UpdateCustomerPartnerFunctionCommand(id, input), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var deleted = await mediator.Send(new DeleteCustomerPartnerFunctionCommand(id), cancellationToken);
        return deleted ? NoContent() : NotFound();
    }
}