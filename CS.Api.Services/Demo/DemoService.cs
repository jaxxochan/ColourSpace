using CS.Api.ResourceModels.Demo;
using CS.Api.Services.Demo.Mapping;
using CS.Core.Demo;

namespace CS.Api.Services.Demo
{
    public interface IDemoService
    {
        EmployeeModel Get(int employeeId);
    }

    public class DemoService : IDemoService
    {
        private readonly IDemoAppService _appService;

        public DemoService(IDemoAppService demoAppService) => _appService = demoAppService;

        public EmployeeModel Get(int employeeId)
        {
            //access validation will come here
            var result = _appService.Get(employeeId);
            return result?.ToResource();
        }
    }
}
