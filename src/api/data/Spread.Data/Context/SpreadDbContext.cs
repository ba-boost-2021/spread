using Microsoft.EntityFrameworkCore;

namespace Spread.Data.Context;

public class SpreadDbContext : DbContext
{
    public SpreadDbContext(DbContextOptions options) : base(options)
    {
        this.ChangeTracker.LazyLoadingEnabled = false;
    }

    public DbSet<Block> Blocks { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Follower> Followers { get; set; }
    public DbSet<HashTag> HashTags { get; set; }
    public DbSet<Like> Likes { get; set; }
    public DbSet<LookUp> LookUps { get; set; }
    public DbSet<LookupType> LookUpTypes { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<PostHashTag> PostHashTags { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<SystemParameter> SystemParameters { get; set; }
    public DbSet<User> Users { get; set; }
}