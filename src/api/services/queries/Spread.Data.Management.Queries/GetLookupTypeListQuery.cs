using MediatR;
using Spread.Data.Abstractions;
using Spread.Data.Query.Requests;
using Spread.Data.Requests.Contracts;
using Spread.Entities.Main;

namespace Spread.Data.Management.Queries;

internal class GetLookupTypeListQuery : IRequestHandler<LookupTypeListRequest, List<LookupTypeDto>>
{
    private readonly IUnitOfWork unitOfWork;

    public GetLookupTypeListQuery(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public Task<List<LookupTypeDto>> Handle(LookupTypeListRequest request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<LookupType>();
        return repository.GetAll<LookupTypeDto>(u => !u.IsDeleted, u => u.Name, cancellationToken);
    }
}