using CS.Api.ResourceModels.Authentication;
using CS.Core.Authentication;

namespace CS.Api.Services.Authentication.Mappings
{
    public static class TokenMapper
    {
        public static Token ToResource(this TokenDto token) => new Token
        {
            AuthToken = token.AuthToken,
            ExpiresOn = token.ExpiresOn,
            IssuedOn = token.IssuedOn,
            UserId = token.UserId,
        };
    }
}
