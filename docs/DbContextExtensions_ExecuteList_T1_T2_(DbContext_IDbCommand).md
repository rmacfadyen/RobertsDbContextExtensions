### [RobertsDbContextExtensions](RobertsDbContextExtensions 'RobertsDbContextExtensions').[DbContextExtensions](DbContextExtensions 'RobertsDbContextExtensions.DbContextExtensions')
## DbContextExtensions.ExecuteList&lt;T1,T2&gt;(DbContext, IDbCommand) Method
Execute the provided command and return a tuple of the   
first two result sets mapped to lists.  
```csharp
public static (System.Collections.Generic.IList<T1>,System.Collections.Generic.IList<T2>) ExecuteList<T1,T2>(this Microsoft.EntityFrameworkCore.DbContext ctx, System.Data.IDbCommand cmd);
```
#### Type parameters
<a name='RobertsDbContextExtensions_DbContextExtensions_ExecuteList_T1_T2_(Microsoft_EntityFrameworkCore_DbContext_System_Data_IDbCommand)_T1'></a>
`T1`  
  
<a name='RobertsDbContextExtensions_DbContextExtensions_ExecuteList_T1_T2_(Microsoft_EntityFrameworkCore_DbContext_System_Data_IDbCommand)_T2'></a>
`T2`  
  
#### Parameters
<a name='RobertsDbContextExtensions_DbContextExtensions_ExecuteList_T1_T2_(Microsoft_EntityFrameworkCore_DbContext_System_Data_IDbCommand)_ctx'></a>
`ctx` [Microsoft.EntityFrameworkCore.DbContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.EntityFrameworkCore.DbContext 'Microsoft.EntityFrameworkCore.DbContext')  
  
<a name='RobertsDbContextExtensions_DbContextExtensions_ExecuteList_T1_T2_(Microsoft_EntityFrameworkCore_DbContext_System_Data_IDbCommand)_cmd'></a>
`cmd` [System.Data.IDbCommand](https://docs.microsoft.com/en-us/dotnet/api/System.Data.IDbCommand 'System.Data.IDbCommand')  
  
#### Returns
[&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')[System.Collections.Generic.IList&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[T1](DbContextExtensions_ExecuteList_T1_T2_(DbContext_IDbCommand)#RobertsDbContextExtensions_DbContextExtensions_ExecuteList_T1_T2_(Microsoft_EntityFrameworkCore_DbContext_System_Data_IDbCommand)_T1 'RobertsDbContextExtensions.DbContextExtensions.ExecuteList&lt;T1,T2&gt;(Microsoft.EntityFrameworkCore.DbContext, System.Data.IDbCommand).T1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[,](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')[System.Collections.Generic.IList&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[T2](DbContextExtensions_ExecuteList_T1_T2_(DbContext_IDbCommand)#RobertsDbContextExtensions_DbContextExtensions_ExecuteList_T1_T2_(Microsoft_EntityFrameworkCore_DbContext_System_Data_IDbCommand)_T2 'RobertsDbContextExtensions.DbContextExtensions.ExecuteList&lt;T1,T2&gt;(Microsoft.EntityFrameworkCore.DbContext, System.Data.IDbCommand).T2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')  