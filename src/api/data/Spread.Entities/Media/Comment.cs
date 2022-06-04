namespace Spread.Entities.Media;

[Table("Comments", Schema = "Media")]
public class Comment : EntityBase
{
    [Required]
    public Guid PostId { get; set; }

    [ForeignKey(nameof(PostId))]
    public Post Post { get; set; }
}

