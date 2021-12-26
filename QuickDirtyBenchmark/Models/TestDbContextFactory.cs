using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace QuickDirtyBenchmark.Models
{
    internal class TestDbContextFactory : IDesignTimeDbContextFactory<TestDbContext>
    {
        public TestDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<TestDbContext>();
            builder.UseSqlServer(@"Server=(LocalDB)\MSSQLLocalDB;Integrated Security=SSPI;Initial Catalog=testdb;");

            return new TestDbContext(builder.Options);
        }
    }
}
