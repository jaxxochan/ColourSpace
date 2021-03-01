namespace CS.Api.DomainModel.Authenticate
{
    public interface IUserQuery
    {
        int Get(string username, string password);
        UserReadModel GetById(int userId);
    }
}
