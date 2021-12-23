### [RobertsDbContextExtensions](RobertsDbContextExtensions 'RobertsDbContextExtensions').[DbContextExtensions](DbContextExtensions 'RobertsDbContextExtensions.DbContextExtensions')
## DbContextExtensions.LoadDataset(DbContext, DbCommand) Method
Execute the provided command and return its results as a classic ADO.NET DataSet.  
Only provided for migratory purposes. Should be avoided for new code.  
```csharp
public static System.Data.DataSet LoadDataset(this Microsoft.EntityFrameworkCore.DbContext ctx, System.Data.Common.DbCommand cmd);
```
#### Parameters
<a name='RobertsDbContextExtensions_DbContextExtensions_LoadDataset(Microsoft_EntityFrameworkCore_DbContext_System_Data_Common_DbCommand)_ctx'></a>
`ctx` [Microsoft.EntityFrameworkCore.DbContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.EntityFrameworkCore.DbContext 'Microsoft.EntityFrameworkCore.DbContext')  
  
<a name='RobertsDbContextExtensions_DbContextExtensions_LoadDataset(Microsoft_EntityFrameworkCore_DbContext_System_Data_Common_DbCommand)_cmd'></a>
`cmd` [System.Data.Common.DbCommand](https://docs.microsoft.com/en-us/dotnet/api/System.Data.Common.DbCommand 'System.Data.Common.DbCommand')  
  
#### Returns
[System.Data.DataSet](https://docs.microsoft.com/en-us/dotnet/api/System.Data.DataSet 'System.Data.DataSet')  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
