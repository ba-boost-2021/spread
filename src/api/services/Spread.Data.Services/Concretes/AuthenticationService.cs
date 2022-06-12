using MediatR;

namespace Spread.Data.Services.Concretes;

internal class AuthenticationService : IAuthenticationService
{
    private readonly IMediator mediator;

    public AuthenticationService(IMediator mediator)
    {
        this.mediator = mediator;
    }

    public Task<LoginResultDto> LoginUser(LoginRequestDto data, CancellationToken cancellationToken)
    {
        return mediator.Send(new LoginUserRequest(data), cancellationToken);
    }

    public Task<bool> RegisterUser(RegisterUserRequestDto data, CancellationToken cancellationToken)
    {
        return mediator.Send(new RegisterUserRequest(data), cancellationToken);
    }
}
