using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spread.Data.Services.Abstractions
{
    public interface IFollowerService
    {
        Task<List<FollowerListDto>> GetFollowers(CancellationToken cancellationToken);

        Task<List<FollowRequestListDto>> GetFollowRequests(CancellationToken cancellationToken);
    }
}