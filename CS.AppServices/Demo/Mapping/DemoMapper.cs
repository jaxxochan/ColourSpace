using CS.Core.Demo;
using CS.Core.DomainModel.Demo;

namespace CS.Core.AppServices.Demo.Mapping
{
    public static class DemoMapper
    {
        public static EmployeeDto ToDto(this Employee employee) => new EmployeeDto
        {
            Id = employee.Id,
            Name = employee.Name
        };
    }
}
