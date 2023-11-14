using MediatR;
using Microsoft.AspNetCore.Mvc;
using Uanion.Application.Features.Dialog.Commands.CreateDialog;
using Uanion.Application.Features.Dialog.Commands.DeleteDialog;
using Uanion.Application.Features.Dialog.Commands.UpdateDialog;
using Uanion.Application.Features.Dialog.Queries.GetDialog;
using Uanion.Application.Features.Dialog.Queries.GetDialogsList;

namespace Uanion.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DialogController : ControllerBase
{
    private readonly IMediator _mediator;

    public DialogController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<DialogListViewModel>>> GetDialogsList()
    {
        var dialogsList = await _mediator.Send(new GetDialogsListQuery());

        return Ok(dialogsList);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DialogViewModel>> GetDialogById(Guid id)
    {
        var getDialogQuery = new GetDialogQuery() { DialogId = id };
        return Ok(await _mediator.Send(getDialogQuery));
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateDialogCommand command)
    {
        var id = await _mediator.Send(command);
        return Ok(id);
    }

    [HttpPut]
    public async Task<ActionResult> Update([FromBody] UpdateDialogCommand command)
    {
        await _mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id, [FromQuery] bool isHardDelete = false)
    {
        var deleteDialogCommand = new DeleteDialogCommand { DialogId = id, IsHardDelete = isHardDelete };
        await _mediator.Send(deleteDialogCommand);

        return NoContent();
    }
}
