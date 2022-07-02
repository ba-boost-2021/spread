using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spread.Data.Requests.Contracts;

namespace Spread.Api.Controllers.Public
{
    [Route("api/public/[controller]")]
    [ApiController]
    [Authorize]
    public class PostController : ControllerBase
    {
        private readonly IPostService service;

        public PostController(IPostService service)
        {
            this.service = service;
        }
        [HttpPost("post")]
        public async Task<IActionResult> Post([FromForm] PostDto dto, CancellationToken cancellationToken)
        {
            var result = await service.Post(dto, cancellationToken);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpGet("list")]
        public async Task<IActionResult> ListPosts(CancellationToken cancellationToken)
        {
            var result = await service.GetAllPosts(cancellationToken);
            return Ok(result);
        }
    }
}
