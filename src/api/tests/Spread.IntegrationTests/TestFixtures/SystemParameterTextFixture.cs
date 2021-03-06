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
    public class SystemParameterTestFixture : IntegrationTestBase
    {
        [SetUp]
        public Task SetUp()
        {
            return Login("admin");
        }
        [Test]
        [Order(1)]
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
        [Order(2)]
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
        [Order(2)]
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
        [Order(2)]
        public async Task I_Can_Get_SystemParameter_ById()
        {
            var guid = new Guid("00000000-0000-0000-0000-000000000001");
            var result = await Api.Get<SystemParameterDto>($"api/management/systemparameter/get/{guid}");
            Assert.That(result, Is.Not.Null);
            Assert.That(result.IsActive, Is.True);
            Assert.That(result.Key, Is.EqualTo("test2"));
        }
        [Test]
        [Order(2)]
        public async Task ICanNot_Get_SystemParameter_ById()
        {
            var guid1 = new Guid("a0000000-0000-0000-0000-000000000001");
            var result = await Api.Get<SystemParameterDto>($"api/management/systemparameter/get/{guid1}");
            Assert.IsNull(result);
        }
        [TestCase("00000000-0000-0000-0000-000000000001")]
        [Order(3)]
        public async Task ICan_Delete_SystemParameter_ById(Guid id)
        {
            var result = await Api.Delete<bool>($"api/management/systemparameter/delete/{id}");
            Assert.That(result, Is.True);
            var result2 = await Api.Get<LookupTypeDto>($"api/management/systemparameter/get/{id}");
            Assert.IsNull(result2);
        }
        [Test]
        [Order(1)]
        public async Task ICan_List_LookupTypes()
        {
            var result = await Api.Get<List<SystemParameterDto>>("api/management/systemparameter/list");
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(2));
        }
    }
}