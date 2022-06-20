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
        if(string.IsNullOrEmpty(request.Data.Name))
        {
            return false;
        }
        var repository = unitOfWork.GetRepository<LookUp>();
        var conflict = await repository.Get(f => f.IsActive && !f.IsDeleted && f.Name == request.Data.Name, cancellationToken);
        if(conflict is not null)
        {
            return false;
        }
        var entity = mapper.Map<LookUp>(request.Data);
        repository.Insert(entity);
        var result = await unitOfWork.SaveChanges(cancellationToken);
        return result > 0;
    }

}
