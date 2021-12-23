### [RobertsDbContextExtensions](RobertsDbContextExtensions 'RobertsDbContextExtensions').[DbContextExtensions](DbContextExtensions 'RobertsDbContextExtensions.DbContextExtensions')
## DbContextExtensions.ExecuteList&lt;T&gt;(DbContext, IDbCommand) Method
Execute the provided command and return the result set mapped to
an IList<T>.
```csharp
public static System.Collections.Generic.IList<T> ExecuteList<T>(this Microsoft.EntityFrameworkCore.DbContext ctx, System.Data.IDbCommand cmd);
```
#### Type parameters
<a name='RobertsDbContextExtensions_DbContextExtensions_ExecuteList_T_(Microsoft_EntityFrameworkCore_DbContext_System_Data_IDbCommand)_T'></a>
`T`  
  
#### Parameters
<a name='RobertsDbContextExtensions_DbContextExtensions_ExecuteList_T_(Microsoft_EntityFrameworkCore_DbContext_System_Data_IDbCommand)_ctx'></a>
`ctx` [Microsoft.EntityFrameworkCore.DbContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.EntityFrameworkCore.DbContext 'Microsoft.EntityFrameworkCore.DbContext')  
  
<a name='RobertsDbContextExtensions_DbContextExtensions_ExecuteList_T_(Microsoft_EntityFrameworkCore_DbContext_System_Data_IDbCommand)_cmd'></a>
`cmd` [System.Data.IDbCommand](https://docs.microsoft.com/en-us/dotnet/api/System.Data.IDbCommand 'System.Data.IDbCommand')  
  
#### Returns
[System.Collections.Generic.IList&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[T](DbContextExtensions_ExecuteList_T_(DbContext_IDbCommand)#RobertsDbContextExtensions_DbContextExtensions_ExecuteList_T_(Microsoft_EntityFrameworkCore_DbContext_System_Data_IDbCommand)_T 'RobertsDbContextExtensions.DbContextExtensions.ExecuteList&lt;T&gt;(Microsoft.EntityFrameworkCore.DbContext, System.Data.IDbCommand).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')  
