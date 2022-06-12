using NUnit.Framework;
using Spread.Data.Requests.Contracts;
using Spread.Data.Seed;
using Spread.Test.Common;
using System.Threading.Tasks;

namespace Spread.IntegrationTests.TestFixtures
{
    [TestFixture]
    public class LookupTestFixture : IntegrationTestBase
    {
        [SetUp]
        public Task SetUp()
        {
            return Login("admin");
        }
        [Test]
        public async Task ICan_Create_Lookup()
        {
            var content = new NewLookupRequestDto
            {
                Name = "Kars",
                TypeId = ConstantIds.LookupType.CityId
            };
            var result = await Api.Post<NewLookupRequestDto, bool>("api/management/lookup/add", content);
            Assert.That(result, Is.True);
        }
    }
}