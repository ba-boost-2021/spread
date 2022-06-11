using Microsoft.EntityFrameworkCore;
using Spread.Entities.Profile;

namespace Spread.Data.Seed.TestSeeders;

public class UserSeeder : ITestSeeder
{
    public void Seed(DbContext dbContext)
    {
        dbContext.Set<User>().AddRange(
            new User
            {
                UserName = "test1",
                EMail = "test1@spread.com",
                Password = "1234",
                PasswordHash = "2",
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
                IsActive = true
            },
            new User
            {
                UserName = "test2",
                EMail = "test2@spread.com",
                Password = "1234",
                PasswordHash = "2",
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
                IsActive = true
            },
            new User
            {
                UserName = "canperk",
                EMail = "canperk@spread.com",
                Password = "1234",
                PasswordHash = "2",
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
                IsActive = true
            },
            new User
            {
                UserName = "esengul",
                EMail = "esengul@spread.com",
                Password = "1234",
                PasswordHash = "2",
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
                IsActive = true
            });
    }
}
