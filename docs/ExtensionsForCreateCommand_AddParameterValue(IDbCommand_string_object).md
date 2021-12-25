### [RobertsDbContextExtensions](RobertsDbContextExtensions 'RobertsDbContextExtensions').[ExtensionsForCreateCommand](ExtensionsForCreateCommand 'RobertsDbContextExtensions.ExtensionsForCreateCommand')
## ExtensionsForCreateCommand.AddParameterValue(IDbCommand, string, object) Method
Add an IDbDataParameter to the provided command using the specified
parameter name and object value.
```csharp
public static void AddParameterValue(this System.Data.IDbCommand cmd, string ParameterName, object Value);
```
#### Parameters
<a name='RobertsDbContextExtensions_ExtensionsForCreateCommand_AddParameterValue(System_Data_IDbCommand_string_object)_cmd'></a>
`cmd` [System.Data.IDbCommand](https://docs.microsoft.com/en-us/dotnet/api/System.Data.IDbCommand 'System.Data.IDbCommand')  
The command to add the specified parameter to.
  
<a name='RobertsDbContextExtensions_ExtensionsForCreateCommand_AddParameterValue(System_Data_IDbCommand_string_object)_ParameterName'></a>
`ParameterName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The name of the parameter (without an @ sign).
  
<a name='RobertsDbContextExtensions_ExtensionsForCreateCommand_AddParameterValue(System_Data_IDbCommand_string_object)_Value'></a>
`Value` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')  
The value of the parameter, null is changed to DBNull.Value
  
