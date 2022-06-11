using Microsoft.EntityFrameworkCore;

namespace Spread.Data.Seed;

public interface ITestSeeder
{
    void Seed(DbContext dbContext);
}
