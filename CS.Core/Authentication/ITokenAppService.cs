using System;
using System.Net.Http;

namespace CS.Core.Authentication
{
    public interface ITokenAppService
    {
        TokenDto Get(string authToken);
        TokenDto GetByUserId(int userId);
        HttpResponseMessage Post(int userId);
        HttpResponseMessage Delete(string tokenId);
    }

    public class TokenDto
    {
        public int TokenId { get; set; }
        public int UserId { get; set; }
        public string AuthToken { get; set; }
        public DateTime IssuedOn { get; set; }
        public DateTime ExpiresOn { get; set; }
    }
}
