using MediatR;
using Microsoft.AspNetCore.Mvc;
using EnterpriseMdmSolution.Application.Modules.CustomerClassification.Commands;
using EnterpriseMdmSolution.Application.Modules.CustomerClassification.DTOs;
using EnterpriseMdmSolution.Application.Modules.CustomerClassification.Queries;

namespace EnterpriseMdmSolution.API.Controllers;

[ApiController]
[Route("api/customerclassifications")]
public sealed class CustomerClassificationsController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerClassificationDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetCustomerClassificationByIdQuery(id), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult> Get(CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchCustomerClassificationsQuery(new SearchCustomerClassificationDto()), cancellationToken));

    [HttpPost("search")]
    public async Task<ActionResult> Search(SearchCustomerClassificationDto search, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new SearchCustomerClassificationsQuery(search), cancellationToken));

    [HttpPost]
    public async Task<ActionResult<CustomerClassificationDto>> Create(CreateCustomerClassificationDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new CreateCustomerClassificationCommand(input), cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<CustomerClassificationDto>> Update(int id, UpdateCustomerClassificationDto input, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new UpdateCustomerClassificationCommand(id, input), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var deleted = await mediator.Send(new DeleteCustomerClassificationCommand(id), cancellationToken);
        return deleted ? NoContent() : NotFound();
    }
}