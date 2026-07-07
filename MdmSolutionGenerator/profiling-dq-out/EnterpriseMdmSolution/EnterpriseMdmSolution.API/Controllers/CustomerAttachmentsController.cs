using MediatR;
using Microsoft.AspNetCore.Mvc;
using EnterpriseMdmSolution.Application.Modules.CustomerAttachment.Commands;
using EnterpriseMdmSolution.Application.Modules.CustomerAttachment.DTOs;
using EnterpriseMdmSolution.Application.Modules.CustomerAttachment.Queries;

namespace EnterpriseMdmSolution.API.Controllers;

[ApiController]
[Route("api/customerattachments")]
public sealed class CustomerAttachmentsController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerAttachmentDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetCustomerAttachmentByIdQuery(id), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult> Get(CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchCustomerAttachmentsQuery(new SearchCustomerAttachmentDto()), cancellationToken));

    [HttpPost("search")]
    public async Task<ActionResult> Search(SearchCustomerAttachmentDto search, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchCustomerAttachmentsQuery(search), cancellationToken));

    [HttpPost]
    public async Task<ActionResult<CustomerAttachmentDto>> Create(CreateCustomerAttachmentDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new CreateCustomerAttachmentCommand(input), cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<CustomerAttachmentDto>> Update(int id, UpdateCustomerAttachmentDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new UpdateCustomerAttachmentCommand(id, input), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var deleted = await mediator.Send(new DeleteCustomerAttachmentCommand(id), cancellationToken);
        return deleted ? NoContent() : NotFound();
    }
}