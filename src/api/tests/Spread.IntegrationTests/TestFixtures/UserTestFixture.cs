using NUnit.Framework;
using Spread.Data.Requests.Contracts;
using Spread.Test.Common;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spread.IntegrationTests.TestFixtures
{
    [TestFixture]
    public class UserTestFixture : IntegrationTestBase
    {
        [SetUp]
        public Task Setup()
        {
            return Login("admin");
        }

        [Test]
        [Order(1)]
        public async Task ICan_List_Users()
        {
            var result = await Api.Get<List<UserListDto>>("api/management/user/list");
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(5));
            Assert.That(result.First().EMail, Is.EqualTo("admin@spread.com"));
            Assert.That(result.Last().EMail, Is.EqualTo("test2@spread.com"));
        }
    }
}