using MediatR;
using Microsoft.AspNetCore.Mvc;
using Uanion.Application.Features.Profile.Commands.CreateProfile;
using Uanion.Application.Features.Profile.Queries.GetProfile;

namespace Uanion.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProfileController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProfileController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProfileViewModel>> GetProfileById(Guid id)
    {
        var getProfileQuery = new GetProfileQuery() { ProfileId = id };
        return Ok(await _mediator.Send(getProfileQuery));
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateProfileCommand command)
    {
        var id = await _mediator.Send(command);
        return Ok(id);
    }
}
