using MediatR;
using Spread.Data.Requests.Contracts;

namespace Spread.Data.Query.Requests;

public class LoginUserRequest : IRequest<LoginResultDto>
{
    public LoginUserRequest(LoginRequestDto data)
    {
        Data = data;
    }

    public LoginRequestDto Data { get; }
}