using MediatR;
using Spread.Data.Abstractions;
using Spread.Data.Query.Requests;
using Spread.Data.Requests.Contracts;
using Spread.Entities.Profile;

namespace Spread.Data.Management.Queries;

//CQRS : Command Query Responsibility Seggregation

internal class GetUserListQuery : IRequestHandler<GetUserRequest, List<UserListDto>>
{
    private readonly IUnitOfWork unitOfWork;

    public GetUserListQuery(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public Task<List<UserListDto>> Handle(GetUserRequest request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<User>();
        return repository.GetAll<UserListDto>(f => true, o => o.EMail, cancellationToken);
    }
}
