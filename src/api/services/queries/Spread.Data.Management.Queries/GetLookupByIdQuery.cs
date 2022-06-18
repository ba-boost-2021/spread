using AutoMapper;
using MediatR;
using Spread.Data.Abstractions;
using Spread.Data.Query.Requests;
using Spread.Data.Requests.Contracts;
using Spread.Entities.Main;

namespace Spread.Data.Management.Queries;

internal class GetLookupByIdQuery : IRequestHandler<GetLookupByIdRequest, LookUpDto>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public GetLookupByIdQuery(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<LookUpDto> Handle(GetLookupByIdRequest request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<LookUp>();
        var entity = await repository.Get(f => !f.IsDeleted && f.Id == request.Id, f=> f.Type, cancellationToken);
        if(entity is null)
        {
            return null;
        }
        var result = mapper.Map<LookUpDto>(entity);
        return result;
    }
}