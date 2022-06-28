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
                Id = new Guid("00000000-0000-0000-0000-000000000001"),
                UserName = "test1",
                EMail = "test1@spread.com",
                FullName = "Test 1",
                Password = "bfc39e59a1b59967052a0809eb122f8645d8f85b3f0f86986d5e9528557af3fd",
                PasswordHash = "2",
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
                IsActive = true
            },
            new User
            {
                Id = new Guid("00000000-0000-0000-0000-000000000002"),
                UserName = "test2",
                EMail = "test2@spread.com",
                FullName = "Test 2",
                Password = "123.",
                PasswordHash = "2",
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
                IsActive = true
            },
            new User
            {
                Id = new Guid("00000000-0000-0000-0000-000000000003"),
                UserName = "canperk",
                EMail = "canperk@spread.com",
                FullName = "Can Perk",
                Password = "123.",
                PasswordHash = "2",
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
                IsActive = true
            },
            new User
            {
                Id = new Guid("00000000-0000-0000-0000-000000000004"),
                UserName = "esengul",
                EMail = "esengul@spread.com",
                FullName = "Esengül",
                Password = "123.",
                PasswordHash = "2",
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
                IsActive = true
            },
            new User
            {
                Id = new Guid("00000000-0000-0000-0000-000000000005"),
                UserName = "mete",
                EMail = "mete@spread.com",
                FullName = "Mete",
                Password = "1234",
                PasswordHash = "2",
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
                IsActive = true
            });
    }
}
