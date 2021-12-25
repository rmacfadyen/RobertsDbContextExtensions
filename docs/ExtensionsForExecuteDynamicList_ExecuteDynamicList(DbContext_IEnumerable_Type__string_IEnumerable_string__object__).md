### [RobertsDbContextExtensions](RobertsDbContextExtensions 'RobertsDbContextExtensions').[ExtensionsForExecuteDynamicList](ExtensionsForExecuteDynamicList 'RobertsDbContextExtensions.ExtensionsForExecuteDynamicList')
## ExtensionsForExecuteDynamicList.ExecuteDynamicList(DbContext, IEnumerable&lt;Type&gt;, string, IEnumerable&lt;string&gt;, object[]) Method
When you have a query that consists of several result sets,
and the first result contains columns that are not known in 
advanced, then ExecuteDynamicList is your ticket.
```csharp
public static System.Collections.Generic.IList<object> ExecuteDynamicList(this Microsoft.EntityFrameworkCore.DbContext ctx, System.Collections.Generic.IEnumerable<System.Type> Types, string Sql, System.Collections.Generic.IEnumerable<string> DynamicColumnNames=null, params object[] Parameters);
```
#### Parameters
<a name='RobertsDbContextExtensions_ExtensionsForExecuteDynamicList_ExecuteDynamicList(Microsoft_EntityFrameworkCore_DbContext_System_Collections_Generic_IEnumerable_System_Type__string_System_Collections_Generic_IEnumerable_string__object__)_ctx'></a>
`ctx` [Microsoft.EntityFrameworkCore.DbContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.EntityFrameworkCore.DbContext 'Microsoft.EntityFrameworkCore.DbContext')  
The DbContext to execute the SQL on.
  
<a name='RobertsDbContextExtensions_ExtensionsForExecuteDynamicList_ExecuteDynamicList(Microsoft_EntityFrameworkCore_DbContext_System_Collections_Generic_IEnumerable_System_Type__string_System_Collections_Generic_IEnumerable_string__object__)_Types'></a>
`Types` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
A list of Types the query's result sets will be
            mapped to. The first type must have an object[] property to hold
            the dynamic column values.
  
<a name='RobertsDbContextExtensions_ExtensionsForExecuteDynamicList_ExecuteDynamicList(Microsoft_EntityFrameworkCore_DbContext_System_Collections_Generic_IEnumerable_System_Type__string_System_Collections_Generic_IEnumerable_string__object__)_Sql'></a>
`Sql` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The SQL to be executed.
  
<a name='RobertsDbContextExtensions_ExtensionsForExecuteDynamicList_ExecuteDynamicList(Microsoft_EntityFrameworkCore_DbContext_System_Collections_Generic_IEnumerable_System_Type__string_System_Collections_Generic_IEnumerable_string__object__)_DynamicColumnNames'></a>
`DynamicColumnNames` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
A list of columns names who's values will populate
            the first object[] property on T.
  
<a name='RobertsDbContextExtensions_ExtensionsForExecuteDynamicList_ExecuteDynamicList(Microsoft_EntityFrameworkCore_DbContext_System_Collections_Generic_IEnumerable_System_Type__string_System_Collections_Generic_IEnumerable_string__object__)_Parameters'></a>
`Parameters` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
A list of values to be passed as parameters. See [Passing parameters](https://github.com/rmacfadyen/RobertsDbContextExtensions/blob/master/Parameters.md 'https://github.com/rmacfadyen/RobertsDbContextExtensions/blob/master/Parameters.md')
  
#### Returns
[System.Collections.Generic.IList&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')  
A list of lists. Each list corresponds to the type from the Types parameter.
