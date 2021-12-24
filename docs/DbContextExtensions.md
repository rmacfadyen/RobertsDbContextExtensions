### [RobertsDbContextExtensions](RobertsDbContextExtensions 'RobertsDbContextExtensions')
## DbContextExtensions Class
DbContextExtension provides several convience methods based on
classic ADO.NET.
```csharp
public static class DbContextExtensions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; DbContextExtensions  

| Methods | |
| :--- | :--- |
| [ExecuteNonQuery(DbContext, string, object[])](DbContextExtensions_ExecuteNonQuery(DbContext_string_object__) 'RobertsDbContextExtensions.DbContextExtensions.ExecuteNonQuery(Microsoft.EntityFrameworkCore.DbContext, string, object[])') | Execute the provided SQL and return the number of rows affected.  |
| [ExecuteScalar&lt;T&gt;(DbContext, string, object[])](DbContextExtensions_ExecuteScalar_T_(DbContext_string_object__) 'RobertsDbContextExtensions.DbContextExtensions.ExecuteScalar&lt;T&gt;(Microsoft.EntityFrameworkCore.DbContext, string, object[])') | Execute the provided SQL and return the first row of the result set.  |
| [ExecuteScalar&lt;T&gt;(DbContext, IDbCommand)](DbContextExtensions_ExecuteScalar_T_(DbContext_IDbCommand) 'RobertsDbContextExtensions.DbContextExtensions.ExecuteScalar&lt;T&gt;(Microsoft.EntityFrameworkCore.DbContext, System.Data.IDbCommand)') | Execute the provided command and return the first column of the first row of the result set.  |
| [ExecuteScalarStream(DbContext, string, object[])](DbContextExtensions_ExecuteScalarStream(DbContext_string_object__) 'RobertsDbContextExtensions.DbContextExtensions.ExecuteScalarStream(Microsoft.EntityFrameworkCore.DbContext, string, object[])') | Execute the provided SQL and return a stream from the database. This is indended for accessing BLOBs stored in the database efficiently.  |
