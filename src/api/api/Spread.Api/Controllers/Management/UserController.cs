using Microsoft.AspNetCore.Authorization;
using Spread.Data.Requests.Contracts;

namespace Spread.Api.Controllers.Management;

[Route("api/management/[controller]")]
[ApiController]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IUserService service;

    public UserController(IUserService service)
    {
        this.service = service;
    }

    [HttpGet("list")]
    public async Task<IActionResult> GetUsers(CancellationToken cancellationToken)
    {
        var result = await service.GetUsers(cancellationToken);
        return Ok(result);
    }
}