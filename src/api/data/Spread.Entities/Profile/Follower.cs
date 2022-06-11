namespace Spread.Entities.Profile;

[Table("Followers", Schema = "Profile")]
public class Follower : EntityBase
{
    public Guid? UserId { get; set; }
    public Guid? FollowingUserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public User User { get; set; }
    [ForeignKey(nameof(FollowingUserId))]
    public User FollowingUser { get; set; }
}