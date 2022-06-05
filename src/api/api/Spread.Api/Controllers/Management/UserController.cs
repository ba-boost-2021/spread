using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Spread.Api.Controllers.Management
{
    [Route("api/management/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> logger;

        public UserController(ILogger<UserController> logger)
        {
            this.logger = logger;
        }
        [HttpGet("list")]
        public async Task<IActionResult> GetUsers(CancellationToken cancellationToken)
        {
            await Task.Delay(5000, cancellationToken);
            logger.LogInformation("Süreç işletildi");
            return Ok("3 kullanıcı var");
        }
    }
}
