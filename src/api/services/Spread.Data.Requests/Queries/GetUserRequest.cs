using MediatR;
using Spread.Entities.Profile;

namespace Spread.Data.Query.Requests;

public class GetUserRequest : IRequest<List<User>>
{
}
