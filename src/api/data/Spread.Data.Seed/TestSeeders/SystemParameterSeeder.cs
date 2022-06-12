using Microsoft.EntityFrameworkCore;
using Spread.Entities.Main;
using Spread.Entities.Profile;

namespace Spread.Data.Seed.TestSeeders;

public class SystemParameterSeeder : ITestSeeder
{
    public void Seed(DbContext dbContext)
    {
        dbContext.Set<SystemParameter>().Add(
            new SystemParameter
            {
                Key = "test",
                Value = "test",                
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
                IsActive = true
            });

    }
}
