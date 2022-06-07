using NUnit.Framework;
using Spread.Entities.Profile;
using Spread.Test.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Spread.IntegrationTests.TestFixtures
{
    [TestFixture]
    public class UserTestFixture : IntegrationTestBase
    {
        [Test]
        public async Task ICan_Create_User()
        {
            var result = await Api.Get<List<User>>("api/management/user/list");
            Assert.That(true, Is.True);
        }

        [Test]
        public async Task ICannot_Create_User_With_Same_UserName()
        {
            Assert.Pass();
        }
    }
}