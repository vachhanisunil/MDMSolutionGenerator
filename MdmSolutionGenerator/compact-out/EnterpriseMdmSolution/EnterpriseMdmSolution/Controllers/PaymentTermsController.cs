using Microsoft.AspNetCore.Mvc;
using EnterpriseMdmSolution.DTOs;
using EnterpriseMdmSolution.Entities;
using EnterpriseMdmSolution.Services;

namespace EnterpriseMdmSolution.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class PaymentTermsController(GenericCrudService<PaymentTerm, PaymentTermDto, CreatePaymentTermDto, UpdatePaymentTermDto, int> service) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<PaymentTermDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var record = await service.GetByIdAsync(id, cancellationToken);
        return record is null ? NotFound() : Ok(record);
    }

    [HttpPost("search")]
    public async Task<ActionResult<PagedResult<PaymentTermDto>>> Search(SearchPaymentTermDto search, CancellationToken cancellationToken)
        => Ok(await service.SearchAsync(search, cancellationToken));

    [HttpPost]
    public async Task<ActionResult<PaymentTermDto>> Create(CreatePaymentTermDto input, CancellationToken cancellationToken)
        => Ok(await service.CreateAsync(input, cancellationToken));

    [HttpPut("{id}")]
    public async Task<ActionResult<PaymentTermDto>> Update(int id, UpdatePaymentTermDto input, CancellationToken cancellationToken)
    {
        var record = await service.UpdateAsync(id, input, cancellationToken);
        return record is null ? NotFound() : Ok(record);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        => await service.DeleteAsync(id, cancellationToken) ? NoContent() : NotFound();
}