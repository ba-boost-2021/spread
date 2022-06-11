namespace Spread.Data.Services.Concretes;

internal class UserService : IUserService
{
    private readonly IMediator mediator;

    public UserService(IMediator mediator)
    {
        this.mediator = mediator;
    }

    public Task<bool> CreateUser(NewUserDto data, CancellationToken cancellationToken)
    {
        return mediator.Send(new NewUserRequest(data), cancellationToken);
    }

    public Task<List<UserListDto>> GetUsers(CancellationToken cancellationToken)
    {
        return mediator.Send(new GetUserRequest(), cancellationToken);
    }
}
