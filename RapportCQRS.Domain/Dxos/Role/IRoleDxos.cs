using RapportCQRS.Model.Dtos;
using RapportCQRS.Model.Models;
using RapportCQRS.Domain.Dxos.Common;

namespace RapportCQRS.Domain.Dxos
{
    public interface IRoleDxos: IBaseDxos
    {
        RoleDto MapRoleDto(ARole employee);
        //ARole MapCreateRequesttoRole(CreateRoleCommand employee);
        //ARole MapUpdateRequesttoRole(UpdateRoleCommand employee);
    }
}