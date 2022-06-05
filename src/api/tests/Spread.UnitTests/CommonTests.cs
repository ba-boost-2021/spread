using NUnit.Framework;
using Spread.Common;
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
    }
}