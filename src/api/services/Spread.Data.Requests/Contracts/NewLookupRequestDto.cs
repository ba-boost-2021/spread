namespace Spread.Data.Requests.Contracts;

public class NewLookupRequestDto
{
    public string Name { get; set; }
    public Guid TypeId { get; set; }
    public Guid? ParentId { get; set; }
}




