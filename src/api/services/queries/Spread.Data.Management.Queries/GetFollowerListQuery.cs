using MediatR;
using Spread.Common;
using Spread.Data.Abstractions;
using Spread.Data.Requests.Contracts;
using Spread.Data.Requests.Queries;
using Spread.Entities.Profile;

namespace Spread.Data.Management.Queries
{
    internal class GetFollowerListQuery : IRequestHandler<GetFollowersRequest, List<FollowerInfoDto>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IClaims claims;

        public GetFollowerListQuery(IUnitOfWork unitOfWork, IClaims claims)
        {
            this.unitOfWork = unitOfWork;
            this.claims = claims;
        }

        public Task<List<FollowerInfoDto>> Handle(GetFollowersRequest request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<Follower>();
            return repository.GetAll<FollowerInfoDto>(f => f.IsActive && 
                                                           f.IsApproved &&
                                                           f.UserId == claims.CurrentUser.Id,
                                                      cancellationToken);
        }
    }
}