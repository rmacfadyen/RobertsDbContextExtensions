### [RobertsDbContextExtensions](RobertsDbContextExtensions 'RobertsDbContextExtensions').[DbContextExtensions](DbContextExtensions 'RobertsDbContextExtensions.DbContextExtensions')
## DbContextExtensions.ExecuteScalar&lt;T&gt;(DbContext, IDbCommand) Method
Execute the provided command and return the first column of the first row of
the result set.
```csharp
public static T ExecuteScalar<T>(this Microsoft.EntityFrameworkCore.DbContext ctx, System.Data.IDbCommand cmd);
```
#### Type parameters
<a name='RobertsDbContextExtensions_DbContextExtensions_ExecuteScalar_T_(Microsoft_EntityFrameworkCore_DbContext_System_Data_IDbCommand)_T'></a>
`T`  
The type the first result set should be mapped to.
  
#### Parameters
<a name='RobertsDbContextExtensions_DbContextExtensions_ExecuteScalar_T_(Microsoft_EntityFrameworkCore_DbContext_System_Data_IDbCommand)_ctx'></a>
`ctx` [Microsoft.EntityFrameworkCore.DbContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.EntityFrameworkCore.DbContext 'Microsoft.EntityFrameworkCore.DbContext')  
The DbContext to execute the command on.
  
<a name='RobertsDbContextExtensions_DbContextExtensions_ExecuteScalar_T_(Microsoft_EntityFrameworkCore_DbContext_System_Data_IDbCommand)_cmd'></a>
`cmd` [System.Data.IDbCommand](https://docs.microsoft.com/en-us/dotnet/api/System.Data.IDbCommand 'System.Data.IDbCommand')  
The command to be executed.
  
#### Returns
[T](DbContextExtensions_ExecuteScalar_T_(DbContext_IDbCommand)#RobertsDbContextExtensions_DbContextExtensions_ExecuteScalar_T_(Microsoft_EntityFrameworkCore_DbContext_System_Data_IDbCommand)_T 'RobertsDbContextExtensions.DbContextExtensions.ExecuteScalar&lt;T&gt;(Microsoft.EntityFrameworkCore.DbContext, System.Data.IDbCommand).T')  
The value of the first column of the first row of the first result set cast as a T.
