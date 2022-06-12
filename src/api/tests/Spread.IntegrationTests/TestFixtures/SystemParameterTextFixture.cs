using NUnit.Framework;
using Spread.Data.Requests.Contracts;
using Spread.Data.Seed;
using Spread.Test.Common;
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
    }
}