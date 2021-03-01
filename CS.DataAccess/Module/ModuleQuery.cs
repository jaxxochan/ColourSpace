using CS.Core.DomainModel.Module;
using System.Collections.Generic;
using Dapper;
using System.Data.SqlClient;
using System.Linq;

namespace CS.Core.DataAccess.Module
{
    public class ModuleQuery : IModuleQuery
    {
        private const string Sql = @"
            SELECT m.ModuleId AS ModuleId, m.Title AS Title, m.HasAction AS HasAction, m.Action AS Action, 
                m.Controller AS Controller, m.Class AS Class, m.ParentModuleId AS ParentModuleId
            FROM Module m (NOLOCK)
            JOIN RoleModulePermission r ON r.ModuleId = m.ModuleId
            WHERE r.RoleId = @roleId";

        private readonly IDbConfiguration _dbConfig;

        public ModuleQuery(IDbConfiguration configuration) => _dbConfig = configuration;

        public List<UserModule> Get(int roleId)
        {
            using (var connection = new SqlConnection(_dbConfig.MainDatabase))
            {
                connection.Open();
                var result = connection.Query<UserModule>(Sql, new { roleId = roleId });
                return result?.ToList();
            }
        }
    }
}