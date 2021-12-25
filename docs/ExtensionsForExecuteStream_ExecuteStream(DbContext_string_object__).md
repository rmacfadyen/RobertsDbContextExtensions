### [RobertsDbContextExtensions](RobertsDbContextExtensions 'RobertsDbContextExtensions').[ExtensionsForExecuteStream](ExtensionsForExecuteStream 'RobertsDbContextExtensions.ExtensionsForExecuteStream')
## ExtensionsForExecuteStream.ExecuteStream(DbContext, string, object[]) Method
Execute the provided SQL and return a stream from the database. This is
indended for accessing BLOBs stored in the database efficiently.
```csharp
public static System.IO.Stream ExecuteStream(this Microsoft.EntityFrameworkCore.DbContext ctx, string Sql, params object[] Parameters);
```
#### Parameters
<a name='RobertsDbContextExtensions_ExtensionsForExecuteStream_ExecuteStream(Microsoft_EntityFrameworkCore_DbContext_string_object__)_ctx'></a>
`ctx` [Microsoft.EntityFrameworkCore.DbContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.EntityFrameworkCore.DbContext 'Microsoft.EntityFrameworkCore.DbContext')  
The DbContext to execute the SQL on.
  
<a name='RobertsDbContextExtensions_ExtensionsForExecuteStream_ExecuteStream(Microsoft_EntityFrameworkCore_DbContext_string_object__)_Sql'></a>
`Sql` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The SQL to be executed.
  
<a name='RobertsDbContextExtensions_ExtensionsForExecuteStream_ExecuteStream(Microsoft_EntityFrameworkCore_DbContext_string_object__)_Parameters'></a>
`Parameters` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
A list of values to be passed as parameters. See [Passing parameters](https://github.com/rmacfadyen/RobertsDbContextExtensions/blob/master/Parameters.md 'https://github.com/rmacfadyen/RobertsDbContextExtensions/blob/master/Parameters.md')
  
#### Returns
[System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')  
A stream that reads directly from the database.
