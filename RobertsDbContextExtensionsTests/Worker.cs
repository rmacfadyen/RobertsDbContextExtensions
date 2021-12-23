using Microsoft.EntityFrameworkCore;
using RobertsDbContextExtensions;
using System.Collections.Generic;

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

        public (IList<Customer> Good, IList<Customer> Bad) GetGoodAndBadCustomer()
        {
            var Sql =
                @"select CustomerId, CustomerName from Customers where Good = 1
            select CustomerId, CustomerName from Customers where Good <> 1";
            return ctx.ExecuteList<Customer, Customer>(Sql);
        }

    }
}
