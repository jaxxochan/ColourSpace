using CS.Core.DataAccess.Infrastructure;
using CS.Core.DomainModel.Demo;
using CS.Core.EFModel;
using System.Linq;

namespace CS.Core.DataAccess.Demo
{
    //EF Update
    public class DemoRepository : IDemoRepository
    {
        private readonly IRepositoryUow _uow;

        public DemoRepository(IRepositoryUow uow) => _uow = uow;

        public Employee Get(int employeeId)
        {
            //var result = _uow.Repository<student>().FindBy(t => t.student_id == employeeId).FirstOrDefault();
            //return new Employee()
            //{
            //    Id = result.student_id,
            //    Name = result.student_name
            //};
            return null;
        }
    }
}
