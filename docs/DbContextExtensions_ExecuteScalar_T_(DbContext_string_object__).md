### [RobertsDbContextExtensions](RobertsDbContextExtensions 'RobertsDbContextExtensions').[DbContextExtensions](DbContextExtensions 'RobertsDbContextExtensions.DbContextExtensions')
## DbContextExtensions.ExecuteScalar&lt;T&gt;(DbContext, string, object[]) Method
Execute the provided SQL and return the first column of the first row of
the result set.
```csharp
public static T ExecuteScalar<T>(this Microsoft.EntityFrameworkCore.DbContext ctx, string Sql, params object[] Parameters);
```
#### Type parameters
<a name='RobertsDbContextExtensions_DbContextExtensions_ExecuteScalar_T_(Microsoft_EntityFrameworkCore_DbContext_string_object__)_T'></a>
`T`  
  
#### Parameters
<a name='RobertsDbContextExtensions_DbContextExtensions_ExecuteScalar_T_(Microsoft_EntityFrameworkCore_DbContext_string_object__)_ctx'></a>
`ctx` [Microsoft.EntityFrameworkCore.DbContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.EntityFrameworkCore.DbContext 'Microsoft.EntityFrameworkCore.DbContext')  
  
<a name='RobertsDbContextExtensions_DbContextExtensions_ExecuteScalar_T_(Microsoft_EntityFrameworkCore_DbContext_string_object__)_Sql'></a>
`Sql` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
  
<a name='RobertsDbContextExtensions_DbContextExtensions_ExecuteScalar_T_(Microsoft_EntityFrameworkCore_DbContext_string_object__)_Parameters'></a>
`Parameters` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
  
#### Returns
[T](DbContextExtensions_ExecuteScalar_T_(DbContext_string_object__)#RobertsDbContextExtensions_DbContextExtensions_ExecuteScalar_T_(Microsoft_EntityFrameworkCore_DbContext_string_object__)_T 'RobertsDbContextExtensions.DbContextExtensions.ExecuteScalar&lt;T&gt;(Microsoft.EntityFrameworkCore.DbContext, string, object[]).T')  
