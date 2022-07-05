namespace Spread.Data.Services.Abstractions
{
    public interface IFollowerService
    {
        Task<List<FollowerInfoDto>> GetFollowers(CancellationToken cancellationToken);

        Task<List<FollowerInfoDto>> GetFollowRequests(CancellationToken cancellationToken);
    }
}