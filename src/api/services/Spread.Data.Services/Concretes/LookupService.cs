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
}
