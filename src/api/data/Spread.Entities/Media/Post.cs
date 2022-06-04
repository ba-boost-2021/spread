﻿using Spread.Entities.Profile;

namespace Spread.Entities.Media;

[Table("Posts", Schema = "Media")]
public class Post : EntityBase
{
    [Required]
    public Guid UserId { get; set; }
    [Required]
    [MaxLength(256)]
    public string Content { get; set; }
    public DateTime? ExpireDate { get; set; }
    public DateTime? ActivatinDate { get; set; }

    [ForeignKey(nameof(UserId))]
    public User User { get; set; }

    public ICollection<Like> Likes { get; set; }
    public ICollection<Comment> Comments { get; set; }
}