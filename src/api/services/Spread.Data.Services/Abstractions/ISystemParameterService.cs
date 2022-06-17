namespace Spread.Data.Services.Abstractions
{
    public interface ISystemParameterService
    {
        Task<bool> CreateSystemParameter(NewSystemParameterRequestDto data, CancellationToken cancellationToken);
        Task<SystemParameterDto> GetSystemParameterById(Guid id, CancellationToken cancellationToken);
    }
}