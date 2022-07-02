namespace Spread.Data.Services.Concretes;

internal class PostService : IPostService
{
    private readonly IMediator mediator;

    public PostService(IMediator mediator)
    {
        this.mediator = mediator;
    }

    public Task<List<PostListDto>> GetAllPosts(CancellationToken cancellationToken)
    {
        return mediator.Send(new ListPostsRequest(), cancellationToken);
    }

    public Task<bool> Post(PostDto data, CancellationToken cancellationToken)
    {
        return mediator.Send(new NewPostRequest(data), cancellationToken);
    }
}
