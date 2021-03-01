namespace CS.Api.DomainModel.Authenticate
{
    public interface ITokenQuery
    {
        TokenReadModel Get(string authToken);
        TokenReadModel GetByUserId(int userId);
    }
}
