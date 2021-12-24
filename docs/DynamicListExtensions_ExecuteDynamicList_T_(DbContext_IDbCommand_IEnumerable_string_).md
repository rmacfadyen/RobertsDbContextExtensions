### [RobertsDbContextExtensions](RobertsDbContextExtensions 'RobertsDbContextExtensions').[DynamicListExtensions](DynamicListExtensions 'RobertsDbContextExtensions.DynamicListExtensions')
## DynamicListExtensions.ExecuteDynamicList&lt;T&gt;(DbContext, IDbCommand, IEnumerable&lt;string&gt;) Method
A dynamic list is a regular POCO object with one property defined
as an object[]. This array will be populated with column values
as passed in the DynmaicColumnNames list (in the same order). The
other properties on the object will be populated as normal.
```csharp
public static System.Collections.Generic.IList<T> ExecuteDynamicList<T>(this Microsoft.EntityFrameworkCore.DbContext ctx, System.Data.IDbCommand cmd, System.Collections.Generic.IEnumerable<string> DynamicColumnNames);
```
#### Type parameters
<a name='RobertsDbContextExtensions_DynamicListExtensions_ExecuteDynamicList_T_(Microsoft_EntityFrameworkCore_DbContext_System_Data_IDbCommand_System_Collections_Generic_IEnumerable_string_)_T'></a>
`T`  
The type the first result set should be mapped to. Must include an object[] property to 
            hold the list of values for the columns from DynamicColumnNames.
  
#### Parameters
<a name='RobertsDbContextExtensions_DynamicListExtensions_ExecuteDynamicList_T_(Microsoft_EntityFrameworkCore_DbContext_System_Data_IDbCommand_System_Collections_Generic_IEnumerable_string_)_ctx'></a>
`ctx` [Microsoft.EntityFrameworkCore.DbContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.EntityFrameworkCore.DbContext 'Microsoft.EntityFrameworkCore.DbContext')  
The DbContext to execute the SQL on.
  
<a name='RobertsDbContextExtensions_DynamicListExtensions_ExecuteDynamicList_T_(Microsoft_EntityFrameworkCore_DbContext_System_Data_IDbCommand_System_Collections_Generic_IEnumerable_string_)_cmd'></a>
`cmd` [System.Data.IDbCommand](https://docs.microsoft.com/en-us/dotnet/api/System.Data.IDbCommand 'System.Data.IDbCommand')  
The command to be executed.
  
<a name='RobertsDbContextExtensions_DynamicListExtensions_ExecuteDynamicList_T_(Microsoft_EntityFrameworkCore_DbContext_System_Data_IDbCommand_System_Collections_Generic_IEnumerable_string_)_DynamicColumnNames'></a>
`DynamicColumnNames` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
A list of columns names who's values will populate
            the first object[] property on T.
  
#### Returns
[System.Collections.Generic.IList&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[T](DynamicListExtensions_ExecuteDynamicList_T_(DbContext_IDbCommand_IEnumerable_string_)#RobertsDbContextExtensions_DynamicListExtensions_ExecuteDynamicList_T_(Microsoft_EntityFrameworkCore_DbContext_System_Data_IDbCommand_System_Collections_Generic_IEnumerable_string_)_T 'RobertsDbContextExtensions.DynamicListExtensions.ExecuteDynamicList&lt;T&gt;(Microsoft.EntityFrameworkCore.DbContext, System.Data.IDbCommand, System.Collections.Generic.IEnumerable&lt;string&gt;).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')  
The first result set mapped to a list of T's, with the columns
            specified as dynamic loaded into the first object[] property on T.
            
