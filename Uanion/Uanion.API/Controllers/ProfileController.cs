using MediatR;
using Microsoft.AspNetCore.Mvc;
using Uanion.Application.Features.Profile.Commands.CreateProfile;
using Uanion.Application.Features.Profile.Queries.GetProfile;
using Uanion.Application.Features.Profile.Commands.DeleteProfile;
using Uanion.Application.Features.Profile.Queries.GetProfilesList;
using Uanion.Application.Features.Profile.Commands.UpdateProfile;

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

    [HttpGet]
    public async Task<ActionResult<List<ProfileListViewModel>>> GetProfilesList()
    {
        var profilesList = await _mediator.Send(new GetProfilesListQuery());

        return Ok(profilesList);
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

    [HttpPut]
    public async Task<ActionResult> Update([FromBody] UpdateProfileCommand command)
    {
        await _mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id, [FromQuery] bool isHardDelete = false)
    {
        var deleteProfileCommand = new DeleteProfileCommand { ProfileId = id, IsHardDelete = isHardDelete };
        await _mediator.Send(deleteProfileCommand);

        return NoContent();
    }
}
