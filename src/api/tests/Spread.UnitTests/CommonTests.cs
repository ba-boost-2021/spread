using NUnit.Framework;
using Spread.Common;
using Spread.Common.Extensions;
using System.Linq;

namespace Spread.UnitTests
{
    public class CommonTests
    {
        [TestCase(76, 10, 10, 8)]
        [TestCase(80, 10, 10, 8)]
        [TestCase(81, 10, 10, 9)]
        [TestCase(6, 6, 10, 1)]
        [TestCase(0, 0, 10, 1)]

        public void PageSize_IsAlways_Correct(int total, int fetchedItemCount, int pageSize, int pageCount)
        {
            var sut = new PagedList<int>
            {
                Items = Enumerable.Range(1, fetchedItemCount).ToList(),
                TotalCount = total,
                PageSize = pageSize
            };
            Assert.That(sut.PageCount, Is.EqualTo(pageCount));
            Assert.That(sut.ItemCount, Is.EqualTo(fetchedItemCount));
            Assert.That(sut.PageSize, Is.EqualTo(pageSize));
        }

        [TestCase("123", "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3")]
        [TestCase("abc123!", "033b83d92431548e13424903c235a9922af56dd34d53c9b72b37cf158489213e")]
        public void Hash_Algorithm_Returns_SameValue(string password, string result)
        {
            var hash = password.CreateHash();
            Assert.That(hash, Is.EqualTo(result));
        }
    }
}