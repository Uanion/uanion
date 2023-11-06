using AutoMapper;
using MediatR;
using Uanion.Application.Contracts.Persistence;

namespace Uanion.Application.Features.Dialog.Queries.GetDialog;

public class GetDialogQueryHandler : IRequestHandler<GetDialogQuery, DialogViewModel>
{
    private readonly IDialogRepository _dialogRepository;
    private readonly IMapper _mapper;

    public GetDialogQueryHandler(IDialogRepository dialogRepository, IMapper mapper)
    {
        _dialogRepository = dialogRepository;
        _mapper = mapper;
    }

    public async Task<DialogViewModel> Handle(GetDialogQuery request, CancellationToken cancellationToken)
    {
        var dialog = await _dialogRepository.GetByIdAsync(request.DialogId);
        var dialogVm = _mapper.Map<DialogViewModel>(dialog);

        return dialogVm;
    }
}
