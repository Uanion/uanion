using Uanion.Application.Features.Dialog.Commands.CreateDialog;
using Uanion.Application.Features.Dialog.Commands.UpdateDialog;
using Uanion.Application.Features.Dialog.Queries.GetDialog;
using Uanion.Application.Features.Dialog.Queries.GetDialogsList;
using Uanion.Domain.Entities;

namespace Uanion.Application.MappingProfiles;

public class DialogMappingProfile : AutoMapper.Profile
{
    public DialogMappingProfile()
    {
        CreateMap<CreateDialogCommand, Dialog>();
        CreateMap<UpdateDialogCommand, Dialog>();

        CreateMap<Dialog, DialogViewModel>();
        CreateMap<Dialog, DialogListViewModel>();
    }
}
