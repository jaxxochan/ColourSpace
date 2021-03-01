using CS.Api.DomainModel.Authenticate;
using Dapper;
using System.Data.SqlClient;

namespace CS.Core.DataAccess.Authenticate
{
    public class TokenQuery : ITokenQuery
    {
        private const string Sql = @"
            SELECT *  
            FROM [Token] 
            WHERE AuthToken = @authToken";


        private const string SqlGetByUserId = @"
            SELECT *  
            FROM [Token] 
            WHERE UserId = @userId";

        private readonly IDbConfiguration _dbConfig;

        public TokenQuery(IDbConfiguration configuration) => _dbConfig = configuration;

        public TokenReadModel Get(string authToken)
        {
            using (var connection = new SqlConnection(_dbConfig.MainDatabase))
            {
                connection.Open();
                return connection.QueryFirstOrDefault<TokenReadModel>(Sql, new { authToken = authToken });
            }
        }

        public TokenReadModel GetByUserId(int userId)
        {
            using (var connection = new SqlConnection(_dbConfig.MainDatabase))
            {
                connection.Open();
                return connection.QueryFirstOrDefault<TokenReadModel>(SqlGetByUserId, new { userId = userId });
            }
        }
    }
}
