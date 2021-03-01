namespace CS.Core.Demo
{
    public interface IDemoAppService
    {
        EmployeeDto Get(int employeeId);
    }

    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
