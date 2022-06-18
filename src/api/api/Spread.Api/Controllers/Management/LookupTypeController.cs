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
        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var result = await service.LookupTypeGetById(id, cancellationToken);
            return Ok(result);
        }
       
    }
}
