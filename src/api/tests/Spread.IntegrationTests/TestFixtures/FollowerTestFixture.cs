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
            return Login("test1");
        }

        [Test]
        [Order(1)]
        public async Task ICan_List_Followers()
        {
            var result = await Api.Get<List<FollowerListDto>>("api/public/follower/followers");
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(6));
            Assert.That(result.Any(x => x.UserName == "test2"), Is.True);
            Assert.That(result.Any(x => x.UserName == "esengul"), Is.True);
            Assert.That(result.Any(x => x.UserName == "canperk"), Is.True);
        }

        [Test]
        [Order(1)]
        public async Task ICan_List_Follow_Request()
        {
            var result = await Api.Get<List<FollowerListDto>>("api/public/follower/requests");
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(6));
            Assert.That(result.First().UserName, Is.EqualTo("test1"));     //mete userName'i gelmiyor.Null geliyordu.
        }
    }
}