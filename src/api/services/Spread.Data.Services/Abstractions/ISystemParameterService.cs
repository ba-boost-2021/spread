public interface ISystemParameterService
{
    Task<bool> CreateSystemParameter(NewSystemParameterRequestDto data, CancellationToken cancellationToken);
}