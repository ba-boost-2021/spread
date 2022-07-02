using MediatR;
using Spread.Data.Abstractions;
using Spread.Data.Requests.Contracts;
using Spread.Data.Requests.Queries;
using Spread.Entities.Profile;

namespace Spread.Data.Management.Queries
{
    public class GetFollowRequestListQuery : IRequestHandler<GetFollowRequestList, List<FollowRequestListDto>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetFollowRequestListQuery(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Task<List<FollowRequestListDto>> Handle(GetFollowRequestList request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<User>();
            return repository.GetAll<FollowRequestListDto>(r => !r.IsDeleted, cancellationToken);
        }
    }
}