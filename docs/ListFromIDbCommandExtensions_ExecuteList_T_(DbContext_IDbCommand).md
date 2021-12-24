### [RobertsDbContextExtensions](RobertsDbContextExtensions 'RobertsDbContextExtensions').[ListFromIDbCommandExtensions](ListFromIDbCommandExtensions 'RobertsDbContextExtensions.ListFromIDbCommandExtensions')
## ListFromIDbCommandExtensions.ExecuteList&lt;T&gt;(DbContext, IDbCommand) Method
Execute the provided command and return the result set mapped to
an IList<T>.
```csharp
public static System.Collections.Generic.IList<T> ExecuteList<T>(this Microsoft.EntityFrameworkCore.DbContext ctx, System.Data.IDbCommand cmd);
```
#### Type parameters
<a name='RobertsDbContextExtensions_ListFromIDbCommandExtensions_ExecuteList_T_(Microsoft_EntityFrameworkCore_DbContext_System_Data_IDbCommand)_T'></a>
`T`  
The type the first result set should be mapped to.
  
#### Parameters
<a name='RobertsDbContextExtensions_ListFromIDbCommandExtensions_ExecuteList_T_(Microsoft_EntityFrameworkCore_DbContext_System_Data_IDbCommand)_ctx'></a>
`ctx` [Microsoft.EntityFrameworkCore.DbContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.EntityFrameworkCore.DbContext 'Microsoft.EntityFrameworkCore.DbContext')  
The DbContext to execute the command on.
  
<a name='RobertsDbContextExtensions_ListFromIDbCommandExtensions_ExecuteList_T_(Microsoft_EntityFrameworkCore_DbContext_System_Data_IDbCommand)_cmd'></a>
`cmd` [System.Data.IDbCommand](https://docs.microsoft.com/en-us/dotnet/api/System.Data.IDbCommand 'System.Data.IDbCommand')  
The command to be executed.
  
#### Returns
[System.Collections.Generic.IList&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[T](ListFromIDbCommandExtensions_ExecuteList_T_(DbContext_IDbCommand)#RobertsDbContextExtensions_ListFromIDbCommandExtensions_ExecuteList_T_(Microsoft_EntityFrameworkCore_DbContext_System_Data_IDbCommand)_T 'RobertsDbContextExtensions.ListFromIDbCommandExtensions.ExecuteList&lt;T&gt;(Microsoft.EntityFrameworkCore.DbContext, System.Data.IDbCommand).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')  
The first result set mapped to a list of T's.
#### See Also
- [ExecuteList&lt;T&gt;(DbContext, IDbCommand)](ListFromIDbCommandExtensions_ExecuteList_T_(DbContext_IDbCommand) 'RobertsDbContextExtensions.ListFromIDbCommandExtensions.ExecuteList&lt;T&gt;(Microsoft.EntityFrameworkCore.DbContext, System.Data.IDbCommand)')
- [ExecuteList&lt;T1,T2&gt;(DbContext, IDbCommand)](ListFromIDbCommandExtensions_ExecuteList_T1_T2_(DbContext_IDbCommand) 'RobertsDbContextExtensions.ListFromIDbCommandExtensions.ExecuteList&lt;T1,T2&gt;(Microsoft.EntityFrameworkCore.DbContext, System.Data.IDbCommand)')
- [ExecuteList&lt;T1,T2,T3&gt;(DbContext, IDbCommand)](ListFromIDbCommandExtensions_ExecuteList_T1_T2_T3_(DbContext_IDbCommand) 'RobertsDbContextExtensions.ListFromIDbCommandExtensions.ExecuteList&lt;T1,T2,T3&gt;(Microsoft.EntityFrameworkCore.DbContext, System.Data.IDbCommand)')
- [ExecuteList&lt;T1,T2,T3,T4&gt;(DbContext, IDbCommand)](ListFromIDbCommandExtensions_ExecuteList_T1_T2_T3_T4_(DbContext_IDbCommand) 'RobertsDbContextExtensions.ListFromIDbCommandExtensions.ExecuteList&lt;T1,T2,T3,T4&gt;(Microsoft.EntityFrameworkCore.DbContext, System.Data.IDbCommand)')
- [ExecuteList&lt;T1,T2,T3,T4,T5&gt;(DbContext, IDbCommand)](ListFromIDbCommandExtensions_ExecuteList_T1_T2_T3_T4_T5_(DbContext_IDbCommand) 'RobertsDbContextExtensions.ListFromIDbCommandExtensions.ExecuteList&lt;T1,T2,T3,T4,T5&gt;(Microsoft.EntityFrameworkCore.DbContext, System.Data.IDbCommand)')
- [ExecuteList&lt;T1,T2,T3,T4,T5,T6&gt;(DbContext, IDbCommand)](ListFromIDbCommandExtensions_ExecuteList_T1_T2_T3_T4_T5_T6_(DbContext_IDbCommand) 'RobertsDbContextExtensions.ListFromIDbCommandExtensions.ExecuteList&lt;T1,T2,T3,T4,T5,T6&gt;(Microsoft.EntityFrameworkCore.DbContext, System.Data.IDbCommand)')
