using MediatR;
using Spread.Data.Abstractions;
using Spread.Data.Query.Requests;
using Spread.Data.Requests.Contracts;
using Spread.Entities.Main;

namespace Spread.Data.Management.Queries;

internal class GetLookupListQuery : IRequestHandler<LookupGetAllRequest, List<LookUpDto>>
{
    private readonly IUnitOfWork unitOfWork;

    public GetLookupListQuery(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }
    public Task<List<LookUpDto>> Handle(LookupGetAllRequest request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<LookUp>();
        return repository.GetAll<LookUpDto>(u=> !u.IsDeleted,u=>u.Name,cancellationToken);
    }
}
