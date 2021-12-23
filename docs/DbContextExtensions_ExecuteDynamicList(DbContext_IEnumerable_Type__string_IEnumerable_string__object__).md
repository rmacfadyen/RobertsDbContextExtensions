### [RobertsDbContextExtensions](RobertsDbContextExtensions 'RobertsDbContextExtensions').[DbContextExtensions](DbContextExtensions 'RobertsDbContextExtensions.DbContextExtensions')
## DbContextExtensions.ExecuteDynamicList(DbContext, IEnumerable&lt;Type&gt;, string, IEnumerable&lt;string&gt;, object[]) Method
When you have a query that consists of several result sets,  
and the first result contains columns that are not known in   
advanced, then ExecuteDynamicList is your ticket.  
```csharp
public static System.Collections.Generic.IList<object> ExecuteDynamicList(this Microsoft.EntityFrameworkCore.DbContext ctx, System.Collections.Generic.IEnumerable<System.Type> Types, string Sql, System.Collections.Generic.IEnumerable<string> DynamicColumnNames=null, params object[] Parameters);
```
#### Parameters
<a name='RobertsDbContextExtensions_DbContextExtensions_ExecuteDynamicList(Microsoft_EntityFrameworkCore_DbContext_System_Collections_Generic_IEnumerable_System_Type__string_System_Collections_Generic_IEnumerable_string__object__)_ctx'></a>
`ctx` [Microsoft.EntityFrameworkCore.DbContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.EntityFrameworkCore.DbContext 'Microsoft.EntityFrameworkCore.DbContext')  
  
<a name='RobertsDbContextExtensions_DbContextExtensions_ExecuteDynamicList(Microsoft_EntityFrameworkCore_DbContext_System_Collections_Generic_IEnumerable_System_Type__string_System_Collections_Generic_IEnumerable_string__object__)_Types'></a>
`Types` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
  
<a name='RobertsDbContextExtensions_DbContextExtensions_ExecuteDynamicList(Microsoft_EntityFrameworkCore_DbContext_System_Collections_Generic_IEnumerable_System_Type__string_System_Collections_Generic_IEnumerable_string__object__)_Sql'></a>
`Sql` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
  
<a name='RobertsDbContextExtensions_DbContextExtensions_ExecuteDynamicList(Microsoft_EntityFrameworkCore_DbContext_System_Collections_Generic_IEnumerable_System_Type__string_System_Collections_Generic_IEnumerable_string__object__)_DynamicColumnNames'></a>
`DynamicColumnNames` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
  
<a name='RobertsDbContextExtensions_DbContextExtensions_ExecuteDynamicList(Microsoft_EntityFrameworkCore_DbContext_System_Collections_Generic_IEnumerable_System_Type__string_System_Collections_Generic_IEnumerable_string__object__)_Parameters'></a>
`Parameters` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
  
#### Returns
[System.Collections.Generic.IList&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')  
