### [RobertsDbContextExtensions](RobertsDbContextExtensions 'RobertsDbContextExtensions').[DbContextExtensions](DbContextExtensions 'RobertsDbContextExtensions.DbContextExtensions')
## DbContextExtensions.LoadDataTable(DbContext, IDbCommand) Method
Executes the provided command and returns a classic ADO.NET DataTable.   
Only provided for migratory purposes. Should be avoided for new code.  
```csharp
public static System.Data.DataTable LoadDataTable(this Microsoft.EntityFrameworkCore.DbContext ctx, System.Data.IDbCommand cmd);
```
#### Parameters
<a name='RobertsDbContextExtensions_DbContextExtensions_LoadDataTable(Microsoft_EntityFrameworkCore_DbContext_System_Data_IDbCommand)_ctx'></a>
`ctx` [Microsoft.EntityFrameworkCore.DbContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.EntityFrameworkCore.DbContext 'Microsoft.EntityFrameworkCore.DbContext')  
  
<a name='RobertsDbContextExtensions_DbContextExtensions_LoadDataTable(Microsoft_EntityFrameworkCore_DbContext_System_Data_IDbCommand)_cmd'></a>
`cmd` [System.Data.IDbCommand](https://docs.microsoft.com/en-us/dotnet/api/System.Data.IDbCommand 'System.Data.IDbCommand')  
  
#### Returns
[System.Data.DataTable](https://docs.microsoft.com/en-us/dotnet/api/System.Data.DataTable 'System.Data.DataTable')  
