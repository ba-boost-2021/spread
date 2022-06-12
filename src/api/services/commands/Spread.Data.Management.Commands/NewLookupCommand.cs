using AutoMapper;
using MediatR;
using Spread.Data.Abstractions;
using Spread.Data.Query.Requests;
using Spread.Entities.Main;

namespace Spread.Data.Management.Commands;

internal class NewLookupCommand : IRequestHandler<NewLookupRequest, bool>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public NewLookupCommand(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<bool> Handle(NewLookupRequest request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<LookUp>(request.Data);
        var repository = unitOfWork.GetRepository<LookUp>();
        repository.Insert(entity);
        var result = await unitOfWork.SaveChanges(cancellationToken);
        return result > 0;
    }
}