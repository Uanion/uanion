using Uanion.Application.Features.Dialog.Commands.CreateDialog;
using Uanion.Application.Features.Dialog.Queries.GetDialog;
using Uanion.Domain.Entities;

namespace Uanion.Application.MappingProfiles;

public class DialogMappingProfile : AutoMapper.Profile
{
    public DialogMappingProfile()
    {
        CreateMap<CreateDialogCommand, Dialog>();
        CreateMap<Dialog, DialogViewModel>();
    }
}
