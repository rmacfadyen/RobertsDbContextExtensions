using RobertsDbContextExtensions;
using RobertsDbContextExtensionsTests.Fixtures;
using RobertsDbContextExtensionsTests.Models;
using Xunit;

namespace RobertsDbContextExtensionsTests
{
    public class ExecuteListTests : IClassFixture<TestDbContextFixture>
    {
        TestDbContext ctx;

        public ExecuteListTests(TestDbContextFixture testDbContextFixture)
        {
            this.ctx = testDbContextFixture.CreateDbContext();
        }


        [Fact]
        public void StringList()
        {
            var l = ctx.ExecuteList<string>("select FieldOne from TableTwo");
            Assert.NotEmpty(l);
        }

        [Fact]
        public void StringListCmd()
        {
            var cmd = ctx.CreateCommand("select FieldOne from TableTwo");
            var l = ctx.ExecuteList<string>(cmd);
            Assert.NotEmpty(l);
        }

        class SimpleProjection
        {
            public string FieldOne { get; set; }
        }

        [Fact]
        public void OneListsCmd()
        {
            var Sql =
                "select FieldOne from TableTwo; ";
            var cmd = ctx.CreateCommand(Sql);
            var l = ctx.ExecuteList<SimpleProjection>(cmd);
            Assert.NotEmpty(l);
        }

        [Fact]
        public void TwoListsCmd()
        {
            var Sql =
                "select FieldOne from TableTwo; " +
                "select FieldOne from TableTwo ";
            var cmd = ctx.CreateCommand(Sql);
            var l = ctx.ExecuteList<SimpleProjection, SimpleProjection>(cmd);
            Assert.NotEmpty(l.Item1);
            Assert.NotEmpty(l.Item2);
        }

        [Fact]
        public void ThreeListsCmd()
        {
            var Sql =
                "select FieldOne from TableTwo; " +
                "select FieldOne from TableTwo; " +
                "select FieldOne from TableTwo ";
            var cmd = ctx.CreateCommand(Sql);
            var l = ctx.ExecuteList<SimpleProjection, SimpleProjection, SimpleProjection>(cmd);
            Assert.NotEmpty(l.Item1);
            Assert.NotEmpty(l.Item2);
            Assert.NotEmpty(l.Item3);
        }

        [Fact]
        public void FourListsCmd()
        {
            var Sql =
                "select FieldOne from TableTwo; " +
                "select FieldOne from TableTwo; " +
                "select FieldOne from TableTwo; " +
                "select FieldOne from TableTwo ";
            var cmd = ctx.CreateCommand(Sql);
            var l = ctx.ExecuteList<SimpleProjection, SimpleProjection, SimpleProjection, SimpleProjection>(cmd);
            Assert.NotEmpty(l.Item1);
            Assert.NotEmpty(l.Item2);
            Assert.NotEmpty(l.Item3);
            Assert.NotEmpty(l.Item4);
        }
        [Fact]
        public void FiveListsCmd()
        {
            var Sql =
                "select FieldOne from TableTwo; " +
                "select FieldOne from TableTwo; " +
                "select FieldOne from TableTwo; " +
                "select FieldOne from TableTwo; " +
                "select FieldOne from TableTwo ";
            var cmd = ctx.CreateCommand(Sql);
            var l = ctx.ExecuteList<SimpleProjection, SimpleProjection, SimpleProjection, SimpleProjection, SimpleProjection>(cmd);
            Assert.NotEmpty(l.Item1);
            Assert.NotEmpty(l.Item2);
            Assert.NotEmpty(l.Item3);
            Assert.NotEmpty(l.Item4);
            Assert.NotEmpty(l.Item5);
        }
        [Fact]
        public void SixListsCmd()
        {
            var Sql =
                "select FieldOne from TableTwo; " +
                "select FieldOne from TableTwo; " +
                "select FieldOne from TableTwo; " +
                "select FieldOne from TableTwo; " +
                "select FieldOne from TableTwo; " +
                "select FieldOne from TableTwo ";
            var cmd = ctx.CreateCommand(Sql);
            var l = ctx.ExecuteList<SimpleProjection, SimpleProjection, SimpleProjection, SimpleProjection, SimpleProjection, SimpleProjection>(cmd);
            Assert.NotEmpty(l.Item1);
            Assert.NotEmpty(l.Item2);
            Assert.NotEmpty(l.Item3);
            Assert.NotEmpty(l.Item4);
            Assert.NotEmpty(l.Item5);
            Assert.NotEmpty(l.Item6);
        }
        [Fact]
        public void OneListsSql()
        {
            var Sql =
                "select FieldOne from TableTwo; ";
            var l = ctx.ExecuteList<SimpleProjection>(Sql);
            Assert.NotEmpty(l);
        }

            [Fact]
        public void TwoLists()
        {
            var Sql =
                "select FieldOne from TableTwo; " +
                "select FieldOne from TableTwo ";
            var l = ctx.ExecuteList<SimpleProjection, SimpleProjection>(Sql);
            Assert.NotEmpty(l.Item1);
            Assert.NotEmpty(l.Item2);
        }

        [Fact]
        public void ThreeLists()
        {
            var Sql =
                "select FieldOne from TableTwo; " +
                "select FieldOne from TableTwo; " +
                "select FieldOne from TableTwo ";
            var l = ctx.ExecuteList<SimpleProjection, SimpleProjection, SimpleProjection>(Sql);
            Assert.NotEmpty(l.Item1);
            Assert.NotEmpty(l.Item2);
            Assert.NotEmpty(l.Item3);
        }

        [Fact]
        public void FourLists()
        {
            var Sql =
                "select FieldOne from TableTwo; " +
                "select FieldOne from TableTwo; " +
                "select FieldOne from TableTwo; " +
                "select FieldOne from TableTwo ";
            var l = ctx.ExecuteList<SimpleProjection, SimpleProjection, SimpleProjection, SimpleProjection>(Sql);
            Assert.NotEmpty(l.Item1);
            Assert.NotEmpty(l.Item2);
            Assert.NotEmpty(l.Item3);
            Assert.NotEmpty(l.Item4);
        }

        [Fact]
        public void FiveLists()
        {
            var Sql =
                "select FieldOne from TableTwo; " +
                "select FieldOne from TableTwo; " +
                "select FieldOne from TableTwo; " +
                "select FieldOne from TableTwo; " +
                "select FieldOne from TableTwo ";
            var l = ctx.ExecuteList<SimpleProjection, SimpleProjection, SimpleProjection, SimpleProjection, SimpleProjection>(Sql);
            Assert.NotEmpty(l.Item1);
            Assert.NotEmpty(l.Item2);
            Assert.NotEmpty(l.Item3);
            Assert.NotEmpty(l.Item4);
            Assert.NotEmpty(l.Item5);
        }

        [Fact]
        public void SixLists()
        {
            var Sql =
                "select FieldOne from TableTwo; " +
                "select FieldOne from TableTwo; " +
                "select FieldOne from TableTwo; " +
                "select FieldOne from TableTwo; " +
                "select FieldOne from TableTwo; " +
                "select FieldOne from TableTwo ";
            var l = ctx.ExecuteList<SimpleProjection, SimpleProjection, SimpleProjection, SimpleProjection, SimpleProjection, SimpleProjection>(Sql);
            Assert.NotEmpty(l.Item1);
            Assert.NotEmpty(l.Item2);
            Assert.NotEmpty(l.Item3);
            Assert.NotEmpty(l.Item4);
            Assert.NotEmpty(l.Item5);
            Assert.NotEmpty(l.Item6);
        }
    }
}
