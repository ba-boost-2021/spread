using MediatR;
using Spread.Data.Abstractions;
using Spread.Data.Requests.Contracts;
using Spread.Data.Requests.Queries;
using Spread.Entities.Profile;

namespace Spread.Data.Management.Queries
{
    internal class GetFollowerListQuery : IRequestHandler<GetFollowersRequest, List<FollowerListDto>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetFollowerListQuery(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Task<List<FollowerListDto>> Handle(GetFollowersRequest request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<User>();           //Burada Follower'a maplememiz gerekmez miydi ?
            return repository.GetAll<FollowerListDto>(l => !l.IsDeleted, cancellationToken);
        }
    }
}