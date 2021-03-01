using CS.Core.DomainModel.Demo;
using Dapper;
using System.Data.SqlClient;

namespace CS.Core.DataAccess.Demo
{
    //Dapper Read
    public class DemoQuery : IDemoQuery
    {
        private const string Sql = @"
            SELECT student_id id, student_name name 
            FROM student 
            WHERE student_id = @studentId";

        private readonly IDbConfiguration _dbConfig;

        public DemoQuery(IDbConfiguration configuration) => _dbConfig = configuration;

        public Employee Get(int employeeId)
        {
            using (var connection = new SqlConnection(_dbConfig.MainDatabase))
            {
                connection.Open();
                return connection.QueryFirstOrDefault<Employee>(Sql, new { studentId = employeeId });
            }
        }
    }
}
