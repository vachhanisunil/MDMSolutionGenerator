using Microsoft.AspNetCore.Mvc;
using EnterpriseMdmSolution.DTOs;
using EnterpriseMdmSolution.Entities;
using EnterpriseMdmSolution.Services;

namespace EnterpriseMdmSolution.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class VendorEvaluationsController(GenericCrudService<VendorEvaluation, VendorEvaluationDto, CreateVendorEvaluationDto, UpdateVendorEvaluationDto, int> service) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<VendorEvaluationDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var record = await service.GetByIdAsync(id, cancellationToken);
        return record is null ? NotFound() : Ok(record);
    }

    [HttpPost("search")]
    public async Task<ActionResult<PagedResult<VendorEvaluationDto>>> Search(SearchVendorEvaluationDto search, CancellationToken cancellationToken)
        => Ok(await service.SearchAsync(search, cancellationToken));

    [HttpPost]
    public async Task<ActionResult<VendorEvaluationDto>> Create(CreateVendorEvaluationDto input, CancellationToken cancellationToken)
        => Ok(await service.CreateAsync(input, cancellationToken));

    [HttpPut("{id}")]
    public async Task<ActionResult<VendorEvaluationDto>> Update(int id, UpdateVendorEvaluationDto input, CancellationToken cancellationToken)
    {
        var record = await service.UpdateAsync(id, input, cancellationToken);
        return record is null ? NotFound() : Ok(record);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        => await service.DeleteAsync(id, cancellationToken) ? NoContent() : NotFound();
}