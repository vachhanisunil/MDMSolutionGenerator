using MediatR;
using Microsoft.AspNetCore.Mvc;
using EnterpriseMdmSolution.Application.Modules.CustomerBankAccount.Commands;
using EnterpriseMdmSolution.Application.Modules.CustomerBankAccount.DTOs;
using EnterpriseMdmSolution.Application.Modules.CustomerBankAccount.Queries;

namespace EnterpriseMdmSolution.API.Controllers;

[ApiController]
[Route("api/customerbankaccounts")]
public sealed class CustomerBankAccountsController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerBankAccountDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetCustomerBankAccountByIdQuery(id), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult> Get(CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchCustomerBankAccountsQuery(new SearchCustomerBankAccountDto()), cancellationToken));

    [HttpPost("search")]
    public async Task<ActionResult> Search(SearchCustomerBankAccountDto search, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchCustomerBankAccountsQuery(search), cancellationToken));

    [HttpPost]
    public async Task<ActionResult<CustomerBankAccountDto>> Create(CreateCustomerBankAccountDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new CreateCustomerBankAccountCommand(input), cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<CustomerBankAccountDto>> Update(int id, UpdateCustomerBankAccountDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new UpdateCustomerBankAccountCommand(id, input), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var deleted = await mediator.Send(new DeleteCustomerBankAccountCommand(id), cancellationToken);
        return deleted ? NoContent() : NotFound();
    }

}