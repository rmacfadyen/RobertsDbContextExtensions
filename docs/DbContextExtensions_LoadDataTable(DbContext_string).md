### [RobertsDbContextExtensions](RobertsDbContextExtensions 'RobertsDbContextExtensions').[DbContextExtensions](DbContextExtensions 'RobertsDbContextExtensions.DbContextExtensions')
## DbContextExtensions.LoadDataTable(DbContext, string) Method
Executes the provided SQL and returns a classic ADO.NET DataTable. 
Only provided for migratory purposes. Should be avoided for new code.
```csharp
public static System.Data.DataTable LoadDataTable(this Microsoft.EntityFrameworkCore.DbContext ctx, string Sql);
```
#### Parameters
<a name='RobertsDbContextExtensions_DbContextExtensions_LoadDataTable(Microsoft_EntityFrameworkCore_DbContext_string)_ctx'></a>
`ctx` [Microsoft.EntityFrameworkCore.DbContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.EntityFrameworkCore.DbContext 'Microsoft.EntityFrameworkCore.DbContext')  
  
<a name='RobertsDbContextExtensions_DbContextExtensions_LoadDataTable(Microsoft_EntityFrameworkCore_DbContext_string)_Sql'></a>
`Sql` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
  
#### Returns
[System.Data.DataTable](https://docs.microsoft.com/en-us/dotnet/api/System.Data.DataTable 'System.Data.DataTable')  
