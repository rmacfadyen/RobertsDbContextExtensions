### [RobertsDbContextExtensions](RobertsDbContextExtensions 'RobertsDbContextExtensions').[DbContextExtensions](DbContextExtensions 'RobertsDbContextExtensions.DbContextExtensions')
## DbContextExtensions.ExecuteScalarStream(IDbCommand) Method
Execute the provided command and return a stream from the database. This is  
indended for accessing BLOBs stored in the database efficiently.  
```csharp
public static System.IO.Stream ExecuteScalarStream(this System.Data.IDbCommand cmd);
```
#### Parameters
<a name='RobertsDbContextExtensions_DbContextExtensions_ExecuteScalarStream(System_Data_IDbCommand)_cmd'></a>
`cmd` [System.Data.IDbCommand](https://docs.microsoft.com/en-us/dotnet/api/System.Data.IDbCommand 'System.Data.IDbCommand')  
  
#### Returns
[System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')  
