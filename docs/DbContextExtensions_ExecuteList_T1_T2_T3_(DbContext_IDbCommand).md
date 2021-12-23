### [RobertsDbContextExtensions](RobertsDbContextExtensions 'RobertsDbContextExtensions').[DbContextExtensions](DbContextExtensions 'RobertsDbContextExtensions.DbContextExtensions')
## DbContextExtensions.ExecuteList&lt;T1,T2,T3&gt;(DbContext, IDbCommand) Method
Execute the provided command and return a tuple of the 
first three result sets mapped to lists.
```csharp
public static (System.Collections.Generic.IList<T1>,System.Collections.Generic.IList<T2>,System.Collections.Generic.IList<T3>) ExecuteList<T1,T2,T3>(this Microsoft.EntityFrameworkCore.DbContext ctx, System.Data.IDbCommand cmd);
```
#### Type parameters
<a name='RobertsDbContextExtensions_DbContextExtensions_ExecuteList_T1_T2_T3_(Microsoft_EntityFrameworkCore_DbContext_System_Data_IDbCommand)_T1'></a>
`T1`  
The type the first result set should be mapped to.
  
<a name='RobertsDbContextExtensions_DbContextExtensions_ExecuteList_T1_T2_T3_(Microsoft_EntityFrameworkCore_DbContext_System_Data_IDbCommand)_T2'></a>
`T2`  
The type the second result set should be mapped to.
  
<a name='RobertsDbContextExtensions_DbContextExtensions_ExecuteList_T1_T2_T3_(Microsoft_EntityFrameworkCore_DbContext_System_Data_IDbCommand)_T3'></a>
`T3`  
The type the third result set should be mapped to.
  
#### Parameters
<a name='RobertsDbContextExtensions_DbContextExtensions_ExecuteList_T1_T2_T3_(Microsoft_EntityFrameworkCore_DbContext_System_Data_IDbCommand)_ctx'></a>
`ctx` [Microsoft.EntityFrameworkCore.DbContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.EntityFrameworkCore.DbContext 'Microsoft.EntityFrameworkCore.DbContext')  
The DbContext to execute the command on.
  
<a name='RobertsDbContextExtensions_DbContextExtensions_ExecuteList_T1_T2_T3_(Microsoft_EntityFrameworkCore_DbContext_System_Data_IDbCommand)_cmd'></a>
`cmd` [System.Data.IDbCommand](https://docs.microsoft.com/en-us/dotnet/api/System.Data.IDbCommand 'System.Data.IDbCommand')  
The command to be executed.
  
#### Returns
[&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')[System.Collections.Generic.IList&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[T1](DbContextExtensions_ExecuteList_T1_T2_T3_(DbContext_IDbCommand)#RobertsDbContextExtensions_DbContextExtensions_ExecuteList_T1_T2_T3_(Microsoft_EntityFrameworkCore_DbContext_System_Data_IDbCommand)_T1 'RobertsDbContextExtensions.DbContextExtensions.ExecuteList&lt;T1,T2,T3&gt;(Microsoft.EntityFrameworkCore.DbContext, System.Data.IDbCommand).T1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[,](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')[System.Collections.Generic.IList&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[T2](DbContextExtensions_ExecuteList_T1_T2_T3_(DbContext_IDbCommand)#RobertsDbContextExtensions_DbContextExtensions_ExecuteList_T1_T2_T3_(Microsoft_EntityFrameworkCore_DbContext_System_Data_IDbCommand)_T2 'RobertsDbContextExtensions.DbContextExtensions.ExecuteList&lt;T1,T2,T3&gt;(Microsoft.EntityFrameworkCore.DbContext, System.Data.IDbCommand).T2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[,](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')[System.Collections.Generic.IList&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[T3](DbContextExtensions_ExecuteList_T1_T2_T3_(DbContext_IDbCommand)#RobertsDbContextExtensions_DbContextExtensions_ExecuteList_T1_T2_T3_(Microsoft_EntityFrameworkCore_DbContext_System_Data_IDbCommand)_T3 'RobertsDbContextExtensions.DbContextExtensions.ExecuteList&lt;T1,T2,T3&gt;(Microsoft.EntityFrameworkCore.DbContext, System.Data.IDbCommand).T3')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')  
A tuple, with each value be the corresponding mapping of a result set.
#### See Also
- [ExecuteList&lt;T&gt;(DbContext, IDbCommand)](DbContextExtensions_ExecuteList_T_(DbContext_IDbCommand) 'RobertsDbContextExtensions.DbContextExtensions.ExecuteList&lt;T&gt;(Microsoft.EntityFrameworkCore.DbContext, System.Data.IDbCommand)')
- [ExecuteList&lt;T1,T2&gt;(DbContext, IDbCommand)](DbContextExtensions_ExecuteList_T1_T2_(DbContext_IDbCommand) 'RobertsDbContextExtensions.DbContextExtensions.ExecuteList&lt;T1,T2&gt;(Microsoft.EntityFrameworkCore.DbContext, System.Data.IDbCommand)')
- [ExecuteList&lt;T1,T2,T3&gt;(DbContext, IDbCommand)](DbContextExtensions_ExecuteList_T1_T2_T3_(DbContext_IDbCommand) 'RobertsDbContextExtensions.DbContextExtensions.ExecuteList&lt;T1,T2,T3&gt;(Microsoft.EntityFrameworkCore.DbContext, System.Data.IDbCommand)')
- [ExecuteList&lt;T1,T2,T3,T4&gt;(DbContext, IDbCommand)](DbContextExtensions_ExecuteList_T1_T2_T3_T4_(DbContext_IDbCommand) 'RobertsDbContextExtensions.DbContextExtensions.ExecuteList&lt;T1,T2,T3,T4&gt;(Microsoft.EntityFrameworkCore.DbContext, System.Data.IDbCommand)')
- [ExecuteList&lt;T1,T2,T3,T4,T5&gt;(DbContext, IDbCommand)](DbContextExtensions_ExecuteList_T1_T2_T3_T4_T5_(DbContext_IDbCommand) 'RobertsDbContextExtensions.DbContextExtensions.ExecuteList&lt;T1,T2,T3,T4,T5&gt;(Microsoft.EntityFrameworkCore.DbContext, System.Data.IDbCommand)')
- [ExecuteList&lt;T1,T2,T3,T4,T5,T6&gt;(DbContext, IDbCommand)](DbContextExtensions_ExecuteList_T1_T2_T3_T4_T5_T6_(DbContext_IDbCommand) 'RobertsDbContextExtensions.DbContextExtensions.ExecuteList&lt;T1,T2,T3,T4,T5,T6&gt;(Microsoft.EntityFrameworkCore.DbContext, System.Data.IDbCommand)')
