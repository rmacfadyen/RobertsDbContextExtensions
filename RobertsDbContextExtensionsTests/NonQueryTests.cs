using RobertsDbContextExtensions;
using RobertsDbContextExtensionsTests.Fixtures;
using RobertsDbContextExtensionsTests.Models;
using Xunit;

namespace RobertsDbContextExtensionsTests
{
    /// <summary>
    /// ExecuteNonQuery is very useful. If you need to update data,
    /// insert data, delete data or do anything other than SELECT
    /// then ExecuteNonQuery is your very best friend. These tests
    /// show that the number of rows affected are returned correctly
    /// and that the commands are correctly executed.
    /// </summary>
    public class NonQueryTests : IClassFixture<TestDbContextFixture>
    {
        TestDbContext ctx;

        public NonQueryTests(TestDbContextFixture testDbContextFixture)
        {
            this.ctx = testDbContextFixture.CreateDbContext();
        }

        /// <summary>
        /// This test shows that ExecutingNonQuery of an SQL string will 
        /// affect the database and return the number of rows affected.
        /// </summary>
        [Fact]
        public void InsertTest()
        {
            string Sql = "insert into TableTwo (TwoId, OneId, FieldOne) values (2, 1, @FieldOne)";
            ctx.ExecuteNonQuery(Sql, new { FieldOne = "abc" });

            var n = ctx.ExecuteScalar<int>("select count(*) from TableTwo where TwoId = 2 and FieldOne = 'abc'");
            Assert.Equal(1, n);
        }

        /// <summary>
        /// This test shows that ExecutingNonQuery of a command will affect 
        /// the database and return the number of rows affected.
        /// </summary>
        [Fact]
        public void InsertTestCmd()
        {
            string Sql = "insert into TableTwo (TwoId, OneId, FieldOne) values (3, 1, @FieldOne)";
            var cmd = ctx.CreateCommand(Sql, new { FieldOne = "abce" });
            cmd.ExecuteNonQuery();

            var n = ctx.ExecuteScalar<int>("select count(*) from TableTwo where TwoId = 3 and FieldOne = 'abce'");
            Assert.Equal(1, n);
        }

        /// <summary>
        /// This test shows that SQL will complain mightly about any parameters
        /// that are not specified
        /// </summary>
        [Fact]
        public void InsertTestMissingParameter()
        {
            string Sql = "insert into TableTwo (TwoId, FieldOne) values (2, @FieldOne)";
            Assert.Throws<Microsoft.Data.SqlClient.SqlException>(() => ctx.ExecuteNonQuery(Sql, new { FieldOn = "abc" }));
        }
    }
}
