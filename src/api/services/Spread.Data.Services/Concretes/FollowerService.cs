using Spread.Data.Requests.Queries;

namespace Spread.Data.Services.Concretes
{
    internal class FollowerService : IFollowerService
    {
        private readonly IMediator mediator;

        public FollowerService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public Task<List<FollowerListDto>> GetFollowers(CancellationToken cancellationToken)
        {
            return mediator.Send(new GetFollowersRequest(), cancellationToken);
        }

        Task<List<FollowRequestListDto>> IFollowerService.GetFollowRequests(CancellationToken cancellationToken)
        {
            return mediator.Send(new GetFollowRequestList(), cancellationToken);
        }
    }
}