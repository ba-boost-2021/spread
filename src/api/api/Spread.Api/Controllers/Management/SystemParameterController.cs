﻿using Microsoft.AspNetCore.Authorization;
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
    }
}
