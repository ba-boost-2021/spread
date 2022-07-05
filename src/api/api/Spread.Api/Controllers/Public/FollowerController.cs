using Microsoft.AspNetCore.Authorization;

namespace Spread.Api.Controllers.Public
{
    [Route("api/public/[controller]")]
    [ApiController]
    [Authorize]
    public class FollowerController : ControllerBase
    {
        private readonly IFollowerService service;

        public FollowerController(IFollowerService service)
        {
            this.service = service;
        }

        [HttpGet("requests")]
        public async Task<IActionResult> GetFollowRequests(CancellationToken cancellationToken)
        {
            var result = await service.GetFollowRequests(cancellationToken);
            return Ok(result);
        }

        [HttpGet("followers")]
        public async Task<IActionResult> GetFollowers(CancellationToken cancellationToken)
        {
            var result = await service.GetFollowers(cancellationToken);
            return Ok(result);
        }
    }
}