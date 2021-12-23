using RobertsDbContextExtensions;
using RobertsDbContextExtensionsTests.Fixtures;
using RobertsDbContextExtensionsTests.Models;
using Xunit;

namespace RobertsDbContextExtensionsTests
{
    /// <summary>
    /// Empty results sets should return empty lists and default
    /// values for scalars.
    /// </summary>
    public class EmptyResultSetTests : IClassFixture<TestDbContextFixture>
    {
        TestDbContext ctx;

        public EmptyResultSetTests(TestDbContextFixture testDbContextFixture)
        {
            this.ctx = testDbContextFixture.CreateDbContext();
        }
        
        /// <summary>
        /// This test shows that an empty resultset returns a list of
        /// primative datatypes with no elements
        /// </summary>
        [Fact]
        public void EmptyResultSetPrimitiveCount()
        {
            var l = ctx.ExecuteList<int>("select OneId from TableOne where 1 = 0");
            Assert.Equal(0, l.Count);
        }

        /// <summary>
        /// This test shows that an empty resultset returns a list of
        /// poco objects with no elements
        /// </summary>
        [Fact]
        public void EmptyResultSetObjectCount()
        {
            var l = ctx.ExecuteList<TableOne>("select * from TableOne where 1 = 0");
            Assert.Equal(0, l.Count);
        }

        /// <summary>
        /// This test shows that an empty result set returns a the default
        /// values for an execute scalar of a primative type
        /// </summary>
        [Fact]
        public void EmptyResultSetPrimitiveValue()
        {
            var l = ctx.ExecuteScalar<int>("select OneId from TableOne where 1 = 0");
            Assert.Equal(0, l);
        }

        /// <summary>
        /// This test shows that an empty result set returns a null
        /// value for an execute scalar of a nullable primative type
        /// </summary>
        [Fact]
        public void EmptyResultSetNullablePrimitiveValue()
        {
            var l = ctx.ExecuteScalar<int?>("select OneId from TableOne where 1 = 0");
            Assert.False(l.HasValue);
        }

        /// <summary>
        /// This test shows that an empty result set returns a null
        /// value for an execute scalar of a poco object
        /// </summary>
        [Fact]
        public void EmptyResultSetObjectValue()
        {
            var l = ctx.ExecuteScalar<TableOne>("select * from TableOne where 1 = 0");
            Assert.Null(l);
        }
    }
}