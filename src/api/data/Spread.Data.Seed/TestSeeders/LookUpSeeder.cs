using Microsoft.EntityFrameworkCore;
using Spread.Entities.Main;

namespace Spread.Data.Seed.TestSeeders;

public class LookUpSeeder : ITestSeeder
{
    public void Seed(DbContext dbContext)
    {
        dbContext.Set<LookUp>().AddRange(
            new LookUp
            {
                Name = "Test Lookup",
                TypeId = ConstantIds.LookupType.CityId,
                CreatedAt = DateTime.UtcNow,
                ModifiedAt = DateTime.UtcNow,
                IsActive = true,
            },
            new LookUp
            {
                Id = new Guid("00000000-0000-0000-0000-000000000001"),
                Name = "Test Lookup2",
                TypeId = ConstantIds.LookupType.CityId,
                CreatedAt = DateTime.UtcNow,
                ModifiedAt = DateTime.UtcNow,
                IsActive = true,
            });
    }
}