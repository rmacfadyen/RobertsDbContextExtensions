### [RobertsDbContextExtensions](RobertsDbContextExtensions 'RobertsDbContextExtensions').[ExtensionsForExecuteStream](ExtensionsForExecuteStream 'RobertsDbContextExtensions.ExtensionsForExecuteStream')
## ExtensionsForExecuteStream.ExecuteStream(IDbCommand) Method
Execute the provided command and return a stream from the database. This is
indended for accessing BLOBs stored in the database efficiently.
```csharp
public static System.IO.Stream ExecuteStream(this System.Data.IDbCommand cmd);
```
#### Parameters
<a name='RobertsDbContextExtensions_ExtensionsForExecuteStream_ExecuteStream(System_Data_IDbCommand)_cmd'></a>
`cmd` [System.Data.IDbCommand](https://docs.microsoft.com/en-us/dotnet/api/System.Data.IDbCommand 'System.Data.IDbCommand')  
The command to be executed.
  
#### Returns
[System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')  
A stream that reads directly from the database.
