using NUnit.Framework;
using Spread.Data.Requests.Contracts;
using Spread.Data.Seed;
using Spread.Test.Common;
using System;
using System.Collections.Generic;
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
        [Order(2)]
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
        [Test, Order(1)]
        public async Task ICanNot_Create_Lookup_With_Existing_Name()
        {
            var content = new NewLookupRequestDto
            {
                Name = "Test Lookup",
                TypeId = ConstantIds.LookupType.CityId
            };
            var result = await Api.Post<NewLookupRequestDto, bool>("api/management/lookup/add", content);
            Assert.That(result, Is.False);
        }

        [TestCase("")]
        [TestCase(null)]
        [Order(1)]
        public async Task ICanNot_Create_Lookup_With_EmptyOrNull_Name(string name)
        {
            var content = new NewLookupRequestDto
            {
                Name = name,
                TypeId = ConstantIds.LookupType.CityId
            };
            var result = await Api.Post<NewLookupRequestDto, bool>("api/management/lookup/add", content);
            Assert.That(result, Is.False);
        }
        [Test]
        [Order(1)]
        public async Task ICanGet_Lookup_By_Id()
        {
            var guid1 = new Guid("00000000-0000-0000-0000-000000000001");
            var result = await Api.Get<LookUpDto>($"api/management/lookup/get/{guid1}");
            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.EqualTo(guid1));
            Assert.That(result.Name, Is.EqualTo("Test Lookup2"));
            Assert.That(result.TypeId, Is.EqualTo(ConstantIds.LookupType.CityId));
            Assert.That(result.ParentId, Is.Null);
            Assert.That(result.IsActive, Is.True);
            Assert.That(result.TypeName, Is.EqualTo("Şehir"));
        }
        [Test]
        [Order(1)]
        public async Task ICanNot_Get_Lookup_ById_If_EntityNot_Exists()
        {
            var guid1 = new Guid("a0000000-0000-0000-0000-000000000001");
            var result = await Api.Get<LookUpDto>($"api/management/lookup/get/{guid1}");
            Assert.IsNull(result);
        }
        [Test]
        [Order(1)]
        public async Task ICan_List_Lookups()
        {
            var result = await Api.Get<List<LookUpDto>>("api/management/lookup/list");
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(16));
        }
    }
}