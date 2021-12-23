### [RobertsDbContextExtensions](RobertsDbContextExtensions 'RobertsDbContextExtensions').[DbContextExtensions](DbContextExtensions 'RobertsDbContextExtensions.DbContextExtensions')
## DbContextExtensions.ExecuteList&lt;T1,T2,T3,T4,T5,T6&gt;(DbContext, string, object[]) Method
Execute the provided SQL and return a tuple of the   
first six result sets mapped to lists.  
```csharp
public static (System.Collections.Generic.IList<T1>,System.Collections.Generic.IList<T2>,System.Collections.Generic.IList<T3>,System.Collections.Generic.IList<T4>,System.Collections.Generic.IList<T5>,System.Collections.Generic.IList<T6>) ExecuteList<T1,T2,T3,T4,T5,T6>(this Microsoft.EntityFrameworkCore.DbContext ctx, string Sql, params object[] Parameters);
```
#### Type parameters
<a name='RobertsDbContextExtensions_DbContextExtensions_ExecuteList_T1_T2_T3_T4_T5_T6_(Microsoft_EntityFrameworkCore_DbContext_string_object__)_T1'></a>
`T1`  
  
<a name='RobertsDbContextExtensions_DbContextExtensions_ExecuteList_T1_T2_T3_T4_T5_T6_(Microsoft_EntityFrameworkCore_DbContext_string_object__)_T2'></a>
`T2`  
  
<a name='RobertsDbContextExtensions_DbContextExtensions_ExecuteList_T1_T2_T3_T4_T5_T6_(Microsoft_EntityFrameworkCore_DbContext_string_object__)_T3'></a>
`T3`  
  
<a name='RobertsDbContextExtensions_DbContextExtensions_ExecuteList_T1_T2_T3_T4_T5_T6_(Microsoft_EntityFrameworkCore_DbContext_string_object__)_T4'></a>
`T4`  
  
<a name='RobertsDbContextExtensions_DbContextExtensions_ExecuteList_T1_T2_T3_T4_T5_T6_(Microsoft_EntityFrameworkCore_DbContext_string_object__)_T5'></a>
`T5`  
  
<a name='RobertsDbContextExtensions_DbContextExtensions_ExecuteList_T1_T2_T3_T4_T5_T6_(Microsoft_EntityFrameworkCore_DbContext_string_object__)_T6'></a>
`T6`  
  
#### Parameters
<a name='RobertsDbContextExtensions_DbContextExtensions_ExecuteList_T1_T2_T3_T4_T5_T6_(Microsoft_EntityFrameworkCore_DbContext_string_object__)_ctx'></a>
`ctx` [Microsoft.EntityFrameworkCore.DbContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.EntityFrameworkCore.DbContext 'Microsoft.EntityFrameworkCore.DbContext')  
  
<a name='RobertsDbContextExtensions_DbContextExtensions_ExecuteList_T1_T2_T3_T4_T5_T6_(Microsoft_EntityFrameworkCore_DbContext_string_object__)_Sql'></a>
`Sql` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
  
<a name='RobertsDbContextExtensions_DbContextExtensions_ExecuteList_T1_T2_T3_T4_T5_T6_(Microsoft_EntityFrameworkCore_DbContext_string_object__)_Parameters'></a>
`Parameters` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
  
#### Returns
[&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')[System.Collections.Generic.IList&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[T1](DbContextExtensions_ExecuteList_T1_T2_T3_T4_T5_T6_(DbContext_string_object__)#RobertsDbContextExtensions_DbContextExtensions_ExecuteList_T1_T2_T3_T4_T5_T6_(Microsoft_EntityFrameworkCore_DbContext_string_object__)_T1 'RobertsDbContextExtensions.DbContextExtensions.ExecuteList&lt;T1,T2,T3,T4,T5,T6&gt;(Microsoft.EntityFrameworkCore.DbContext, string, object[]).T1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[,](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')[System.Collections.Generic.IList&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[T2](DbContextExtensions_ExecuteList_T1_T2_T3_T4_T5_T6_(DbContext_string_object__)#RobertsDbContextExtensions_DbContextExtensions_ExecuteList_T1_T2_T3_T4_T5_T6_(Microsoft_EntityFrameworkCore_DbContext_string_object__)_T2 'RobertsDbContextExtensions.DbContextExtensions.ExecuteList&lt;T1,T2,T3,T4,T5,T6&gt;(Microsoft.EntityFrameworkCore.DbContext, string, object[]).T2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[,](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')[System.Collections.Generic.IList&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[T3](DbContextExtensions_ExecuteList_T1_T2_T3_T4_T5_T6_(DbContext_string_object__)#RobertsDbContextExtensions_DbContextExtensions_ExecuteList_T1_T2_T3_T4_T5_T6_(Microsoft_EntityFrameworkCore_DbContext_string_object__)_T3 'RobertsDbContextExtensions.DbContextExtensions.ExecuteList&lt;T1,T2,T3,T4,T5,T6&gt;(Microsoft.EntityFrameworkCore.DbContext, string, object[]).T3')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[,](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')[System.Collections.Generic.IList&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[T4](DbContextExtensions_ExecuteList_T1_T2_T3_T4_T5_T6_(DbContext_string_object__)#RobertsDbContextExtensions_DbContextExtensions_ExecuteList_T1_T2_T3_T4_T5_T6_(Microsoft_EntityFrameworkCore_DbContext_string_object__)_T4 'RobertsDbContextExtensions.DbContextExtensions.ExecuteList&lt;T1,T2,T3,T4,T5,T6&gt;(Microsoft.EntityFrameworkCore.DbContext, string, object[]).T4')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[,](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')[System.Collections.Generic.IList&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[T5](DbContextExtensions_ExecuteList_T1_T2_T3_T4_T5_T6_(DbContext_string_object__)#RobertsDbContextExtensions_DbContextExtensions_ExecuteList_T1_T2_T3_T4_T5_T6_(Microsoft_EntityFrameworkCore_DbContext_string_object__)_T5 'RobertsDbContextExtensions.DbContextExtensions.ExecuteList&lt;T1,T2,T3,T4,T5,T6&gt;(Microsoft.EntityFrameworkCore.DbContext, string, object[]).T5')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[,](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')[System.Collections.Generic.IList&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[T6](DbContextExtensions_ExecuteList_T1_T2_T3_T4_T5_T6_(DbContext_string_object__)#RobertsDbContextExtensions_DbContextExtensions_ExecuteList_T1_T2_T3_T4_T5_T6_(Microsoft_EntityFrameworkCore_DbContext_string_object__)_T6 'RobertsDbContextExtensions.DbContextExtensions.ExecuteList&lt;T1,T2,T3,T4,T5,T6&gt;(Microsoft.EntityFrameworkCore.DbContext, string, object[]).T6')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')  
