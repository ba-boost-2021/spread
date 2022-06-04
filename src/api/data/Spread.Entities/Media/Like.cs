namespace Spread.Entities.Media;

[Table("Likes", Schema = "Media")]
public class Like : EntityBase
{
    [Required]
    public Guid PostId { get; set; }

    [ForeignKey(nameof(PostId))]
    public Post Post { get; set; }
}

