### [RobertsDbContextExtensions](RobertsDbContextExtensions 'RobertsDbContextExtensions')
## ExtensionExecuteScalar Class
ExecuteScalar extension methods 
```csharp
public static class ExtensionExecuteScalar
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ExtensionExecuteScalar  

| Methods | |
| :--- | :--- |
| [ExecuteScalar&lt;T&gt;(DbContext, string, object[])](ExtensionExecuteScalar_ExecuteScalar_T_(DbContext_string_object__) 'RobertsDbContextExtensions.ExtensionExecuteScalar.ExecuteScalar&lt;T&gt;(Microsoft.EntityFrameworkCore.DbContext, string, object[])') | Execute the provided SQL and return the first row of the result set.  |
| [ExecuteScalar&lt;T&gt;(DbContext, IDbCommand)](ExtensionExecuteScalar_ExecuteScalar_T_(DbContext_IDbCommand) 'RobertsDbContextExtensions.ExtensionExecuteScalar.ExecuteScalar&lt;T&gt;(Microsoft.EntityFrameworkCore.DbContext, System.Data.IDbCommand)') | Execute the provided command and return the first column of the first row of the result set.  |
| [ExecuteScalarStream(DbContext, string, object[])](ExtensionExecuteScalar_ExecuteScalarStream(DbContext_string_object__) 'RobertsDbContextExtensions.ExtensionExecuteScalar.ExecuteScalarStream(Microsoft.EntityFrameworkCore.DbContext, string, object[])') | Execute the provided SQL and return a stream from the database. This is indended for accessing BLOBs stored in the database efficiently.  |
