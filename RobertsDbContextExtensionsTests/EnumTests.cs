using RobertsDbContextExtensions;
using RobertsDbContextExtensionsTests.Fixtures;
using RobertsDbContextExtensionsTests.Models;
using System.Linq;
using Xunit;

namespace RobertsDbContextExtensionsTests
{
    /// <summary>
    /// These tests show that enums are correctly read from a result set
    /// </summary>
    public class EnumTests : IClassFixture<TestDbContextFixture>
    {
        TestDbContext ctx;

        public EnumTests(TestDbContextFixture testDbContextFixture)
        {
            this.ctx = testDbContextFixture.CreateDbContext();
        }

        enum Currency
        {
            CAD = 0,
            USD = 1
        }

        class Projection
        {
            public int OneId { get; set; }
            public Currency ChargedIn { get; set; }
        }

        /// <summary>
        /// This test shows that exactly matching strings are converted to enum values correctly
        /// </summary>
        [Fact]
        public void ReadEnumCaseMatches()
        {
            var Sql = "select 1 as OnId, 'USD' as ChargedIn ";
            var l = ctx.ExecuteList<Projection>(Sql);

            Assert.NotEmpty(l);
            Assert.Equal(Currency.USD, l.First().ChargedIn);
        }

        /// <summary>
        /// This test shows that case differences don't affect enum conversion
        /// </summary>
        [Fact]
        public void ReadEnumCaseDoesNotMatch()
        {
            var Sql = "select 1 as OnId, 'uSd' as ChargedIn ";
            var l = ctx.ExecuteList<Projection>(Sql);

            Assert.NotEmpty(l);
            Assert.Equal(Currency.USD, l.First().ChargedIn);
        }

        /// <summary>
        /// This test shows that integers are converted to enums correctly
        /// </summary>
        [Fact]
        public void ReadEnumFromInt()
        {
            var Sql = "select 1 as OnId, 1 as ChargedIn ";
            var l = ctx.ExecuteList<Projection>(Sql);

            Assert.NotEmpty(l);
            Assert.Equal(Currency.USD, l.First().ChargedIn);
        }

        /// <summary>
        /// This test shows that invalid integers are converted as passed (exactly
        /// what happens with native code)
        /// </summary>
        [Fact]
        public void ReadEnumFromIntBig()
        {
            var Sql = "select 1 as OnId, 99 as ChargedIn ";
            var l = ctx.ExecuteList<Projection>(Sql);

            Assert.NotEmpty(l);
            Assert.Equal(99, (int)l.First().ChargedIn);
        }

        /// <summary>
        /// This test shows that exactly matching strings are converted to enum values correctly
        /// </summary>
        [Fact]
        public void ReadEnumInvalid()
        {
            var Sql = "select 1 as OnId, 'XXX' as ChargedIn ";
            Assert.Throws<System.ArgumentException>(() => ctx.ExecuteList<Projection>(Sql));
        }
    }
}
