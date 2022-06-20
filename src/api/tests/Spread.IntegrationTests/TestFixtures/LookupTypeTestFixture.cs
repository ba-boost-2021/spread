using NUnit.Framework;
using Spread.Data.Requests.Contracts;
using Spread.Test.Common;
using System;
using System.Threading.Tasks;

namespace Spread.IntegrationTests.TestFixtures
{
    [TestFixture]
    public class LookupTypeTestFixture : IntegrationTestBase
    {
        [SetUp]
        public Task SetUp()
        {
            return Login("admin");
        }

        [Test]
        [Order(1)]
        public async Task I_Can_Create_LookupType()
        {
            var content = new NewLookupTypeRequestDto
            {
                Name = "Para Birimi"
            };
            var result = await Api.Post<NewLookupTypeRequestDto, bool>("api/management/lookuptype/add", content);
            Assert.That(result, Is.True);
        }

        [TestCase("")]
        [TestCase(null)]
        [Order(2)]
        public async Task I_Cant_Create_LookupType(string name)
        {
            var content = new NewLookupTypeRequestDto
            {
                Name = name
            };
            var result = await Api.Post<NewLookupTypeRequestDto, bool>("api/management/lookuptype/add", content);
            Assert.That(result, Is.False);
        }

        [Test]
        [Order(2)]
        public async Task I_Cant_Create_LookupType_With_Existing_Name()
        {
            var content = new NewLookupTypeRequestDto
            {
                Name = "Test LookupType"
            };
            var result = await Api.Post<NewLookupTypeRequestDto, bool>("api/management/lookuptype/add", content);
            Assert.That(result, Is.False);
        }
        [Test]
        [Order(2)]
        public async Task I_Can_GetById()
        {
            var guid = new Guid("00000000-0000-0000-0000-000000000001");
            var result = await Api.Get<LookupTypeDto>($"api/management/lookuptype/get/{guid}");
            Assert.That(result, Is.Not.Null);
            Assert.That(result.IsActive,Is.True);
            Assert.That(result.Name, Is.EqualTo("Test LookupType2"));
        }
        [Test]
        [Order(2)]
        public async Task ICanNot_Get_LookupType_ById_If_EntityNot_Exists()
        {
            var guid1 = new Guid("a0000000-0000-0000-0000-000000000001");
            var result = await Api.Get<LookupTypeDto>($"api/management/lookuptype/get/{guid1}");
            Assert.IsNull(result);
        }

        [TestCase("00000000-0000-0000-0000-000000000001")]
        [Order(3)]
        public async Task ICan_Delete_LookUpType_ById(Guid id)
        {
            var result = await Api.Delete<bool>($"api/management/lookuptype/delete/{id}");
            Assert.That(result, Is.True);
            var result2 = await Api.Get<LookupTypeDto>($"api/management/lookuptype/get/{id}");
            Assert.IsNull(result2);
        }
    }
}