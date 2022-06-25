using AutoMapper;
using MediatR;
using Spread.Data.Abstractions;
using Spread.Data.Query.Requests;
using Spread.Data.Requests.Contracts;
using Spread.Entities.Main;

namespace Spread.Data.Management.Commands;

internal class EditLookupCommand : IRequestHandler<EditLookupRequest, bool>
{
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;
    public EditLookupCommand(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<bool> Handle(EditLookupRequest request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<LookUp>();
        var entity = await repository.Get(f => f.Id == request.Data.Id, cancellationToken);
        if (entity is null)
        {
            return false;
        }
        var mapped = mapper.Map(request.Data, entity);
        repository.Update(mapped);
        var result = await unitOfWork.SaveChanges(cancellationToken);
        return result > 0;
    }
}