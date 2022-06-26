namespace Spread.Entities.Profile;

[Table("Users", Schema = "Profile")]
public class User : EntityBase
{
    [MaxLength(64)]
    [Required]
    public string FullName { get; set; }
    [Required]
    [MaxLength(32)]
    public string UserName { get; set; }
    [Required]
    [MaxLength(64)]
    public string EMail { get; set; }
    [Required]
    [MaxLength(64)]
    public string Password { get; set; }
    [Required]
    public string PasswordHash { get; set; }
    [MaxLength(36)]
    public string VerificationId { get; set; }
    public bool IsBlocked { get; set; }
}