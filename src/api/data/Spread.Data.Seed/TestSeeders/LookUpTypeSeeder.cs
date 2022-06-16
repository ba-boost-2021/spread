using Microsoft.EntityFrameworkCore;
using Spread.Entities.Main;

namespace Spread.Data.Seed.TestSeeders;

public class LookUpTypeSeeder : ITestSeeder
{
    public void Seed(DbContext dbContext)
    {
        dbContext.Set<LookupType>().AddRange(
            new LookupType
            {
                Name = "Test LookupType",
                CreatedAt = DateTime.UtcNow,
                ModifiedAt = DateTime.UtcNow,
                IsActive = true,
            },
            new LookupType
            {
                Id = new Guid("00000000-0000-0000-0000-000000000001"),
                Name = "Test LookupType2",
                CreatedAt = DateTime.UtcNow,
                ModifiedAt = DateTime.UtcNow,
                IsActive = true,
            });

    }

}