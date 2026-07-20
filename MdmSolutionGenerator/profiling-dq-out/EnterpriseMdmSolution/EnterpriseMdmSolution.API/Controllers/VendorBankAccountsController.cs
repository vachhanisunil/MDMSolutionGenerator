using MediatR;
using Microsoft.AspNetCore.Mvc;
using EnterpriseMdmSolution.Application.Modules.VendorBankAccount.Commands;
using EnterpriseMdmSolution.Application.Modules.VendorBankAccount.DTOs;
using EnterpriseMdmSolution.Application.Modules.VendorBankAccount.Queries;

namespace EnterpriseMdmSolution.API.Controllers;

[ApiController]
[Route("api/vendorbankaccounts")]
public sealed class VendorBankAccountsController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<VendorBankAccountDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetVendorBankAccountByIdQuery(id), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult> Get(CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchVendorBankAccountsQuery(new SearchVendorBankAccountDto()), cancellationToken));

    [HttpPost("search")]
    public async Task<ActionResult> Search(SearchVendorBankAccountDto search, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchVendorBankAccountsQuery(search), cancellationToken));

    [HttpPost]
    public async Task<ActionResult<VendorBankAccountDto>> Create(CreateVendorBankAccountDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new CreateVendorBankAccountCommand(input), cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<VendorBankAccountDto>> Update(int id, UpdateVendorBankAccountDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new UpdateVendorBankAccountCommand(id, input), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var deleted = await mediator.Send(new DeleteVendorBankAccountCommand(id), cancellationToken);
        return deleted ? NoContent() : NotFound();
    }

}