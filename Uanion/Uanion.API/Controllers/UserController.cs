using MediatR;
using Microsoft.AspNetCore.Mvc;
using Uanion.Application.Features.User.Commands.CreateUser;
using Uanion.Application.Features.User.Queries.GetUser;

namespace Uanion.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserViewModel>> GetUserById(Guid id)
    {
        var getUserQuery = new GetUserQuery() { UserId = id };
        return Ok(await _mediator.Send(getUserQuery));
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateUserCommand command)
    {
        var id = await _mediator.Send(command);
        return Ok(id);
    }
}
