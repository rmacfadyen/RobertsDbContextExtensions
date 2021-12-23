using Microsoft.EntityFrameworkCore;
using RobertsDbContextExtensions;

namespace RobertsDbContextExtensionsTests
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
    }

    public class Worker
    {
        private DbContext ctx;
        public Worker(DbContext ctx)
        {
            this.ctx = ctx;
        }

        public Customer GetCustomer(int CustomerId)
        {
            var Sql =
                @"select CustomerId, CustomerName
                from Customers    
                where CustomerId = @CustomerId
                ";
            return ctx.ExecuteScalar<Customer>(Sql, new { CustomerId });
        }
    }
}
