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

        public Task<List<FollowerInfoDto>> GetFollowers(CancellationToken cancellationToken)
        {
            return mediator.Send(new GetFollowersRequest(), cancellationToken);
        }

        public Task<List<FollowerInfoDto>> GetFollowRequests(CancellationToken cancellationToken)
        {
            return mediator.Send(new GetFollowRequestRequest(), cancellationToken);
        }
    }
}