using RobertsDbContextExtensions;
using RobertsDbContextExtensionsTests.Fixtures;
using RobertsDbContextExtensionsTests.Models;
using Xunit;

namespace RobertsDbContextExtensionsTests
{
    /// <summary>
    /// Classic ADODB DataTables are awful things. At first they seem
    /// fine, it's only after you've got dozens and dozens of them that
    /// they become problematic (errors from schema changes become tough).
    /// 
    /// BUT... if you're migrating code from DataTables to EFCore and/or
    /// plain POCO queries then LoadData is a nice bridge.
    /// </summary>
    public class LoadDataTable : IClassFixture<TestDbContextFixture>
    {
        TestDbContext ctx;

        public LoadDataTable(TestDbContextFixture testDbContextFixture)
        {
            this.ctx = testDbContextFixture.CreateDbContext();
        }

        /// <summary>
        /// This test shows that loading a datatable from an SQL string works
        /// </summary>
        [Fact]
        public void LoadTable()
        {
            var dt = ctx.LoadDataTable("select * from TableTwo");
            Assert.NotNull(dt);
            Assert.NotEqual(0, dt.Rows.Count);
        }

        /// <summary>
        /// This test shows that loading a datatable from a command works
        /// </summary>
        [Fact]
        public void LoadTableCmd()
        {
            var cmd = ctx.CreateCommand("select * from TableTwo");
            var dt = ctx.LoadDataTable(cmd);
            Assert.NotNull(dt);
            Assert.NotEqual(0, dt.Rows.Count);
        }
    }
}
