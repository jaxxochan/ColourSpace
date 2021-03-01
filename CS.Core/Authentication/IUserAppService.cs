namespace CS.Core.Authentication
{
    public interface IUserAppService
    {
        int Get(string username, string password);
        UserDto GetById(int userId);
    }

    public class UserDto
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}