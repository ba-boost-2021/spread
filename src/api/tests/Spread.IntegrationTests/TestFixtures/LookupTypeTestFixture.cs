﻿using NUnit.Framework;
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
    public class LookupTypeTestFixture : IntegrationTestBase
    {
        [SetUp]
        public Task SetUp()
        {
            return Login("admin");
        }
        [Test]
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
        [TestCase(null)] //veya null yazılabilir.
        public async Task I_Cant_Create_LookupType(string name)
        {
            var content = new NewLookupTypeRequestDto
            {
                Name = name
            };
            var result = await Api.Post<NewLookupTypeRequestDto, bool>("api/management/lookuptype/add", content);
            Assert.That(result, Is.False);
        }
    }
}


