using NUnit.Framework;
using Spread.Data.Requests.Contracts;
using Spread.Data.Seed;
using Spread.Test.Common;
using System;
using System.Threading.Tasks;

namespace Spread.IntegrationTests.TestFixtures
{
    [TestFixture]
    public class SystemParameterTestFixture : IntegrationTestBase
    {
        [SetUp]
        public Task SetUp()
        {
            return Login("admin");
        }
        [Test]
        public async Task ICan_Create_SystemParameter()
        {
            var content = new NewSystemParameterRequestDto
            {
                Key = "mete",
                Value ="tufan"
            };
            var result = await Api.Post<NewSystemParameterRequestDto, bool>("api/management/systemparameter/add", content);
            Assert.That(result, Is.True);
        }
        [TestCase("key","")]
        [TestCase("","value")]
        [TestCase("","")]
        public async Task ICannot_NullorEmpty_SystemParameter(string key,string value)
        {
            var content = new NewSystemParameterRequestDto
            {
                Key = key,
                Value =value
            };
            var result = await Api.Post<NewSystemParameterRequestDto, bool>("api/management/systemparameter/add", content);
            Assert.That(result, Is.False);
        }
       
      
        [Test]
        public async Task ICannot_SameKey_SystemParameter()
        {
            var content = new NewSystemParameterRequestDto
            {
                Key = "test",
                Value = "test"
            };
            var result = await Api.Post<NewSystemParameterRequestDto, bool>("api/management/systemparameter/add", content);
            Assert.That(result, Is.False);
        }

        [Test]
        public async Task I_Can_Get_SystemParameter_ById()
        {
            var guid = new Guid("00000000-0000-0000-0000-000000000001");
            var result = await Api.Get<SystemParameterDto>($"api/management/systemparameter/get/{guid}");
            Assert.That(result, Is.Not.Null);
            Assert.That(result.IsActive, Is.True);
            Assert.That(result.Key, Is.EqualTo("test2"));
        }
        [Test]
        public async Task ICanNot_Get_SystemParameter_ById()
        {
            var guid1 = new Guid("a0000000-0000-0000-0000-000000000001");
            var result = await Api.Get<SystemParameterDto>($"api/management/systemparameter/get/{guid1}");
            Assert.IsNull(result);
        }
    }
}