using MediatR;
using Microsoft.AspNetCore.Mvc;
using EnterpriseMdmSolution.Application.Modules.VendorCertificate.Commands;
using EnterpriseMdmSolution.Application.Modules.VendorCertificate.DTOs;
using EnterpriseMdmSolution.Application.Modules.VendorCertificate.Queries;

namespace EnterpriseMdmSolution.API.Controllers;

[ApiController]
[Route("api/vendorcertificates")]
public sealed class VendorCertificatesController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<VendorCertificateDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetVendorCertificateByIdQuery(id), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult> Get(CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchVendorCertificatesQuery(new SearchVendorCertificateDto()), cancellationToken));

    [HttpPost("search")]
    public async Task<ActionResult> Search(SearchVendorCertificateDto search, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchVendorCertificatesQuery(search), cancellationToken));

    [HttpPost]
    public async Task<ActionResult<VendorCertificateDto>> Create(CreateVendorCertificateDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new CreateVendorCertificateCommand(input), cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<VendorCertificateDto>> Update(int id, UpdateVendorCertificateDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new UpdateVendorCertificateCommand(id, input), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var deleted = await mediator.Send(new DeleteVendorCertificateCommand(id), cancellationToken);
        return deleted ? NoContent() : NotFound();
    }
}