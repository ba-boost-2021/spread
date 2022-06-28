using System.ComponentModel.DataAnnotations;

namespace Spread.Data.Requests.Contracts;

public class LoginRequestDto
{
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Password { get; set; }
}
