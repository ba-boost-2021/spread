namespace Spread.Entities.Profile;

[Table("Blocks", Schema = "Profile")]
public class Block : EntityBase
{
    [Required]
    public Guid UserId { get; set; }
    [Required]
    public Guid BlockedUserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public User User { get; set; }
    [ForeignKey(nameof(BlockedUserId))]
    public User BlockedUser { get; set; }
}