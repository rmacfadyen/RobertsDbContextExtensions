## RobertsDbContextExtensions Namespace
The original inspiration for these extensions came from ADO.NET's ExecuteScalar(..) method.
It was clear that with a little generic magic it could have been so much easier to use.
The same for constructing command objects, just so many of the same steps repeated over
and over.Data tables are also fairly pondorous, especially when a simple IList<T> would
be so much easier to deal with.

| Classes | |
| :--- | :--- |
| [ExtensionsForCreateCommand](ExtensionsForCreateCommand 'RobertsDbContextExtensions.ExtensionsForCreateCommand') | Provides several extension methods relating to IDbCommands  |
| [ExtensionsForExecuteDynamicList](ExtensionsForExecuteDynamicList 'RobertsDbContextExtensions.ExtensionsForExecuteDynamicList') | Extensions that load a lists that includes dynamic columns. The key concept behind ExecuteDynamicList is where the list of fields retrived by the query can vary at runtime. Because the list is dynamic at runtime a simple POCO class by itself isn't sufficient.  To solve the problem ExecuteDynamicList relies on the POCO containing a plain array of object values. For example:  |
| [ExtensionsForExecuteList](ExtensionsForExecuteList 'RobertsDbContextExtensions.ExtensionsForExecuteList') | Extensions that load lists from an IDbCommand  |
| [ExtensionsForExecuteNonQuery](ExtensionsForExecuteNonQuery 'RobertsDbContextExtensions.ExtensionsForExecuteNonQuery') | DbContextExtension provides several convience methods based on classic ADO.NET.  |
| [ExtensionsForExecuteScalar](ExtensionsForExecuteScalar 'RobertsDbContextExtensions.ExtensionsForExecuteScalar') | ExecuteScalar extension methods   |
| [ExtensionsForExecuteStream](ExtensionsForExecuteStream 'RobertsDbContextExtensions.ExtensionsForExecuteStream') | ADO.NET supports efficient reading of BLOB data by using the CommandBehavior.SequentialAccess flag. By wrapping the returned IDataReader in a slim readonly stream you can read and process a BLOB without loading it entirely into memory.   Perfect when dealing with files that have been stored in a database  and need to be beamed down to a client (eg. browser).  |
