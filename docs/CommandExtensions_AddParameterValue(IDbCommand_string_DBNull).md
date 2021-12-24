### [RobertsDbContextExtensions](RobertsDbContextExtensions 'RobertsDbContextExtensions').[CommandExtensions](CommandExtensions 'RobertsDbContextExtensions.CommandExtensions')
## CommandExtensions.AddParameterValue(IDbCommand, string, DBNull) Method
Add an IDbDataParameter to the provided command using the specified
parameter name and NULL value. The underlying DbType of the parameter
is always string.
```csharp
public static void AddParameterValue(this System.Data.IDbCommand cmd, string ParameterName, System.DBNull Value);
```
#### Parameters
<a name='RobertsDbContextExtensions_CommandExtensions_AddParameterValue(System_Data_IDbCommand_string_System_DBNull)_cmd'></a>
`cmd` [System.Data.IDbCommand](https://docs.microsoft.com/en-us/dotnet/api/System.Data.IDbCommand 'System.Data.IDbCommand')  
The command to add the specified parameter to.
  
<a name='RobertsDbContextExtensions_CommandExtensions_AddParameterValue(System_Data_IDbCommand_string_System_DBNull)_ParameterName'></a>
`ParameterName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The name of the parameter (without an @ sign).
  
<a name='RobertsDbContextExtensions_CommandExtensions_AddParameterValue(System_Data_IDbCommand_string_System_DBNull)_Value'></a>
`Value` [System.DBNull](https://docs.microsoft.com/en-us/dotnet/api/System.DBNull 'System.DBNull')  
Must be DBNull.Value
  
### Remarks
In certain situations it can be tricky to correctly pass a NULL value
as a parameter via code. This method allows for explicitly adding a
string parameter will a NULL value.
