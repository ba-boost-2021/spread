namespace Spread.Entities.Media;

[Table("PostHashTags", Schema = "Media")]
public class PostHashTag : EntityBase
{
    [Required]
    public Guid PostId { get; set; }
    [Required]
    public Guid HashTagId { get; set; }

    [ForeignKey(nameof(PostId))]
    public Post Post { get; set; }

    [ForeignKey(nameof(HashTagId))]
    public HashTag HashTag { get; set; }
}