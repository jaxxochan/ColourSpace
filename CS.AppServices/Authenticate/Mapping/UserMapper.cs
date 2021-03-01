using CS.Api.DomainModel.Authenticate;
using CS.Core.Authentication;

namespace CS.Core.AppServices.Authenticate.Mapping
{
    public static class UserMapper
    {
        public static UserDto ToDto(this UserReadModel model) => new UserDto()
        {
            UserId = model.UserId,
            FirstName = model.FirstName,
            LastName = model.LastName,
            RoleName = model.RoleName,
            RoleId = model.RoleId
        };
    }
}