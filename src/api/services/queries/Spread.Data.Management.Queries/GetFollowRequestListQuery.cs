using MediatR;
using Spread.Common;
using Spread.Data.Abstractions;
using Spread.Data.Requests.Contracts;
using Spread.Data.Requests.Queries;
using Spread.Entities.Profile;

namespace Spread.Data.Management.Queries
{
    public class GetFollowRequestListQuery : IRequestHandler<GetFollowRequestRequest, List<FollowerInfoDto>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IClaims claims;

        public GetFollowRequestListQuery(IUnitOfWork unitOfWork, IClaims claims)
        {
            this.unitOfWork = unitOfWork;
            this.claims = claims;
        }

        public Task<List<FollowerInfoDto>> Handle(GetFollowRequestRequest request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<Follower>();
            return repository.GetAll<FollowerInfoDto>(f => f.IsActive &&
                                                           f.IsApproved == false &&
                                                           f.UserId == claims.CurrentUser.Id,
                                                      cancellationToken);
        }
    }
}