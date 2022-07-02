namespace Spread.Data.Services.Abstractions
{
    public interface IPostService
    {
        Task<bool> Post(PostDto data, CancellationToken cancellationToken);
    }
}