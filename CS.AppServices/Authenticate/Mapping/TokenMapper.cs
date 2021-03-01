using CS.Api.DomainModel.Authenticate;
using CS.Core.Authentication;
using CS.Core.EFModel.Models;

namespace CS.Core.AppServices.Authenticate.Mapping
{
    public static class TokenMapper
    {
        public static Token ToDomain(this TokenReadModel token)
        {
            return new Token()
            {
                TokenId = token.TokenId,
                AuthToken = token.AuthToken,
                UserId = token.UserId,
                IssuedOn = token.IssuedOn,
                ExpiresOn = token.ExpiresOn
            };
        }

        public static TokenDto ToDto(this TokenReadModel token)
        {
            return new TokenDto()
            {
                TokenId = token.TokenId,
                AuthToken = token.AuthToken,
                UserId = token.UserId,
                IssuedOn = token.IssuedOn,
                ExpiresOn = token.ExpiresOn
            };
        }
    }
}
