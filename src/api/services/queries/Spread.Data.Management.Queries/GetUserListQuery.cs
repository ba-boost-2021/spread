using MediatR;
using Spread.Data.Abstractions;
using Spread.Data.Query.Requests;
using Spread.Entities.Profile;

namespace Spread.Data.Management.Queries;

//CQRS : Command Query Responsibility Seggregation

internal class GetUserListQuery : IRequestHandler<GetUserRequest, List<User>>
{
    private readonly IUnitOfWork unitOfWork;

    public GetUserListQuery(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<List<User>> Handle(GetUserRequest request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<User>();
        var result = await repository.GetAll(f => true, cancellationToken);
        return result;
    }
}
