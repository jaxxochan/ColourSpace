using CS.Api.DomainModel.Authenticate;
using Dapper;
using System.Data.SqlClient;

namespace CS.Core.DataAccess.Authenticate
{
    public class UserQuery : IUserQuery
    {
        private const string Sql = @"
            SELECT UserId  
            FROM [User] 
            WHERE UserName = @username AND Password = @password";

        private const string SqlGetById = @"
            SELECT TOP 1 u.UserId AS UserId, ud.FirstName AS FirstName, ud.LastName AS LastName, ur.UserRoleId AS RoleId, ur.UserRoleName AS RoleName 
            FROM [User] u
            INNER JOIN UserDetail ud ON u.UserId = ud.UserId
            INNER JOIN UserUserRole uur ON u.UserId = uur.UserId
            INNER JOIN UserRole ur ON uur.UserRoleId = ur.UserRoleId
            WHERE u.Active = 1 AND u.UserId = @userId";

        private readonly IDbConfiguration _dbConfig;

        public UserQuery(IDbConfiguration configuration) => _dbConfig = configuration;

        public int Get(string username, string password)
        {
            using (var connection = new SqlConnection(_dbConfig.MainDatabase))
            {
                connection.Open();
                return connection.QueryFirst<int>(Sql, new { username = username, password = password });
            }
        }

        public UserReadModel GetById(int userId)
        {
            using (var connection = new SqlConnection(_dbConfig.MainDatabase))
            {
                connection.Open();
                return connection.QuerySingleOrDefault<UserReadModel>(SqlGetById, new { userId = userId });
            }
        }
    }
}
