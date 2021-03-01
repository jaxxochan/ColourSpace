using CS.Api.DomainModel.Authenticate;
using CS.Core.DataAccess.Infrastructure;
using CS.Core.EFModel.Models;
using System;
using System.Linq;

namespace CS.Core.DataAccess.Authenticate
{
    public class TokenRepository : ITokenRepository
    {
        private readonly IRepositoryUow _uow;

        public TokenRepository(IRepositoryUow uow) => _uow = uow;

        public Token Get(int userId)
        {
            return _uow.Repository<Token>().FindBy(t => t.UserId == userId).FirstOrDefault();
        }

        public void Delete(Token token)
        {
            _uow.Repository<Token>().Delete(token);
            _uow.Repository<Token>().UnitOfWork.Commit();
        }

        public void Post(Token token)
        {
            try
            {
                _uow.Repository<Token>().Add(token);
                _uow.Repository<Token>().UnitOfWork.Commit();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void Put(Token token)
        {
            try
            {
                _uow.Repository<Token>().Update(token);
                _uow.Repository<Token>().UnitOfWork.Commit();
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
