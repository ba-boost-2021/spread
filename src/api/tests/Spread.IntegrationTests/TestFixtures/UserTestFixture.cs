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

        [Test]
        public async Task ICan_Create_User()
        {
            var user = new NewUserDto
            {
                EMail = "newuser@mail.com",
                UserName = "newuser",
                Password = "qwer"
            };
            var result = await Api.Post<NewUserDto, bool>("api/management/user/add", user);
            Assert.That(result, Is.True);
        }

        [Test]
        public async Task ICannot_Create_User_With_Same_Mail()
        {
            var user = new NewUserDto
            {
                EMail = "test1@spread.com",
                UserName = "test1",
                Password = "qwer"
            };
            var result = await Api.Post<NewUserDto, bool>("api/management/user/add", user);
            Assert.That(result, Is.False);
        }

        [Test]
        public async Task ICannot_Create_User_With_Same_UserName()
        {
            Assert.Fail();
        }
    }
}