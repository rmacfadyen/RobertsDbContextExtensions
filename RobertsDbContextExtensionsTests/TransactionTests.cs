using RobertsDbContextExtensions;
using RobertsDbContextExtensionsTests.Fixtures;
using RobertsDbContextExtensionsTests.Models;
using Xunit;


namespace RobertsDbContextExtensionsTests
{
    /// <summary>
    /// These tests show that ctx.CreateCommand(..) correctly enrolls
    /// new commands in an existing transaction
    /// </summary>
    public class TransactionTests : IClassFixture<TestDbContextFixture>
    {
        TestDbContext ctx;

        public TransactionTests(TestDbContextFixture testDbContextFixture)
        {
            this.ctx = testDbContextFixture.CreateDbContext();
        }

        /// <summary>
        /// This test shows that if there is an active transaction the command
        /// is actually enrolled in the transaction
        /// </summary>
        [Fact]
        public void TransactionAddedToCommand()
        {
            // 
            // Start a db transaction
            //
            var txn = ctx.Database.BeginTransaction();
            
            //
            // Create a command and check it has a transaction
            //
            var cmd = ctx.CreateCommand("insert into TableTwo (TwoId, OneId, FieldOne) values (99, 99, 'z')");
            Assert.NotNull(cmd.Transaction);

            //
            // Update teh db
            //
            cmd.ExecuteNonQuery();

            //
            // Check the update occurred
            //
            var n = ctx.ExecuteScalar<int>("select count(*) from TableTwo where TwoId = 99");
            Assert.Equal(1, n);

            //
            // Undo the transaction
            //
            txn.Rollback();

            //
            // Check the update was undone
            //
            var n2 = ctx.ExecuteScalar<int>("select count(*) from TableTwo where TwoId = 99");
            Assert.Equal(0, n2);
        }
    }
}
