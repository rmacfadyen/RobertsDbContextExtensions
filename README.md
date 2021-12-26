## Robert's DbContext Extensions

If you want read data using an Entity Framework Core (EFCore) DbContext 
into arbitrary plain old C# objects (POCO) then you're in the right place.

The original inspiration for these extensions came from ADO.NET's ExecuteScalar(..) method.
It was clear that with a little generic magic it could have been so much easier to use. 
The same for constructing command objects, just so many of the same steps repeated over 
and over. Data tables are also fairly pondorous, especially when a simple IList<T> would
be so much easier to deal with.

These extensions were created to provide breviety, simplicity, conciseness to data access 
using an Entity Framework Core DbContext object.


### Documentation

You can review the [full documentation here](https://rmacfadyen.github.io/RobertsDbContextExtensions/docs/RobertsDbContextExtensions).

### Highlights

- [ExecuteList&lt;T1...T6>](https://rmacfadyen.github.io/RobertsDbContextExtensions/docs/DbContextExtensions_ExecuteList_T_(DbContext_string_object__)) - Loads a list of values from the database, up to 6 lists (T1..T6).
- [ExecuteDynamicList&lt;T>](https://rmacfadyen.github.io/RobertsDbContextExtensions/docs/DbContextExtensions_ExecuteDynamicList_T_(DbContext_string_IEnumerable_string__object__)) - Executes SQL and returns a list of T's with additional columns in an object[] (roughly equivelant of EFCore's shadow properties).
- [ExecuteDynamicList](https://rmacfadyen.github.io/RobertsDbContextExtensions/docs/DbContextExtensions_ExecuteDynamicList(DbContext_IEnumerable_Type__string_IEnumerable_string__object__)) - Executes SQL and returns a list of objects with additional columns in an object[], and additional object lists.
- [ExecuteScalar&lt;T>](https://rmacfadyen.github.io/RobertsDbContextExtensions/docs/DbContextExtensions_ExecuteNonQuery(DbContext_string_object__)) - Executes SQL and returns the first column of the first row of the first result set.
- [ExecuteNonQuery](https://rmacfadyen.github.io/RobertsDbContextExtensions/docs/DbContextExtensions_ExecuteNonQuery(DbContext_string_object__)) - Executes SQL and returns number of rows affected
- [ExecuteStream](https://rmacfadyen.github.io/RobertsDbContextExtensions/docs/DbContextExtensions_ExecuteScalarStream(DbContext_string_object__)) - Executes SQL and returns a Stream directly from the database (great for efficiently retrieving BLOBs).

### IDbCommand helpers
- [CreateCommand(string, params object[])](https://rmacfadyen.github.io/RobertsDbContextExtensions/docs/DbContextExtensions_CreateCommand(DbContext_string_object__)) - Convinence method to create a IDbCommand object
- [AddParameterValue(string, bool)](https://rmacfadyen.github.io/RobertsDbContextExtensions/docs/DbContextExtensions_AddParameterValue(IDbCommand_string_bool)) - Adds a bool parameter to an IDbCommand
- [AddParameterValue(string, string)](https://rmacfadyen.github.io/RobertsDbContextExtensions/docs/DbContextExtensions_AddParameterValue(IDbCommand_string_string)) - Adds a string parameter to an IDbCommand
- [AddParameterValue(string, int)](https://rmacfadyen.github.io/RobertsDbContextExtensions/docs/DbContextExtensions_AddParameterValue(IDbCommand_string_int)) - Adds an int parameter to an IDbCommand
- [AddParameterValue(string, DBNull)](https://rmacfadyen.github.io/RobertsDbContextExtensions/docs/DbContextExtensions_AddParameterValue(IDbCommand_string_DBNull)) - Adds a null value parameter to an IDbCommand
- [AddParameterValue(string, object)](https://rmacfadyen.github.io/RobertsDbContextExtensions/docs/DbContextExtensions_AddParameterValue(IDbCommand_string_object)) - Adds a object parameter to an IDbCommand


### Performance Comparisons

Rigorous performance benchmarking is beyond the scope of this project. The performance
testing undertaken was almost solely as a sanity check. 

That said, here's some numbers (average of 10 runs on an idle development machine against
SQL Express on solid state drives). Three tests were used: reading one random row from
a table of 25, reading 4 random row, and finally reading the entire table of 25 rows. 
See the [QuickDirtyBenchmark](https://github.com/rmacfadyen/RobertsDbContextExtensions/tree/master/QuickDirtyBenchmark) project for precise details.

| Library | Test | Elapsed |
| ------- | ---- | --------------- |
| Dapper  | 1 row | 9.55s | 
| Dapper  | 4 rows | 11.46s | 
| Dapper | 25 rows | 15.20s | 
| EFCore | 1 row | 14.00s | 
| EFCore | 4 rows | 16.89s | 
| EFCore | 25 rows | 17.70s | 
| Roberts | 1 row | 8.07s |
| Roberts | 4 rows | 10.19s |
| Roberts | 25 rows | 16.86s | 

One odd thing stands out... our "25 rows" is 1.62 seconds slower than Dapper. This doesn't make
a lot of sense, especially since the 4 row times we're ahead by 1.27 seconds.

And exceptionally odd is what happens when the tests are run against SQL LocalDB:

| Library | Test | Elapsed |
| ------- | ---- | --------------- |
| Dapper | 1 row | 24.58 |
| Dapper | 4 rows | 26.06 |
| Dapper | 25 rows | 30.22 |
| EFCore | 1 row | 29.70 |
| EFCore | 4 rows | 34.03 |
| EFCore | 25 rows | 34.26 |
| Roberts | 1 row | 7.70 |
| Roberts | 4 rows | 9.52 |
| Roberts | 25 rows | 15.79 |

The times for EFCore and Dapper have more than doubled! But our times have decreased!
**Additional investigation is required**.

The last bit of weirdness is that Dapper would fail with an unexpected exception
when reading uint or ushort. This is an 
[existing Dapper issue](https://github.com/DapperLib/Dapper/issues/1164). 
Switched these to int and short so the test would run.

### Sample Code
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
    public int GetNumberOfCustomers()
    {
        var Sql = "select count(*) from Customers";
        return ctx.ExecuteScalar<int>(Sql);
    }

    public IList<string> GetCustomerNames()
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

Execute arbitrary SQL (to alter a table, delete rows, insert rows, etc):
```c#
    public void AddColumnToCustomerTable()
    {
        var Sql = @"alter table Customers add NewColumn nvarchar(max) not null";
        return ctx.ExecuteNonQuery(Sql);
    }

    public bool DeleteCustomer(int CustomerId)
    {
        var Sql = @"delete from Customers where CustomerId = @CustomerId";
        var RowsAffected = ctx.ExecuteNonQuery(Sql, { CustomerId });
        return RowsAffected <> 0;
    }

    public bool AddCustomer(int CustomerId, string CustomerName)
    {
        var Sql = @"insert into Customers (CustomerId, CustomerName) values (@CustomerId, @CustomerName)";
        var RowsAffected = ctx.ExecuteNonQuery(Sql, { CustomerId, CustomerName });
        return RowsAffected <> 0;
    }
```
