### [RobertsDbContextExtensions](RobertsDbContextExtensions 'RobertsDbContextExtensions').[DbContextExtensions](DbContextExtensions 'RobertsDbContextExtensions.DbContextExtensions')
## DbContextExtensions.AddParameterValue(IDbCommand, string, DBNull) Method
Add an IDbDataParameter to the provided command using the specified
parameter name and NULL value. The underlying DbType of the parameter
is always string.
```csharp
public static void AddParameterValue(this System.Data.IDbCommand cmd, string ParameterName, System.DBNull Value);
```
#### Parameters
<a name='RobertsDbContextExtensions_DbContextExtensions_AddParameterValue(System_Data_IDbCommand_string_System_DBNull)_cmd'></a>
`cmd` [System.Data.IDbCommand](https://docs.microsoft.com/en-us/dotnet/api/System.Data.IDbCommand 'System.Data.IDbCommand')  
  
<a name='RobertsDbContextExtensions_DbContextExtensions_AddParameterValue(System_Data_IDbCommand_string_System_DBNull)_ParameterName'></a>
`ParameterName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
  
<a name='RobertsDbContextExtensions_DbContextExtensions_AddParameterValue(System_Data_IDbCommand_string_System_DBNull)_Value'></a>
`Value` [System.DBNull](https://docs.microsoft.com/en-us/dotnet/api/System.DBNull 'System.DBNull')  
  
