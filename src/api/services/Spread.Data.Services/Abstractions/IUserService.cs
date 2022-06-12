namespace Spread.Data.Services.Abstractions
{
    public interface IUserService
    {
        Task<List<UserListDto>> GetUsers(CancellationToken cancellationToken);
    }
}