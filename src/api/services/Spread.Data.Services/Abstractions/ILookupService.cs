namespace Spread.Data.Services.Abstractions
{
    public interface ILookupService
    {
        Task<bool> CreateLookup(NewLookupRequestDto data, CancellationToken cancellationToken);
    }
}