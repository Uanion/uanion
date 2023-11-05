using AutoMapper;
using MediatR;
using Uanion.Application.Contracts.Persistence;

namespace Uanion.Application.Features.Dialoge.Queries.GetDialoge;

public class GetDialogeQueryHandler : IRequestHandler<GetDialogeQuery, DialogeViewModel>
{
    private readonly IDialogeRepository _dialogeRepository;
    private readonly IMapper _mapper;

    public GetDialogeQueryHandler(IDialogeRepository dialogeRepository, IMapper mapper)
    {
        _dialogeRepository = dialogeRepository;
        _mapper = mapper;
    }

    public async Task<DialogeViewModel> Handle(GetDialogeQuery request, CancellationToken cancellationToken)
    {
        var dialoge = await _dialogeRepository.GetByIdAsync(request.DialogeId);
        var dialogeVm = _mapper.Map<DialogeViewModel>(dialoge);

        return dialogeVm;
    }
}
