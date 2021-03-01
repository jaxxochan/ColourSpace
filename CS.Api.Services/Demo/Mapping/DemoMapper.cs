using CS.Api.ResourceModels.Demo;
using CS.Core.Demo;

namespace CS.Api.Services.Demo.Mapping
{
    public static class DemoMapper
    {
        public static EmployeeModel ToResource(this EmployeeDto dto) => new EmployeeModel
        {
            Id = dto.Id,
            Name = dto.Name
        };
    }
}
