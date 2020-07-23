using RapportCQRS.Domain.Commands.User;
using RapportCQRS.Model.Dtos;
using RapportCQRS.Model.Models;
using RapportCQRS.Domain.Dxos.Common;

namespace RapportCQRS.Domain.Dxos
{
    public interface IUserDxos: IBaseDxos
    {
        UserDto MapUserDto(AUser employee);
        AUser MapCreateRequesttoUser(CreateUserCommand employee);
        AUser MapUpdateRequesttoUser(UpdateUserCommand employee);
    }
}