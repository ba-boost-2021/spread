using Microsoft.EntityFrameworkCore;
using Spread.Entities.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spread.Data.Seed.TestSeeders
{
    public class FollowerSeeder : ITestSeeder
    {
        public void Seed(DbContext dbContext)
        {
            dbContext.Set<Follower>().AddRange(
                new Follower
                {
                    UserId = new Guid("00000000-0000-0000-0000-000000000001"),
                    FollowingUserId = new Guid("00000000-0000-0000-0000-000000000002"),
                    IsApproved = true,
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now,
                    IsActive = true,

                },
                new Follower
                {
                    UserId = new Guid("00000000-0000-0000-0000-000000000001"),
                    FollowingUserId = new Guid("00000000-0000-0000-0000-000000000003"),
                    IsApproved = true,
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now,
                    IsActive = true
                },
                new Follower
                {
                    UserId = new Guid("00000000-0000-0000-0000-000000000001"),
                    FollowingUserId = new Guid("00000000-0000-0000-0000-000000000004"),
                    IsApproved = true,
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now,
                    IsActive = true
                },
                new Follower
                {
                    UserId = new Guid("00000000-0000-0000-0000-000000000001"),
                    FollowingUserId = new Guid("00000000-0000-0000-0000-000000000005"),
                    IsApproved = false,
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now,
                    IsActive = true
                },
                new Follower
                {
                    UserId = new Guid("00000000-0000-0000-0000-000000000002"),
                    FollowingUserId = new Guid("00000000-0000-0000-0000-000000000003"),
                    IsApproved = false,
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now,
                    IsActive = true
                },
                new Follower
                {
                    UserId = new Guid("00000000-0000-0000-0000-000000000003"),
                    FollowingUserId = new Guid("00000000-0000-0000-0000-000000000004"),
                    IsApproved = false,
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now,
                    IsActive = true
                });
        }
    }
}
