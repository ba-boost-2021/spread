namespace Spread.Entities.Main;

[Table("Lookups", Schema = "Main")]
public class LookUp : EntityBase
{
    [Required]
    [MaxLength(32)]
    public string Name { get; set; }
    [Required]
    public Guid TypeId { get; set; }
    public Guid? ParentId { get; set; }

    [ForeignKey(nameof(TypeId))]
    public LookupType Type { get; set; }

    [ForeignKey(nameof(ParentId))]
    public LookUp Parent { get; set; }
}
