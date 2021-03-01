using CS.Core.AppServices.Demo.Mapping;
using CS.Core.Demo;
using CS.Core.DomainModel.Demo;

namespace CS.Core.AppServices.Demo
{
    public class DemoAppService : IDemoAppService
    {
        private readonly IDemoRepository _demoQuery;

        public DemoAppService(IDemoRepository demoQuery) => _demoQuery = demoQuery;

        public EmployeeDto Get(int employeeId)
        {
            var result = _demoQuery.Get(employeeId);
            return result?.ToDto();
        }

        //private readonly IDemoQuery _demoQuery;

        //public DemoAppService(IDemoQuery demoQuery) => _demoQuery = demoQuery;

        //public EmployeeDto Get(int employeeId)
        //{
        //    var result = _demoQuery.Get(employeeId);
        //    return result?.ToDto();
        //}
    }
}
