using CS.Api.DomainModel.Authenticate;
using CS.Core.AppServices.Authenticate.Mapping;
using CS.Core.Authentication;

namespace CS.Core.AppServices.Authenticate
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserQuery _userQuery;

        public UserAppService(IUserQuery userQuery) => _userQuery = userQuery;

        public int Get(string username, string password)
        {
            return _userQuery.Get(username, password);
        }

        public UserDto GetById(int userId)
        {
            return _userQuery.GetById(userId)?.ToDto();
        }
    }
}