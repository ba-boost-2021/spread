namespace Spread.Data.Requests.Contracts;

public class UserListDto
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string EMail { get; set; }
    public bool IsBlocked { get; set; }
    public DateTime? CreatedAt { get; set; }
}
