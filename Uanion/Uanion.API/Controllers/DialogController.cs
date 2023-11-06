using MediatR;
using Microsoft.AspNetCore.Mvc;
using Uanion.Application.Features.Dialog.Commands.CreateDialog;
using Uanion.Application.Features.Dialog.Queries.GetDialog;

namespace Uanion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DialogController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DialogController(IMediator mediator)
        {
            _mediator = mediator;
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
    }
}
