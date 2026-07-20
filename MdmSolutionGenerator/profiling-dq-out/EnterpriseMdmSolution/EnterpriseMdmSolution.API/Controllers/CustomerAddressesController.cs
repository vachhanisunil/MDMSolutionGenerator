using MediatR;
using Microsoft.AspNetCore.Mvc;
using EnterpriseMdmSolution.Application.Modules.CustomerAddress.Commands;
using EnterpriseMdmSolution.Application.Modules.CustomerAddress.DTOs;
using EnterpriseMdmSolution.Application.Modules.CustomerAddress.Queries;

namespace EnterpriseMdmSolution.API.Controllers;

[ApiController]
[Route("api/customeraddresses")]
public sealed class CustomerAddressesController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerAddressDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetCustomerAddressByIdQuery(id), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult> Get(CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchCustomerAddressesQuery(new SearchCustomerAddressDto()), cancellationToken));

    [HttpPost("search")]
    public async Task<ActionResult> Search(SearchCustomerAddressDto search, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchCustomerAddressesQuery(search), cancellationToken));

    [HttpPost]
    public async Task<ActionResult<CustomerAddressDto>> Create(CreateCustomerAddressDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new CreateCustomerAddressCommand(input), cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<CustomerAddressDto>> Update(int id, UpdateCustomerAddressDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new UpdateCustomerAddressCommand(id, input), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var deleted = await mediator.Send(new DeleteCustomerAddressCommand(id), cancellationToken);
        return deleted ? NoContent() : NotFound();
    }

}