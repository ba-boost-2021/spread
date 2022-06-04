namespace Spread.Entities.Media;

[Table("HashTags", Schema = "Media")]
public class HashTag : EntityBase
{
    [Required]
    [MaxLength(32)]
    public string Name { get; set; }
}