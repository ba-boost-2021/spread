using Microsoft.AspNetCore.Authorization;
using Spread.Data.Requests.Contracts;

namespace Spread.Api.Controllers.Management
{
    [Route("api/management/[controller]")]
    [ApiController]
    [Authorize]
    public class SystemParameterController : ControllerBase
    {
        private readonly ISystemParameterService service;

        public SystemParameterController(ISystemParameterService service)
        {
            this.service = service;
        }
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] NewSystemParameterRequestDto data, CancellationToken cancellationToken)
        {
            var result = await service.CreateSystemParameter(data, cancellationToken);
            return Ok(result);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetSystemParameterById([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var result = await service.GetSystemParameterById(id, cancellationToken);
            //if (result is null)
            //{
            //    return BadRequest();
            //}
            return Ok(result);
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteSystemParameterById([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var result = await service.DeleteSystemParameterById(id, cancellationToken);
            return Ok(result);
        }
    }
}
