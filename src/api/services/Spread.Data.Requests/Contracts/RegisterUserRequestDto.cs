namespace Spread.Data.Requests.Contracts;

public class RegisterUserRequestDto
{
    public string UserName { get; set; }
    public string FullName { get; set; }
    public string EMail { get; set; }
    public string Password { get; set; }
}
