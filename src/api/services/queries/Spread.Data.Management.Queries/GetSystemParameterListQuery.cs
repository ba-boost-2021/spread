using MediatR;
using Spread.Data.Abstractions;
using Spread.Data.Query.Requests;
using Spread.Data.Requests.Contracts;
using Spread.Entities.Main;

namespace Spread.Data.Management.Queries;

internal class GetSystemParameterListQuery : IRequestHandler<SystemParameterListRequest, List<SystemParameterDto>>
{
    private readonly IUnitOfWork unitOfWork;

    public GetSystemParameterListQuery(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public Task<List<SystemParameterDto>> Handle(SystemParameterListRequest request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<SystemParameter>();
        return repository.GetAll<SystemParameterDto>(u => !u.IsDeleted, u => u.Key, cancellationToken);
    }
}
