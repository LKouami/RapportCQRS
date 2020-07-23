using RapportCQRS.Domain.Commands.Activity;
using RapportCQRS.Model.Dtos;
using RapportCQRS.Model.Models;
using RapportCQRS.Domain.Dxos.Common;

namespace RapportCQRS.Domain.Dxos
{
    public interface IActivityDxos : IBaseDxos
    {
        ActivityDto MapActivityDto(SActivity activity);
        SActivity MapCreateRequesttoActivity(CreateActivityCommand activity);
        SActivity MapUpdateRequesttoActivity(UpdateActivityCommand activity);
    }
}
