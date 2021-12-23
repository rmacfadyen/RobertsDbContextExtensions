### [RobertsDbContextExtensions](RobertsDbContextExtensions 'RobertsDbContextExtensions').[DbContextExtensions](DbContextExtensions 'RobertsDbContextExtensions.DbContextExtensions')
## DbContextExtensions.ExecuteNonQuery(DbContext, string, object[]) Method
Execute the provided SQL and return the number of rows affected.
```csharp
public static int ExecuteNonQuery(this Microsoft.EntityFrameworkCore.DbContext ctx, string Sql, params object[] Parameters);
```
#### Parameters
<a name='RobertsDbContextExtensions_DbContextExtensions_ExecuteNonQuery(Microsoft_EntityFrameworkCore_DbContext_string_object__)_ctx'></a>
`ctx` [Microsoft.EntityFrameworkCore.DbContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.EntityFrameworkCore.DbContext 'Microsoft.EntityFrameworkCore.DbContext')  
The DbContext to execute the SQL on
  
<a name='RobertsDbContextExtensions_DbContextExtensions_ExecuteNonQuery(Microsoft_EntityFrameworkCore_DbContext_string_object__)_Sql'></a>
`Sql` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The SQL to be executed.
  
<a name='RobertsDbContextExtensions_DbContextExtensions_ExecuteNonQuery(Microsoft_EntityFrameworkCore_DbContext_string_object__)_Parameters'></a>
`Parameters` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
A list of values to be passed as parameters. See [Passing parameters](https://github.com/rmacfadyen/RobertsDbContextExtensions/blob/master/Parameters.md 'https://github.com/rmacfadyen/RobertsDbContextExtensions/blob/master/Parameters.md')
  
#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The number of rows affected. Zero if no rows where affected or if the query wasn't row related (eg. created a table)
