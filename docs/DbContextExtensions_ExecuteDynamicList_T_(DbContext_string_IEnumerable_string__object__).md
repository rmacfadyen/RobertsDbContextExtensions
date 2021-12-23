### [RobertsDbContextExtensions](RobertsDbContextExtensions 'RobertsDbContextExtensions').[DbContextExtensions](DbContextExtensions 'RobertsDbContextExtensions.DbContextExtensions')
## DbContextExtensions.ExecuteDynamicList&lt;T&gt;(DbContext, string, IEnumerable&lt;string&gt;, object[]) Method
A dynamic list is a regular POCO object with one property defined
as an object[]. This array will be populated with column values
as passed in the DynmaicColumnNames list (in the same order). The
other properties on the object will be populated as normal.
```csharp
public static System.Collections.Generic.IList<T> ExecuteDynamicList<T>(this Microsoft.EntityFrameworkCore.DbContext ctx, string Sql, System.Collections.Generic.IEnumerable<string> DynamicColumnNames, params object[] Parameters);
```
#### Type parameters
<a name='RobertsDbContextExtensions_DbContextExtensions_ExecuteDynamicList_T_(Microsoft_EntityFrameworkCore_DbContext_string_System_Collections_Generic_IEnumerable_string__object__)_T'></a>
`T`  
The type the first result set should be mapped to. Must include an object[] property to 
            hold the list of values for the columns from DynamicColumnNames.
  
#### Parameters
<a name='RobertsDbContextExtensions_DbContextExtensions_ExecuteDynamicList_T_(Microsoft_EntityFrameworkCore_DbContext_string_System_Collections_Generic_IEnumerable_string__object__)_ctx'></a>
`ctx` [Microsoft.EntityFrameworkCore.DbContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.EntityFrameworkCore.DbContext 'Microsoft.EntityFrameworkCore.DbContext')  
The DbContext to execute the SQL on.
  
<a name='RobertsDbContextExtensions_DbContextExtensions_ExecuteDynamicList_T_(Microsoft_EntityFrameworkCore_DbContext_string_System_Collections_Generic_IEnumerable_string__object__)_Sql'></a>
`Sql` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The SQL to be executed.
  
<a name='RobertsDbContextExtensions_DbContextExtensions_ExecuteDynamicList_T_(Microsoft_EntityFrameworkCore_DbContext_string_System_Collections_Generic_IEnumerable_string__object__)_DynamicColumnNames'></a>
`DynamicColumnNames` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
A list of columns names who's values will populate
            the first object[] property on T.
  
<a name='RobertsDbContextExtensions_DbContextExtensions_ExecuteDynamicList_T_(Microsoft_EntityFrameworkCore_DbContext_string_System_Collections_Generic_IEnumerable_string__object__)_Parameters'></a>
`Parameters` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
A list of values to be passed as parameters. See [Passing parameters](https://github.com/rmacfadyen/RobertsDbContextExtensions/blob/master/Parameters.md 'https://github.com/rmacfadyen/RobertsDbContextExtensions/blob/master/Parameters.md')
  
#### Returns
[System.Collections.Generic.IList&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[T](DbContextExtensions_ExecuteDynamicList_T_(DbContext_string_IEnumerable_string__object__)#RobertsDbContextExtensions_DbContextExtensions_ExecuteDynamicList_T_(Microsoft_EntityFrameworkCore_DbContext_string_System_Collections_Generic_IEnumerable_string__object__)_T 'RobertsDbContextExtensions.DbContextExtensions.ExecuteDynamicList&lt;T&gt;(Microsoft.EntityFrameworkCore.DbContext, string, System.Collections.Generic.IEnumerable&lt;string&gt;, object[]).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')  
The first result set mapped to a list of T's, with the columns
            specified as dynamic loaded into the first object[] property on T.
            
### Remarks
This is a bit tricky to do, but also surprisingly straight-forward.
When we decide whether we're reading a value or an object we now
decide between value, dynamic, or object. For dynamic we figure
out the FastProperty setter (just once, not once per record) and
calculate a mapping between column ordinals (what a DbDataReader
operates on) and column names. 

We then loop through the data reader, populate the regular properties,
then pull out any dynamic properties into a list. Finally we assign
the list to the fast property for the object[] property.

The end result is that we can have a class like:
  class MyRecord {
    public int i { get; set; }
    public object[] values {get; set; }
  }
and have it populated from a simple query like:
  var r = ctx.ExecuteDynamicList<MyRecord>("select i, j, k from tbl", new List<string> { "j", "k" })
which populates: r.i, r.values[0], and r.values[1]

It is up to the caller to track the order of columns in the object array.
This is mostly done for an expected performance gain (duplicating the
mapping on every row/instance seems wasteful, even if it's only a reference)
