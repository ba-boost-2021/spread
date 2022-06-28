using Microsoft.AspNetCore.Authorization;

namespace Spread.Api.Controllers.Public
{
    [Route("api/public/[controller]")]
    [ApiController]
    [Authorize]
    public class FollowerController : ControllerBase
    {
        [HttpGet("requests")]
        public async Task<IActionResult> GetFollowRequests(CancellationToken cancellationToken)
        {
            
            return Ok(true);
        }

        [HttpGet("followers")]
        public async Task<IActionResult> GetFollowers(CancellationToken cancellationToken)
        {
            return Ok(true);
        }
    }
}
