namespace Uanion.Application.Features.User.Queries.GetUsersList;
public class UserListViewModel
{
    public Guid UserId { get; set; }

    public string Nickname { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }
}
