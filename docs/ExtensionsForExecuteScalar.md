### [RobertsDbContextExtensions](RobertsDbContextExtensions 'RobertsDbContextExtensions')
## ExtensionsForExecuteScalar Class
ExecuteScalar extension methods 
```csharp
public static class ExtensionsForExecuteScalar
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ExtensionsForExecuteScalar  

| Methods | |
| :--- | :--- |
| [ExecuteScalar&lt;T&gt;(DbContext, string, object[])](ExtensionsForExecuteScalar_ExecuteScalar_T_(DbContext_string_object__) 'RobertsDbContextExtensions.ExtensionsForExecuteScalar.ExecuteScalar&lt;T&gt;(Microsoft.EntityFrameworkCore.DbContext, string, object[])') | Execute the provided SQL and return the first row of the result set.  |
| [ExecuteScalar&lt;T&gt;(DbContext, IDbCommand)](ExtensionsForExecuteScalar_ExecuteScalar_T_(DbContext_IDbCommand) 'RobertsDbContextExtensions.ExtensionsForExecuteScalar.ExecuteScalar&lt;T&gt;(Microsoft.EntityFrameworkCore.DbContext, System.Data.IDbCommand)') | Execute the provided command and return the first column of the first row of the result set.  |
| [ExecuteScalar&lt;T&gt;(IDbCommand)](ExtensionsForExecuteScalar_ExecuteScalar_T_(IDbCommand) 'RobertsDbContextExtensions.ExtensionsForExecuteScalar.ExecuteScalar&lt;T&gt;(System.Data.IDbCommand)') | Executes the provided command and returns the first column of the first row of the first result set as an T.  |
| [ExecuteScalarStream(DbContext, string, object[])](ExtensionsForExecuteScalar_ExecuteScalarStream(DbContext_string_object__) 'RobertsDbContextExtensions.ExtensionsForExecuteScalar.ExecuteScalarStream(Microsoft.EntityFrameworkCore.DbContext, string, object[])') | Execute the provided SQL and return a stream from the database. This is indended for accessing BLOBs stored in the database efficiently.  |
| [ExecuteScalarStream(IDbCommand)](ExtensionsForExecuteScalar_ExecuteScalarStream(IDbCommand) 'RobertsDbContextExtensions.ExtensionsForExecuteScalar.ExecuteScalarStream(System.Data.IDbCommand)') | Execute the provided command and return a stream from the database. This is indended for accessing BLOBs stored in the database efficiently.  |
