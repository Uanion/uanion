using MediatR;

namespace Uanion.Application.Features.Dialoge.Queries.GetDialoge;

public class GetDialogeQuery : IRequest<DialogeViewModel>
{
    public Guid DialogeId { get; set; }
}
