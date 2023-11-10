using MediatR;
using Microsoft.AspNetCore.Mvc;
using Uanion.Application.Features.User.Commands.CreateUser;
using Uanion.Application.Features.User.Commands.DeleteUser;
using Uanion.Application.Features.User.Commands.UpdateUser;
using Uanion.Application.Features.User.Queries.GetUser;
using Uanion.Application.Features.User.Queries.GetUsersList;

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

    [HttpGet]
    public async Task<ActionResult<List<UserListViewModel>>> GetUsersList()
    {
        var usersList = await _mediator.Send(new GetUsersListQuery());

        return Ok(usersList);
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

    [HttpPut]
    public async Task<ActionResult> Update([FromBody] UpdateUserCommand command)
    {
        await _mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id, [FromQuery] bool isHardDelete = false)
    {
        var deleteUserCommand = new DeleteUserCommand { UserId = id, IsHardDelete = isHardDelete };
        await _mediator.Send(deleteUserCommand);

        return NoContent();
    }
}
