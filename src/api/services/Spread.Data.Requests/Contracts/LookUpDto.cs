namespace Spread.Data.Requests.Contracts;

public class LookUpDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid TypeId { get; set; }
    public string TypeName { get; set; }
    public Guid? ParentId { get; set; }
    public bool IsActive { get; set; }
}