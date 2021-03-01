using CS.Api.Facade.Filters;
using CS.Api.Services.Authentication;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace CS.Api.Facade.WebService.Services.Authenticate
{
    [ApiAuthenticationFilter]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class AuthenticateController : ApiController
    {
        private readonly ITokenService _tokenService;

        public AuthenticateController(ITokenService tokenService) => _tokenService = tokenService;

        public HttpResponseMessage Authenticate()
        {
            if (System.Threading.Thread.CurrentPrincipal != null && System.Threading.Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                var basicAuthenticationIdentity = System.Threading.Thread.CurrentPrincipal.Identity as BasicAuthenticationIdentity;
                if (basicAuthenticationIdentity != null)
                {
                    var userId = basicAuthenticationIdentity.UserId;
                    return GetAuthToken(userId);
                }
            }
            return null;
        }

        private HttpResponseMessage GetAuthToken(int userId)
        {
            var token = _tokenService.Post(userId);
            var response = Request.CreateResponse(HttpStatusCode.OK, "Authorized");
            response.Headers.Add("Token", token.AuthToken);
            response.Headers.Add("TokenExpiry", ConfigurationManager.AppSettings["AuthTokenExpiry"]);
            response.Headers.Add("Access-Control-Expose-Headers", "Token,TokenExpiry");
            return response;
        }
    }
}