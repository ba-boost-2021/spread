namespace Spread.Entities.Main;

[Table("Documents", Schema = "Main")]
public class Document : EntityBase
{
    [Required]
    [MaxLength(120)]
    public string FileName { get; set; }
}