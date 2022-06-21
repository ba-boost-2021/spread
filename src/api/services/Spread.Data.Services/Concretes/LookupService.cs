using Spread.Data.Requests.Queries;

namespace Spread.Data.Services.Concretes;

internal class LookupService : ILookupService
{
    private readonly IMediator mediator;

    public LookupService(IMediator mediator)
    {
        this.mediator = mediator;
    }

    public Task<bool> CreateLookup(NewLookupRequestDto data, CancellationToken cancellationToken)
    {
        return mediator.Send(new NewLookupRequest(data), cancellationToken);
    }

    public Task<bool> DeleteLookUpById(Guid id, CancellationToken cancellationToken)
    {
        return mediator.Send(new DeleteLookUpByIdRequest(id), cancellationToken);
    }

    public Task<LookUpDto> GetById(Guid id, CancellationToken cancellationToken)
    {
        return mediator.Send(new GetLookupByIdRequest(id), cancellationToken);
    }

    Task<List<LookUpDto>> ILookupService.GetAll(CancellationToken cancellationToken)
    {
        return mediator.Send(new LookupGetAllRequest(), cancellationToken);
    }
}
