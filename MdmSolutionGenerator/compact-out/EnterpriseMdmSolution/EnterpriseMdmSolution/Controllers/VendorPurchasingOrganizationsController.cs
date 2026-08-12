using Microsoft.AspNetCore.Mvc;
using EnterpriseMdmSolution.DTOs;
using EnterpriseMdmSolution.Entities;
using EnterpriseMdmSolution.Services;

namespace EnterpriseMdmSolution.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class VendorPurchasingOrganizationsController(GenericCrudService<VendorPurchasingOrganization, VendorPurchasingOrganizationDto, CreateVendorPurchasingOrganizationDto, UpdateVendorPurchasingOrganizationDto, int> service) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<VendorPurchasingOrganizationDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var record = await service.GetByIdAsync(id, cancellationToken);
        return record is null ? NotFound() : Ok(record);
    }

    [HttpPost("search")]
    public async Task<ActionResult<PagedResult<VendorPurchasingOrganizationDto>>> Search(SearchVendorPurchasingOrganizationDto search, CancellationToken cancellationToken)
        => Ok(await service.SearchAsync(search, cancellationToken));

    [HttpPost]
    public async Task<ActionResult<VendorPurchasingOrganizationDto>> Create(CreateVendorPurchasingOrganizationDto input, CancellationToken cancellationToken)
        => Ok(await service.CreateAsync(input, cancellationToken));

    [HttpPut("{id}")]
    public async Task<ActionResult<VendorPurchasingOrganizationDto>> Update(int id, UpdateVendorPurchasingOrganizationDto input, CancellationToken cancellationToken)
    {
        var record = await service.UpdateAsync(id, input, cancellationToken);
        return record is null ? NotFound() : Ok(record);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        => await service.DeleteAsync(id, cancellationToken) ? NoContent() : NotFound();
}