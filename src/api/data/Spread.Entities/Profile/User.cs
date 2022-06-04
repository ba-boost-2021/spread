namespace Spread.Entities.Profile;

[Table("Users", Schema = "Profile")]
public class User : EntityBase
{
    public string UserName { get; set; }
    public string EMail { get; set; }
    public string Password { get; set; }
    public string PasswordHash { get; set; }
    public string VerificationId { get; set; }
    public bool IsBlocked { get; set; }
}