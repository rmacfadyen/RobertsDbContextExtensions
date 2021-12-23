### [RobertsDbContextExtensions](RobertsDbContextExtensions 'RobertsDbContextExtensions').[DbContextExtensions](DbContextExtensions 'RobertsDbContextExtensions.DbContextExtensions')
## DbContextExtensions.AddParameterValue(IDbCommand, string, string) Method
Add an IDbDataParameter to the provided command using the specified
parameter name and string value. Null strings are passed as DbNull.Value.
```csharp
public static void AddParameterValue(this System.Data.IDbCommand cmd, string ParameterName, string Value);
```
#### Parameters
<a name='RobertsDbContextExtensions_DbContextExtensions_AddParameterValue(System_Data_IDbCommand_string_string)_cmd'></a>
`cmd` [System.Data.IDbCommand](https://docs.microsoft.com/en-us/dotnet/api/System.Data.IDbCommand 'System.Data.IDbCommand')  
  
<a name='RobertsDbContextExtensions_DbContextExtensions_AddParameterValue(System_Data_IDbCommand_string_string)_ParameterName'></a>
`ParameterName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
  
<a name='RobertsDbContextExtensions_DbContextExtensions_AddParameterValue(System_Data_IDbCommand_string_string)_Value'></a>
`Value` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
  
