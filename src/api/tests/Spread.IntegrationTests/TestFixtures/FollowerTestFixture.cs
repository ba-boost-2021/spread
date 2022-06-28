using NUnit.Framework;
using Spread.Data.Requests.Contracts;
using Spread.Test.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spread.IntegrationTests.TestFixtures
{
        [TestFixture]
        public class FollowerTestFixture : IntegrationTestBase
        {
            [SetUp]
            public Task Setup()
            {
                return Login("admin");
            }

            [Test]
            [Order(1)]
            public async Task ICan_List_Followers()
            {
                var result = await Api.Get<List<FollowerListDto>>("api/public/follower/list");
                Assert.That(result, Is.Not.Null);
                Assert.That(result.Count, Is.EqualTo(5));
                Assert.That(result.First().Name, Is.EqualTo(""));
                Assert.That(result.Last().Name, Is.EqualTo(""));
            }
        }
}
