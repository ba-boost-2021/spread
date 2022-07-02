namespace Spread.Data.Requests.Contracts;

public class PostListDto
{
    public Guid Id { get; set; }
    public Guid OwnerId { get; set; }
    public string Content { get; set; }
    public string FileUrl { get; set; }
    public string FileName { get; set; }
    public string OwnerName { get; set; }
    public DateTime PublishDate { get; set; }
    public int LikeCount { get; set; }
    public int CommentCount { get; set; }
}