using Microsoft.EntityFrameworkCore;
using RobertsDbContextExtensionsTests.Models;
using System;

namespace RobertsDbContextExtensionsTests.Fixtures
{
    public class TestDbContextFixture : IDisposable
    {
        public void Dispose()
        {

        }

        public TestDbContext CreateDbContext()
        {
            var builder = new DbContextOptionsBuilder<TestDbContext>();
            builder.UseSqlServer(@"Server=(LocalDB)\MSSQLLocalDB;Integrated Security=SSPI;Initial Catalog=testdb");

            return new TestDbContext(builder.Options);
        }

        static TestDbContextFixture()
        {
            var builder = new DbContextOptionsBuilder<TestDbContext>();
            builder.UseSqlServer(@"Server=(LocalDB)\MSSQLLocalDB;Integrated Security=SSPI;Initial Catalog=testdb");

            var ctx = new TestDbContext(builder.Options);

            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
        }
    }
}
