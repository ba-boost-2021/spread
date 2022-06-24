namespace Spread.Data.Requests.Contracts;

public class EditLookupRequestDto
{
    public string Name { get; set; }
    public Guid TypeId { get; set; }
    public Guid? ParentId { get; set; }
}




