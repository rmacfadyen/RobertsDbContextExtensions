### [RobertsDbContextExtensions](RobertsDbContextExtensions 'RobertsDbContextExtensions').[DbContextExtensions](DbContextExtensions 'RobertsDbContextExtensions.DbContextExtensions')
## DbContextExtensions.ExecuteList&lt;T1,T2,T3,T4&gt;(DbContext, IDbCommand) Method
Execute the provided command and return a tuple of the 
first four result sets mapped to lists.
```csharp
public static (System.Collections.Generic.IList<T1>,System.Collections.Generic.IList<T2>,System.Collections.Generic.IList<T3>,System.Collections.Generic.IList<T4>) ExecuteList<T1,T2,T3,T4>(this Microsoft.EntityFrameworkCore.DbContext ctx, System.Data.IDbCommand cmd);
```
#### Type parameters
<a name='RobertsDbContextExtensions_DbContextExtensions_ExecuteList_T1_T2_T3_T4_(Microsoft_EntityFrameworkCore_DbContext_System_Data_IDbCommand)_T1'></a>
`T1`  
  
<a name='RobertsDbContextExtensions_DbContextExtensions_ExecuteList_T1_T2_T3_T4_(Microsoft_EntityFrameworkCore_DbContext_System_Data_IDbCommand)_T2'></a>
`T2`  
  
<a name='RobertsDbContextExtensions_DbContextExtensions_ExecuteList_T1_T2_T3_T4_(Microsoft_EntityFrameworkCore_DbContext_System_Data_IDbCommand)_T3'></a>
`T3`  
  
<a name='RobertsDbContextExtensions_DbContextExtensions_ExecuteList_T1_T2_T3_T4_(Microsoft_EntityFrameworkCore_DbContext_System_Data_IDbCommand)_T4'></a>
`T4`  
  
#### Parameters
<a name='RobertsDbContextExtensions_DbContextExtensions_ExecuteList_T1_T2_T3_T4_(Microsoft_EntityFrameworkCore_DbContext_System_Data_IDbCommand)_ctx'></a>
`ctx` [Microsoft.EntityFrameworkCore.DbContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.EntityFrameworkCore.DbContext 'Microsoft.EntityFrameworkCore.DbContext')  
  
<a name='RobertsDbContextExtensions_DbContextExtensions_ExecuteList_T1_T2_T3_T4_(Microsoft_EntityFrameworkCore_DbContext_System_Data_IDbCommand)_cmd'></a>
`cmd` [System.Data.IDbCommand](https://docs.microsoft.com/en-us/dotnet/api/System.Data.IDbCommand 'System.Data.IDbCommand')  
  
#### Returns
[&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')[System.Collections.Generic.IList&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[T1](DbContextExtensions_ExecuteList_T1_T2_T3_T4_(DbContext_IDbCommand)#RobertsDbContextExtensions_DbContextExtensions_ExecuteList_T1_T2_T3_T4_(Microsoft_EntityFrameworkCore_DbContext_System_Data_IDbCommand)_T1 'RobertsDbContextExtensions.DbContextExtensions.ExecuteList&lt;T1,T2,T3,T4&gt;(Microsoft.EntityFrameworkCore.DbContext, System.Data.IDbCommand).T1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[,](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')[System.Collections.Generic.IList&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[T2](DbContextExtensions_ExecuteList_T1_T2_T3_T4_(DbContext_IDbCommand)#RobertsDbContextExtensions_DbContextExtensions_ExecuteList_T1_T2_T3_T4_(Microsoft_EntityFrameworkCore_DbContext_System_Data_IDbCommand)_T2 'RobertsDbContextExtensions.DbContextExtensions.ExecuteList&lt;T1,T2,T3,T4&gt;(Microsoft.EntityFrameworkCore.DbContext, System.Data.IDbCommand).T2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[,](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')[System.Collections.Generic.IList&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[T3](DbContextExtensions_ExecuteList_T1_T2_T3_T4_(DbContext_IDbCommand)#RobertsDbContextExtensions_DbContextExtensions_ExecuteList_T1_T2_T3_T4_(Microsoft_EntityFrameworkCore_DbContext_System_Data_IDbCommand)_T3 'RobertsDbContextExtensions.DbContextExtensions.ExecuteList&lt;T1,T2,T3,T4&gt;(Microsoft.EntityFrameworkCore.DbContext, System.Data.IDbCommand).T3')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[,](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')[System.Collections.Generic.IList&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[T4](DbContextExtensions_ExecuteList_T1_T2_T3_T4_(DbContext_IDbCommand)#RobertsDbContextExtensions_DbContextExtensions_ExecuteList_T1_T2_T3_T4_(Microsoft_EntityFrameworkCore_DbContext_System_Data_IDbCommand)_T4 'RobertsDbContextExtensions.DbContextExtensions.ExecuteList&lt;T1,T2,T3,T4&gt;(Microsoft.EntityFrameworkCore.DbContext, System.Data.IDbCommand).T4')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')  
