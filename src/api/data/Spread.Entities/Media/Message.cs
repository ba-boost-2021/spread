namespace Spread.Entities.Media;

[Table("Messages", Schema = "Media")]
public class Message : EntityBase
{
    [Required]
    public Guid SenderId { get; set; }
    [Required]
    public Guid ReceiverId { get; set; }
    [Required]
    [MaxLength(256)]
    public string Content { get; set; }
}
