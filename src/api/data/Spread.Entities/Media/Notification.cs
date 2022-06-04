using Spread.Common.Enums;
using Spread.Entities.Profile;

namespace Spread.Entities.Media;

[Table("Notifications", Schema = "Media")]
public class Notification : EntityBase
{
    [Required]
    public Guid UserId { get; set; }
    [Required]
    public NotificationType Type { get; set; }
    public Guid ReferenceId { get; set; }

    [ForeignKey(nameof(UserId))]
    public User User { get; set; }
}