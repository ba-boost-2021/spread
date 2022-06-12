using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Spread.Data.Requests.Contracts;

namespace Spread.Api.Controllers.Management
{
    [Route("api/management/[controller]")]
    [ApiController]
    [Authorize]
    public class LookupTypeController : ControllerBase
    {
        private readonly ILookupTypeService service;

        public LookupTypeController(ILookupTypeService service)
        {
            this.service = service;
        }
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] NewLookupTypeRequestDto data, CancellationToken cancellationToken)
        {
            var result = await service.CreateLookupType(data, cancellationToken);
            return Ok(result);
        }
    }
}
