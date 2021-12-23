using RobertsDbContextExtensions;
using RobertsDbContextExtensionsTests.Fixtures;
using RobertsDbContextExtensionsTests.Models;
using System;
using Xunit;

namespace RobertsDbContextExtensionsTests
{
    public class DbCommandTests : IClassFixture<TestDbContextFixture>
    {
        TestDbContext ctx;

        public DbCommandTests(TestDbContextFixture testDbContextFixture)
        {
            this.ctx = testDbContextFixture.CreateDbContext();
        }


        class ParameterProjection
        {
            public int p0 { get; set; }
            public bool p1 { get; set; }
            public string p2 { get; set; }
            public string p3 { get; set; }
            public decimal p4 { get; set; }
            public float? p5 { get; set; }
            public string p6 { get; set; }
        }

        /// <summary>
        /// This test shows that various native types passed to AddParameterValue are
        /// passed correctly to the database by checking the values are the same after
        /// a round trip
        /// </summary>
        [Fact]
        public void AddParameters()
        {
            object o = null;
            string s = null;

            var cmd = ctx.CreateCommand("select @p0 as p0, @p1 as p1, @p2 as p2, @p3 as p3, @p4 as p4, @p5 as p5, @p6 as p6");
            cmd.AddParameterValue("@p0", 1);
            cmd.AddParameterValue("@p1", true);
            cmd.AddParameterValue("@p2", DBNull.Value);
            cmd.AddParameterValue("@p3", "abc");
            cmd.AddParameterValue("@p4", 17.1m);
            cmd.AddParameterValue("@p5", o);
            cmd.AddParameterValue("@p6", s);

            var p = ctx.ExecuteScalar<ParameterProjection>(cmd);
            Assert.NotNull(p);
            Assert.Equal(1, p.p0);
            Assert.True(p.p1);
            Assert.Null(p.p2);
            Assert.Equal("abc", p.p3);
            Assert.Equal(17.1m, p.p4);
            Assert.Null(p.p5);
            Assert.Null(p.p6);
        }
    }
}
