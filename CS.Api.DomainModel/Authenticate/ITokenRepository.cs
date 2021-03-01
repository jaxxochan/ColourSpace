using CS.Core.EFModel.Models;

namespace CS.Api.DomainModel.Authenticate
{
    public interface ITokenRepository
    {
        Token Get(int userId);
        void Put(Token token);
        void Post(Token token);
        void Delete(Token token);
    }
}
