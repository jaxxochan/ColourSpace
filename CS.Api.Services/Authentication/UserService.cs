using CS.Api.ResourceModels.Authentication;
using CS.Api.Services.Authentication.Mappings;
using CS.Core.Authentication;

namespace CS.Api.Services.Authentication
{
    public interface IUserService
    {
        int Authenticate(string userName, string password);
        UserModel GetById(int userId);
    }

    public class UserService : IUserService
    {
        private readonly IUserAppService _userAppService;

        public UserService(IUserAppService userAppService) => _userAppService = userAppService;
        
        public int Authenticate(string userName, string password)
        {
            return _userAppService.Get(userName, password);
        }

        public UserModel GetById(int userId)
        {
            return _userAppService.GetById(userId)?.ToResource();
        }
    }
}