### [RobertsDbContextExtensions](RobertsDbContextExtensions 'RobertsDbContextExtensions').[DbContextExtensions](DbContextExtensions 'RobertsDbContextExtensions.DbContextExtensions')
## DbContextExtensions.CreateCommand(DbContext, string, object[]) Method
Create an DbCommand and populate its parameters (if necesary)  
```csharp
public static System.Data.Common.DbCommand CreateCommand(this Microsoft.EntityFrameworkCore.DbContext ctx, string Sql, params object[] Parameters);
```
#### Parameters
<a name='RobertsDbContextExtensions_DbContextExtensions_CreateCommand(Microsoft_EntityFrameworkCore_DbContext_string_object__)_ctx'></a>
`ctx` [Microsoft.EntityFrameworkCore.DbContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.EntityFrameworkCore.DbContext 'Microsoft.EntityFrameworkCore.DbContext')  
The database connection
  
<a name='RobertsDbContextExtensions_DbContextExtensions_CreateCommand(Microsoft_EntityFrameworkCore_DbContext_string_object__)_Sql'></a>
`Sql` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The SQL text the command will execute
  
<a name='RobertsDbContextExtensions_DbContextExtensions_CreateCommand(Microsoft_EntityFrameworkCore_DbContext_string_object__)_Parameters'></a>
`Parameters` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
The parameters, if any, that should be passed to the SQL.  
            If the first parameter is an IDbTransaction then that is passed to the command  
            as its transaction and not as a parameter.  
            
  
#### Returns
[System.Data.Common.DbCommand](https://docs.microsoft.com/en-us/dotnet/api/System.Data.Common.DbCommand 'System.Data.Common.DbCommand')  
Am initialized DbCommand ready for execution. If a transaction  
            is active the command is enrolled in it.