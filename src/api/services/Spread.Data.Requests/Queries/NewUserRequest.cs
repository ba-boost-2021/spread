using MediatR;
using Spread.Data.Requests.Contracts;

namespace Spread.Data.Query.Requests;

public class NewUserRequest : IRequest<bool>
{
    public NewUserRequest(NewUserDto data)
    {
        Data = data;
    }

    public NewUserDto Data { get; }
}