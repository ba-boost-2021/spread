namespace Spread.Data.Services.Abstractions
{
    public interface IAuthenticationService
    {
        Task<bool> RegisterUser(RegisterUserRequestDto data, CancellationToken cancellationToken);
        Task<LoginResultDto> LoginUser(LoginRequestDto data, CancellationToken cancellationToken);
    }
}