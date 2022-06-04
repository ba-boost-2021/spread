namespace Spread.Entities.Profile;

[Table("Followers", Schema = "Profile")]
public class Follower : EntityBase
{
    [Required]
    public Guid UserId { get; set; }
    [Required]
    public Guid FollowingUserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public User User { get; set; }
    [ForeignKey(nameof(FollowingUserId))]
    public User FollowingUser { get; set; }
}