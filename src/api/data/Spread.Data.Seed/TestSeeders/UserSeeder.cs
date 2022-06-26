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
                FullName = "Test 1",
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
                FullName = "Test 2",
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
                FullName = "Can Perk",
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
                FullName = "Esengül",
                Password = "1234",
                PasswordHash = "2",
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
                IsActive = true
            });
    }
}
