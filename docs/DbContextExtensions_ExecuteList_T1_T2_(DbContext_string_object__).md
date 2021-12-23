### [RobertsDbContextExtensions](RobertsDbContextExtensions 'RobertsDbContextExtensions').[DbContextExtensions](DbContextExtensions 'RobertsDbContextExtensions.DbContextExtensions')
## DbContextExtensions.ExecuteList&lt;T1,T2&gt;(DbContext, string, object[]) Method
Execute the provided SQL and return a tuple of the 
first two result sets mapped to lists.
```csharp
public static (System.Collections.Generic.IList<T1>,System.Collections.Generic.IList<T2>) ExecuteList<T1,T2>(this Microsoft.EntityFrameworkCore.DbContext ctx, string Sql, params object[] Parameters);
```
#### Type parameters
<a name='RobertsDbContextExtensions_DbContextExtensions_ExecuteList_T1_T2_(Microsoft_EntityFrameworkCore_DbContext_string_object__)_T1'></a>
`T1`  
  
<a name='RobertsDbContextExtensions_DbContextExtensions_ExecuteList_T1_T2_(Microsoft_EntityFrameworkCore_DbContext_string_object__)_T2'></a>
`T2`  
  
#### Parameters
<a name='RobertsDbContextExtensions_DbContextExtensions_ExecuteList_T1_T2_(Microsoft_EntityFrameworkCore_DbContext_string_object__)_ctx'></a>
`ctx` [Microsoft.EntityFrameworkCore.DbContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.EntityFrameworkCore.DbContext 'Microsoft.EntityFrameworkCore.DbContext')  
  
<a name='RobertsDbContextExtensions_DbContextExtensions_ExecuteList_T1_T2_(Microsoft_EntityFrameworkCore_DbContext_string_object__)_Sql'></a>
`Sql` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
  
<a name='RobertsDbContextExtensions_DbContextExtensions_ExecuteList_T1_T2_(Microsoft_EntityFrameworkCore_DbContext_string_object__)_Parameters'></a>
`Parameters` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
  
#### Returns
[&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')[System.Collections.Generic.IList&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[T1](DbContextExtensions_ExecuteList_T1_T2_(DbContext_string_object__)#RobertsDbContextExtensions_DbContextExtensions_ExecuteList_T1_T2_(Microsoft_EntityFrameworkCore_DbContext_string_object__)_T1 'RobertsDbContextExtensions.DbContextExtensions.ExecuteList&lt;T1,T2&gt;(Microsoft.EntityFrameworkCore.DbContext, string, object[]).T1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[,](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')[System.Collections.Generic.IList&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[T2](DbContextExtensions_ExecuteList_T1_T2_(DbContext_string_object__)#RobertsDbContextExtensions_DbContextExtensions_ExecuteList_T1_T2_(Microsoft_EntityFrameworkCore_DbContext_string_object__)_T2 'RobertsDbContextExtensions.DbContextExtensions.ExecuteList&lt;T1,T2&gt;(Microsoft.EntityFrameworkCore.DbContext, string, object[]).T2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')  
