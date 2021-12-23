using RobertsDbContextExtensions;
using RobertsDbContextExtensionsTests.Fixtures;
using RobertsDbContextExtensionsTests.Models;
using Xunit;

namespace RobertsDbContextExtensionsTests
{
    public class ExecuteScalarTests : IClassFixture<TestDbContextFixture>
    {
        TestDbContext ctx;

        public ExecuteScalarTests(TestDbContextFixture testDbContextFixture)
        {
            this.ctx = testDbContextFixture.CreateDbContext();
        }

        [Fact]
        public void Scalar1()
        {
            var id = ctx.ExecuteScalar<int>("select top 1 OneId from TableTwo order by OneId");
            Assert.Equal(1, id);

        }
        [Fact]
        public void Scalar2()
        {
            var cmd = ctx.CreateCommand("select top 1 OneId from TableTwo order by OneId");
            var id = ctx.ExecuteScalar<int>(cmd);
            Assert.Equal(1, id);
        }
        [Fact]
        public void Scalar3()
        {
            var cmd = ctx.CreateCommand("select top 1 OneId from TableTwo order by OneId");
            var id = cmd.ExecuteScalar<int>();
            Assert.Equal(1, id);
        }
    }
}
