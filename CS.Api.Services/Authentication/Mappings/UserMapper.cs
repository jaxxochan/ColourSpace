using CS.Api.ResourceModels.Authentication;
using CS.Core.Authentication;

namespace CS.Api.Services.Authentication.Mappings
{
    public static class UserMapper
    {
        public static UserModel ToResource(this UserDto dto) => new UserModel()
        {
            UserId = dto.UserId,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            RoleId = dto.RoleId,
            RoleName = dto.RoleName
        };
    }
}