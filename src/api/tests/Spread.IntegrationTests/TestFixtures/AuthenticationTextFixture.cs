using NUnit.Framework;
using Spread.Data.Requests.Contracts;
using Spread.Test.Common;
using System.Threading.Tasks;

namespace Spread.IntegrationTests.TestFixtures
{
    [TestFixture]
    public class AuthenticationTextFixture : IntegrationTestBase
    {
        [Test]
        public async Task ICan_Login()
        {
            var request = new LoginRequestDto
            {
                UserName = "admin",
                Password = "123."
            };
            var result = await Api.Post<LoginRequestDto, LoginResultDto>("api/authentication/login", request);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Token, Is.Not.Null);
        }

        [TestCase("admin", "wrongpassword")]
        [TestCase("unknownuser", "password")]
        public async Task ICannot_Login_With_InvalidCredentials(string username, string password)
        {
            var request = new LoginRequestDto
            {
                UserName = username,
                Password = password
            };
            var result = await Api.Post<LoginRequestDto, LoginResultDto>("api/authentication/login", request);
            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task ICan_Create_User()
        {
            var user = new RegisterUserRequestDto
            {
                EMail = "newuser@mail.com",
                UserName = "newuser",
                Password = "qwer"
            };
            var result = await Api.Post<RegisterUserRequestDto, bool>("api/authentication/register", user);
            Assert.That(result, Is.True);
        }

        [Test]
        public async Task ICannot_Create_User_With_Same_Mail()
        {
            var user = new RegisterUserRequestDto
            {
                EMail = "test1@spread.com",
                UserName = "differentusername",
                Password = "qwer"
            };
            var result = await Api.Post<RegisterUserRequestDto, bool>("api/authentication/register", user);
            Assert.That(result, Is.False);
        }

        [Test]
        public async Task ICannot_Create_User_With_Same_UserName()
        {
            var user = new RegisterUserRequestDto
            {
                EMail = "differentmail@spread.com",
                UserName = "test1",
                Password = "qwer"
            };
            var result = await Api.Post<RegisterUserRequestDto, bool>("api/authentication/register", user);
            Assert.That(result, Is.False);
        }
    }
}