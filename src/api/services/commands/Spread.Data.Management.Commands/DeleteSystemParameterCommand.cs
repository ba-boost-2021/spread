using MediatR;
using Spread.Data.Abstractions;
using Spread.Data.Query.Requests;
using Spread.Entities.Main;

namespace Spread.Data.Management.Commands;

internal class DeleteSystemParameterCommand : IRequestHandler<DeleteSystemParameterByIdRequest, bool>
{
    private readonly IUnitOfWork unitofwork;
    public DeleteSystemParameterCommand(IUnitOfWork unitofwork)
    {
        this.unitofwork = unitofwork;
    }

    public async Task<bool> Handle(DeleteSystemParameterByIdRequest request, CancellationToken cancellationToken)
    {

        var repository = unitofwork.GetRepository<SystemParameter>();
        var entity = await repository.Get(x => x.Id == request.Id && !x.IsDeleted, cancellationToken);
        if (entity is null)
        {
            return false;
        }
        repository.Delete(entity);
        var result = await unitofwork.SaveChanges(cancellationToken);
        return result > 0;

    }
}

