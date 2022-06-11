using Spread.Data.Requests.Contracts;

namespace Spread.Api.Controllers.Management;

[Route("api/management/[controller]")]
[ApiController]
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

    [HttpPost("add")]
    public async Task<IActionResult> CreateUser([FromBody] NewUserDto data, CancellationToken cancellationToken)
    {
        var result = await service.CreateUser(data, cancellationToken);
        return Ok(result);
    }
}
