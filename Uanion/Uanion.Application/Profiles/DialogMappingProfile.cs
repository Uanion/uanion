using AutoMapper;
using Uanion.Application.Features.Dialog.Commands.CreateDialog;
using Uanion.Application.Features.Dialog.Queries.GetDialog;
using Uanion.Domain.Entities;

namespace Uanion.Application.Profiles;

public class DialogMappingProfile : Profile
{
    public DialogMappingProfile()
    {
        CreateMap<CreateDialogCommand, Dialog>();
        CreateMap<Dialog, DialogViewModel>();
    }
}
