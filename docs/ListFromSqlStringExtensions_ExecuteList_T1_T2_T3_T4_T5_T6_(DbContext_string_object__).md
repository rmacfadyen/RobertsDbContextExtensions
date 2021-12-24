### [RobertsDbContextExtensions](RobertsDbContextExtensions 'RobertsDbContextExtensions').[ListFromSqlStringExtensions](ListFromSqlStringExtensions 'RobertsDbContextExtensions.ListFromSqlStringExtensions')
## ListFromSqlStringExtensions.ExecuteList&lt;T1,T2,T3,T4,T5,T6&gt;(DbContext, string, object[]) Method
Execute the provided SQL and return a tuple of the 
first six result sets mapped to lists.
```csharp
public static (System.Collections.Generic.IList<T1>,System.Collections.Generic.IList<T2>,System.Collections.Generic.IList<T3>,System.Collections.Generic.IList<T4>,System.Collections.Generic.IList<T5>,System.Collections.Generic.IList<T6>) ExecuteList<T1,T2,T3,T4,T5,T6>(this Microsoft.EntityFrameworkCore.DbContext ctx, string Sql, params object[] Parameters);
```
#### Type parameters
<a name='RobertsDbContextExtensions_ListFromSqlStringExtensions_ExecuteList_T1_T2_T3_T4_T5_T6_(Microsoft_EntityFrameworkCore_DbContext_string_object__)_T1'></a>
`T1`  
The type the first result set should be mapped to.
  
<a name='RobertsDbContextExtensions_ListFromSqlStringExtensions_ExecuteList_T1_T2_T3_T4_T5_T6_(Microsoft_EntityFrameworkCore_DbContext_string_object__)_T2'></a>
`T2`  
The type the second result set should be mapped to.
  
<a name='RobertsDbContextExtensions_ListFromSqlStringExtensions_ExecuteList_T1_T2_T3_T4_T5_T6_(Microsoft_EntityFrameworkCore_DbContext_string_object__)_T3'></a>
`T3`  
The type the third result set should be mapped to.
  
<a name='RobertsDbContextExtensions_ListFromSqlStringExtensions_ExecuteList_T1_T2_T3_T4_T5_T6_(Microsoft_EntityFrameworkCore_DbContext_string_object__)_T4'></a>
`T4`  
The type the forth result set should be mapped to.
  
<a name='RobertsDbContextExtensions_ListFromSqlStringExtensions_ExecuteList_T1_T2_T3_T4_T5_T6_(Microsoft_EntityFrameworkCore_DbContext_string_object__)_T5'></a>
`T5`  
The type the fifth result set should be mapped to.
  
<a name='RobertsDbContextExtensions_ListFromSqlStringExtensions_ExecuteList_T1_T2_T3_T4_T5_T6_(Microsoft_EntityFrameworkCore_DbContext_string_object__)_T6'></a>
`T6`  
The type the sixth result set should be mapped to.
  
#### Parameters
<a name='RobertsDbContextExtensions_ListFromSqlStringExtensions_ExecuteList_T1_T2_T3_T4_T5_T6_(Microsoft_EntityFrameworkCore_DbContext_string_object__)_ctx'></a>
`ctx` [Microsoft.EntityFrameworkCore.DbContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.EntityFrameworkCore.DbContext 'Microsoft.EntityFrameworkCore.DbContext')  
The DbContext to execute the SQL on.
  
<a name='RobertsDbContextExtensions_ListFromSqlStringExtensions_ExecuteList_T1_T2_T3_T4_T5_T6_(Microsoft_EntityFrameworkCore_DbContext_string_object__)_Sql'></a>
`Sql` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The SQL to be executed.
  
<a name='RobertsDbContextExtensions_ListFromSqlStringExtensions_ExecuteList_T1_T2_T3_T4_T5_T6_(Microsoft_EntityFrameworkCore_DbContext_string_object__)_Parameters'></a>
`Parameters` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
A list of values to be passed as parameters. See [Passing parameters](https://github.com/rmacfadyen/RobertsDbContextExtensions/blob/master/Parameters.md 'https://github.com/rmacfadyen/RobertsDbContextExtensions/blob/master/Parameters.md')
  
#### Returns
[&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')[System.Collections.Generic.IList&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[T1](ListFromSqlStringExtensions_ExecuteList_T1_T2_T3_T4_T5_T6_(DbContext_string_object__)#RobertsDbContextExtensions_ListFromSqlStringExtensions_ExecuteList_T1_T2_T3_T4_T5_T6_(Microsoft_EntityFrameworkCore_DbContext_string_object__)_T1 'RobertsDbContextExtensions.ListFromSqlStringExtensions.ExecuteList&lt;T1,T2,T3,T4,T5,T6&gt;(Microsoft.EntityFrameworkCore.DbContext, string, object[]).T1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[,](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')[System.Collections.Generic.IList&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[T2](ListFromSqlStringExtensions_ExecuteList_T1_T2_T3_T4_T5_T6_(DbContext_string_object__)#RobertsDbContextExtensions_ListFromSqlStringExtensions_ExecuteList_T1_T2_T3_T4_T5_T6_(Microsoft_EntityFrameworkCore_DbContext_string_object__)_T2 'RobertsDbContextExtensions.ListFromSqlStringExtensions.ExecuteList&lt;T1,T2,T3,T4,T5,T6&gt;(Microsoft.EntityFrameworkCore.DbContext, string, object[]).T2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[,](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')[System.Collections.Generic.IList&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[T3](ListFromSqlStringExtensions_ExecuteList_T1_T2_T3_T4_T5_T6_(DbContext_string_object__)#RobertsDbContextExtensions_ListFromSqlStringExtensions_ExecuteList_T1_T2_T3_T4_T5_T6_(Microsoft_EntityFrameworkCore_DbContext_string_object__)_T3 'RobertsDbContextExtensions.ListFromSqlStringExtensions.ExecuteList&lt;T1,T2,T3,T4,T5,T6&gt;(Microsoft.EntityFrameworkCore.DbContext, string, object[]).T3')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[,](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')[System.Collections.Generic.IList&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[T4](ListFromSqlStringExtensions_ExecuteList_T1_T2_T3_T4_T5_T6_(DbContext_string_object__)#RobertsDbContextExtensions_ListFromSqlStringExtensions_ExecuteList_T1_T2_T3_T4_T5_T6_(Microsoft_EntityFrameworkCore_DbContext_string_object__)_T4 'RobertsDbContextExtensions.ListFromSqlStringExtensions.ExecuteList&lt;T1,T2,T3,T4,T5,T6&gt;(Microsoft.EntityFrameworkCore.DbContext, string, object[]).T4')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[,](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')[System.Collections.Generic.IList&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[T5](ListFromSqlStringExtensions_ExecuteList_T1_T2_T3_T4_T5_T6_(DbContext_string_object__)#RobertsDbContextExtensions_ListFromSqlStringExtensions_ExecuteList_T1_T2_T3_T4_T5_T6_(Microsoft_EntityFrameworkCore_DbContext_string_object__)_T5 'RobertsDbContextExtensions.ListFromSqlStringExtensions.ExecuteList&lt;T1,T2,T3,T4,T5,T6&gt;(Microsoft.EntityFrameworkCore.DbContext, string, object[]).T5')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[,](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')[System.Collections.Generic.IList&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[T6](ListFromSqlStringExtensions_ExecuteList_T1_T2_T3_T4_T5_T6_(DbContext_string_object__)#RobertsDbContextExtensions_ListFromSqlStringExtensions_ExecuteList_T1_T2_T3_T4_T5_T6_(Microsoft_EntityFrameworkCore_DbContext_string_object__)_T6 'RobertsDbContextExtensions.ListFromSqlStringExtensions.ExecuteList&lt;T1,T2,T3,T4,T5,T6&gt;(Microsoft.EntityFrameworkCore.DbContext, string, object[]).T6')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')  
A tuple, with each value being the corresponding mapping of a result set.
#### See Also
- [ExecuteList&lt;T&gt;(DbContext, string, object[])](ListFromSqlStringExtensions_ExecuteList_T_(DbContext_string_object__) 'RobertsDbContextExtensions.ListFromSqlStringExtensions.ExecuteList&lt;T&gt;(Microsoft.EntityFrameworkCore.DbContext, string, object[])')
- [ExecuteList&lt;T1,T2&gt;(DbContext, string, object[])](ListFromSqlStringExtensions_ExecuteList_T1_T2_(DbContext_string_object__) 'RobertsDbContextExtensions.ListFromSqlStringExtensions.ExecuteList&lt;T1,T2&gt;(Microsoft.EntityFrameworkCore.DbContext, string, object[])')
- [ExecuteList&lt;T1,T2,T3&gt;(DbContext, string, object[])](ListFromSqlStringExtensions_ExecuteList_T1_T2_T3_(DbContext_string_object__) 'RobertsDbContextExtensions.ListFromSqlStringExtensions.ExecuteList&lt;T1,T2,T3&gt;(Microsoft.EntityFrameworkCore.DbContext, string, object[])')
- [ExecuteList&lt;T1,T2,T3,T4&gt;(DbContext, string, object[])](ListFromSqlStringExtensions_ExecuteList_T1_T2_T3_T4_(DbContext_string_object__) 'RobertsDbContextExtensions.ListFromSqlStringExtensions.ExecuteList&lt;T1,T2,T3,T4&gt;(Microsoft.EntityFrameworkCore.DbContext, string, object[])')
- [ExecuteList&lt;T1,T2,T3,T4,T5&gt;(DbContext, string, object[])](ListFromSqlStringExtensions_ExecuteList_T1_T2_T3_T4_T5_(DbContext_string_object__) 'RobertsDbContextExtensions.ListFromSqlStringExtensions.ExecuteList&lt;T1,T2,T3,T4,T5&gt;(Microsoft.EntityFrameworkCore.DbContext, string, object[])')
- [ExecuteList&lt;T1,T2,T3,T4,T5,T6&gt;(DbContext, string, object[])](ListFromSqlStringExtensions_ExecuteList_T1_T2_T3_T4_T5_T6_(DbContext_string_object__) 'RobertsDbContextExtensions.ListFromSqlStringExtensions.ExecuteList&lt;T1,T2,T3,T4,T5,T6&gt;(Microsoft.EntityFrameworkCore.DbContext, string, object[])')
