### [RobertsDbContextExtensions](RobertsDbContextExtensions 'RobertsDbContextExtensions').[DbContextExtensions](DbContextExtensions 'RobertsDbContextExtensions.DbContextExtensions')
## DbContextExtensions.ExecuteList&lt;T&gt;(DbContext, string, object[]) Method
Execute the provided SQL and return a tuple of the 
first result set mapped to lists.
```csharp
public static System.Collections.Generic.IList<T> ExecuteList<T>(this Microsoft.EntityFrameworkCore.DbContext ctx, string Sql, params object[] Parameters);
```
#### Type parameters
<a name='RobertsDbContextExtensions_DbContextExtensions_ExecuteList_T_(Microsoft_EntityFrameworkCore_DbContext_string_object__)_T'></a>
`T`  
  
#### Parameters
<a name='RobertsDbContextExtensions_DbContextExtensions_ExecuteList_T_(Microsoft_EntityFrameworkCore_DbContext_string_object__)_ctx'></a>
`ctx` [Microsoft.EntityFrameworkCore.DbContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.EntityFrameworkCore.DbContext 'Microsoft.EntityFrameworkCore.DbContext')  
The DbContext to execute the SQL on
  
<a name='RobertsDbContextExtensions_DbContextExtensions_ExecuteList_T_(Microsoft_EntityFrameworkCore_DbContext_string_object__)_Sql'></a>
`Sql` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The SQL to be executed.
  
<a name='RobertsDbContextExtensions_DbContextExtensions_ExecuteList_T_(Microsoft_EntityFrameworkCore_DbContext_string_object__)_Parameters'></a>
`Parameters` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
A list of values to be passed as parameters. See [Passing parameters](https://github.com/rmacfadyen/RobertsDbContextExtensions/blob/master/Parameters.md 'https://github.com/rmacfadyen/RobertsDbContextExtensions/blob/master/Parameters.md')
  
#### Returns
[System.Collections.Generic.IList&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[T](DbContextExtensions_ExecuteList_T_(DbContext_string_object__)#RobertsDbContextExtensions_DbContextExtensions_ExecuteList_T_(Microsoft_EntityFrameworkCore_DbContext_string_object__)_T 'RobertsDbContextExtensions.DbContextExtensions.ExecuteList&lt;T&gt;(Microsoft.EntityFrameworkCore.DbContext, string, object[]).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')  
### Remarks
#### See Also
- [ExecuteList&lt;T&gt;(DbContext, string, object[])](DbContextExtensions_ExecuteList_T_(DbContext_string_object__) 'RobertsDbContextExtensions.DbContextExtensions.ExecuteList&lt;T&gt;(Microsoft.EntityFrameworkCore.DbContext, string, object[])')
- [ExecuteList&lt;T1,T2&gt;(DbContext, string, object[])](DbContextExtensions_ExecuteList_T1_T2_(DbContext_string_object__) 'RobertsDbContextExtensions.DbContextExtensions.ExecuteList&lt;T1,T2&gt;(Microsoft.EntityFrameworkCore.DbContext, string, object[])')
- [ExecuteList&lt;T1,T2,T3&gt;(DbContext, string, object[])](DbContextExtensions_ExecuteList_T1_T2_T3_(DbContext_string_object__) 'RobertsDbContextExtensions.DbContextExtensions.ExecuteList&lt;T1,T2,T3&gt;(Microsoft.EntityFrameworkCore.DbContext, string, object[])')
- [ExecuteList&lt;T1,T2,T3,T4&gt;(DbContext, string, object[])](DbContextExtensions_ExecuteList_T1_T2_T3_T4_(DbContext_string_object__) 'RobertsDbContextExtensions.DbContextExtensions.ExecuteList&lt;T1,T2,T3,T4&gt;(Microsoft.EntityFrameworkCore.DbContext, string, object[])')
- [ExecuteList&lt;T1,T2,T3,T4,T5&gt;(DbContext, string, object[])](DbContextExtensions_ExecuteList_T1_T2_T3_T4_T5_(DbContext_string_object__) 'RobertsDbContextExtensions.DbContextExtensions.ExecuteList&lt;T1,T2,T3,T4,T5&gt;(Microsoft.EntityFrameworkCore.DbContext, string, object[])')
- [ExecuteList&lt;T1,T2,T3,T4,T5,T6&gt;(DbContext, string, object[])](DbContextExtensions_ExecuteList_T1_T2_T3_T4_T5_T6_(DbContext_string_object__) 'RobertsDbContextExtensions.DbContextExtensions.ExecuteList&lt;T1,T2,T3,T4,T5,T6&gt;(Microsoft.EntityFrameworkCore.DbContext, string, object[])')
