using MediatR;
using Spread.Data.Requests.Contracts;

namespace Spread.Data.Requests.Queries
{
    public class GetFollowRequestList : IRequest<List<FollowRequestListDto>>
    {
    }
}