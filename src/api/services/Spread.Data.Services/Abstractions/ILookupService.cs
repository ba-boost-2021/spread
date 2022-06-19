namespace Spread.Data.Services.Abstractions
{
    public interface ILookupService
    {
        Task<bool> CreateLookup(NewLookupRequestDto data, CancellationToken cancellationToken);
        Task<LookUpDto> GetById(Guid id, CancellationToken cancellationToken);
        Task<List<LookUpDto>> GetAll(CancellationToken cancellationToken);
    }
}