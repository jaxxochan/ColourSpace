using CS.Api.ResourceModels.Authentication;
using CS.Api.Services.Authentication.Mappings;
using CS.Core.Authentication;
using System.Net;
using System.Net.Http;

namespace CS.Api.Services.Authentication
{
    public interface ITokenService
    {
        //Generate Token
        Token Post(int userId);

        //Validate Token by authToken
        Token Get(string authToken);

        //Delete token by authToken
        HttpResponseMessage Delete(string authToken);
    }

    public class TokenService : ITokenService
    {
        private readonly ITokenAppService _tokenAppService;

        public TokenService(ITokenAppService tokenAppService) => _tokenAppService = tokenAppService;

        public Token Post(int userId)
        {
            _tokenAppService.Post(userId);
            var result = _tokenAppService.GetByUserId(userId);
            return result?.ToResource();
        }

        public Token Get(string authToken)
        {
            var result = _tokenAppService.Get(authToken);
            return result?.ToResource();
        }

        public HttpResponseMessage Delete(string authToken)
        {
            _tokenAppService.Delete(authToken);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}
