You can review the [class documentation](https://rmacfadyen.github.io/RobertsDbContextExtensions/DbContextExtensions.md).


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