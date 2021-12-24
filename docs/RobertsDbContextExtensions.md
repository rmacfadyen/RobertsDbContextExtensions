## RobertsDbContextExtensions Namespace
The original inspiration for these extensions came from ADO.NET's ExecuteScalar(..) method.
It was clear that with a little generic magic it could have been so much easier to use.
The same for constructing command objects, just so many of the same steps repeated over
and over.Data tables are also fairly pondorous, especially when a simple IList<T> would
be so much easier to deal with.

| Classes | |
| :--- | :--- |
| [DbContextExtensions](DbContextExtensions 'RobertsDbContextExtensions.DbContextExtensions') | DbContextExtension provides several convience methods based on classic ADO.NET.  |
| [DynamicListExtensions](DynamicListExtensions 'RobertsDbContextExtensions.DynamicListExtensions') | Extensions that load a lists that includes dynamic columns  |
| [IDbCommandExtensions](IDbCommandExtensions 'RobertsDbContextExtensions.IDbCommandExtensions') | Provides several extension methods relating to IDbCommands  |
| [ListFromIDbCommandExtensions](ListFromIDbCommandExtensions 'RobertsDbContextExtensions.ListFromIDbCommandExtensions') | Extensions that load lists from an IDbCommand  |
| [ListFromSqlStringExtensions](ListFromSqlStringExtensions 'RobertsDbContextExtensions.ListFromSqlStringExtensions') | Extensions that load lists from a string of SQL  |
