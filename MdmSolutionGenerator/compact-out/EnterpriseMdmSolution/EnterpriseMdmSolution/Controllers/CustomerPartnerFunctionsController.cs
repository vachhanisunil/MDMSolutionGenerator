using Microsoft.AspNetCore.Mvc;
using EnterpriseMdmSolution.DTOs;
using EnterpriseMdmSolution.Entities;
using EnterpriseMdmSolution.Services;

namespace EnterpriseMdmSolution.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class CustomerPartnerFunctionsController(GenericCrudService<CustomerPartnerFunction, CustomerPartnerFunctionDto, CreateCustomerPartnerFunctionDto, UpdateCustomerPartnerFunctionDto, int> service) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerPartnerFunctionDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var record = await service.GetByIdAsync(id, cancellationToken);
        return record is null ? NotFound() : Ok(record);
    }

    [HttpPost("search")]
    public async Task<ActionResult<PagedResult<CustomerPartnerFunctionDto>>> Search(SearchCustomerPartnerFunctionDto search, CancellationToken cancellationToken)
        => Ok(await service.SearchAsync(search, cancellationToken));

    [HttpPost]
    public async Task<ActionResult<CustomerPartnerFunctionDto>> Create(CreateCustomerPartnerFunctionDto input, CancellationToken cancellationToken)
        => Ok(await service.CreateAsync(input, cancellationToken));

    [HttpPut("{id}")]
    public async Task<ActionResult<CustomerPartnerFunctionDto>> Update(int id, UpdateCustomerPartnerFunctionDto input, CancellationToken cancellationToken)
    {
        var record = await service.UpdateAsync(id, input, cancellationToken);
        return record is null ? NotFound() : Ok(record);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        => await service.DeleteAsync(id, cancellationToken) ? NoContent() : NotFound();
}