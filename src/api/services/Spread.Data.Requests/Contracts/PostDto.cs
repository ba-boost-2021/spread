using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Spread.Data.Requests.Contracts;

public class PostDto
{
    [MaxLength(256)]
    [Required]
    public string Content { get; set; }
    [Required]
    public IFormFile File { get; set; }
}
