using Microsoft.AspNetCore.Authorization;
using Spread.Data.Requests.Contracts;

namespace Spread.Api.Controllers.Management
{
    [Route("api/management/[controller]")]
    [ApiController]
    [Authorize]
    public class LookupController : ControllerBase
    {
        private readonly ILookupService service;

        public LookupController(ILookupService service)
        {
            this.service = service;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] NewLookupRequestDto data, CancellationToken cancellationToken)
        {
            var result = await service.CreateLookup(data, cancellationToken);
            return Ok(result);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var result = await service.GetById(id, cancellationToken);
            return Ok(result);
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetLookups(CancellationToken cancellationToken)
        {
            var result = await service.GetAll(cancellationToken);
            return Ok(result);
        }
    }
}
