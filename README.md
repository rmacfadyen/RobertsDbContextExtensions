## Robert's DbContext Extensions

If you just need to load some data from a database server into
a plain old C# object then you're in the right place.

Here's how you would read a single record from a Customer table:

```C#
using Microsoft.EntityFrameworkCore;
using RobertsDbContextExtensions;
using System.Collections.Generic;

namespace SampleCode
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
                where CustomerId = @CustomerId";
            return ctx.ExecuteScalar<Customer>(Sql, new { CustomerId });
        }
    }
}
```

There are a few points of interest:

- The mapping of columns from a query's result set to a POCO object is done by matching the column names to the property names (must be properties, can't be fields)
- Parameter passing can be done in several ways, and what's shown here is a simple anonymous class who's properties are mapped to parameter names.
- To keep things quick, object creation and property assignment are done using cached dynamically compiled lambdas. See FastActivator.cs for fast class instantion and FastPropertySetter.cs for fast property assignments.
- Result set columns without a matching property are ignored. Properties without a matching result set column are initialize to their default value.
- Data type mismatches between the result set and the POCO will throw exceptions (if the database returns a datetime column it can't be stuffed into a bool property).
 
If instead of a single customer you need multiple it would look like:

```c#
    public IList<Customer> GetMatchingCustomers(string Phrase)
    {
        var Sql =
            @"select CustomerId, CustomerName
            from Customers    
            where CustomerName like @Phrase";
        return ctx.ExecuteList<Customer>(Sql, new { Phrase });
    }
```

The extension methods can also handle primitive values just as easily:

```c#
    public Customer GetNumberOfCustomers()
    {
        var Sql = "select count(*) from Customers";
        return ctx.ExecuteScalar<int>(Sql);
    }

    public Customer GetCustomerNames()
    {
        var Sql = "select CustomerName from Customers";
        return ctx.ExecuteList<string>(Sql);
    }
```

And it gets better. If you need to return multiple lists, up to 6, from a single
query you can:
```c#
    public (IList<Customer> Good, IList<Customer> Bad) GetGoodAndBadCustomer()
    {
        var Sql = 
            @"select CustomerId, CustomerName from Customers where Good = 1
            select CustomerId, CustomerName from Customers where Good <> 1";
        return ctx.ExecuteList<Customer, Customer>(Sql);
    }
```



You can review the [class documentation](https://rmacfadyen.github.io/RobertsDbContextExtensions/docs/DbContextExtensions).


Adds the following extension methods to DbContext

CreateCommand - Convinence method to create a IDbCommand object

ExecuteNonQuery - Executes SQL and returns number of rows affected
ExecuteList<T> - Loads a list of values from the database, up to 6 lists (T1..T6)
ExecuteScalar<T> - Executes SQL and returns the single value
ExecuteScalarStream - Executes SQL and returns a Stream 

ExecuteDynamicList<T> - Executes SQL and returns a list of T's with additional columns in an object[]
ExecuteDynamicList - Executes SQL and returns a list of objects with additional columns in an object[], and additional object lists

LoadDataTable - Loads a classic ADO.NET datatable
LoadDataset - Loads a classic ADO.NET datatable
LoadDataset<T1, T2> - Loads a list of T1's each with a list of T2 child rows