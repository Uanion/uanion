using AutoMapper;
using MediatR;
using Uanion.Application.Contracts.Persistence;

namespace Uanion.Application.Features.Dialog.Queries.GetDialogsList;

public class GetDialogsListQueryHandler : IRequestHandler<GetDialogsListQuery, List<DialogListViewModel>>
{
    private readonly IDialogRepository _dialogRepository;
    private readonly IMapper _mapper;

    public GetDialogsListQueryHandler(IDialogRepository dialogRepository, IMapper mapper)
    {
        _dialogRepository = dialogRepository;
        _mapper = mapper;
    }

    public async Task<List<DialogListViewModel>> Handle(GetDialogsListQuery request, CancellationToken cancellationToken)
    {
        var allDialogs = await _dialogRepository.ListAllAsync();

        return _mapper.Map<List<DialogListViewModel>>(allDialogs);
    }
}
