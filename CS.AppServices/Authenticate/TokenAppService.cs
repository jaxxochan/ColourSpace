using CS.Api.DomainModel.Authenticate;
using CS.Core.AppServices.Authenticate.Mapping;
using CS.Core.Authentication;
using CS.Core.EFModel.Models;
using System;
using System.Configuration;
using System.Net;
using System.Net.Http;

namespace CS.Core.AppServices.Authenticate
{
    public class TokenAppService : ITokenAppService
    {
        private readonly ITokenQuery _tokenQuery;
        private readonly ITokenRepository _tokenRepository;

        public TokenAppService(ITokenQuery tokenQuery, ITokenRepository tokenRepository)
        {
            this._tokenQuery = tokenQuery;
            this._tokenRepository = tokenRepository;
        }

        public HttpResponseMessage Post(int userId)
        {
            Try.Action(() =>
            {
                var userToken = _tokenRepository.Get(userId);
                DateTime expiredOn = DateTime.Now.AddSeconds(
                                                  Convert.ToDouble(ConfigurationManager.AppSettings["AuthTokenExpiry"]));
                if (userToken == null)
                {
                    string authToken = Guid.NewGuid().ToString();
                    DateTime issuedOn = DateTime.Now;

                    var token = new Token
                    {
                        UserId = userId,
                        AuthToken = authToken,
                        IssuedOn = issuedOn,
                        ExpiresOn = expiredOn
                    };
                    _tokenRepository.Post(token);
                }
                else
                {
                    userToken.ExpiresOn = expiredOn;
                    _tokenRepository.Put(userToken);
                }
            });
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        public TokenDto Get(string authToken)
        {
            var result = _tokenQuery.Get(authToken);
            return result?.ToDto();
        }

        public HttpResponseMessage Delete(string authToken)
        {
            Try.Action(() =>
            {
                var token = _tokenQuery.Get(authToken);
                _tokenRepository.Delete(token?.ToDomain());
            });
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        public TokenDto GetByUserId(int userId)
        {
            var result = _tokenQuery.GetByUserId(userId);
            return result?.ToDto();
        }
    }
}
