using MediatR;
using Spread.Data.Requests.Contracts;

namespace Spread.Data.Query.Requests;

public class RegisterUserRequest : IRequest<bool>
{
    public RegisterUserRequest(RegisterUserRequestDto data)
    {
        Data = data;
    }

    public RegisterUserRequestDto Data { get; }
}