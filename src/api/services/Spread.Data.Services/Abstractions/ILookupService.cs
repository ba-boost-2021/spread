namespace Spread.Data.Services.Abstractions
{
    public interface ILookupService
    {
        Task<bool> CreateLookup(NewLookupRequestDto data, CancellationToken cancellationToken);
        Task<LookUpDto> GetById(Guid id, CancellationToken cancellationToken);
    }
}
