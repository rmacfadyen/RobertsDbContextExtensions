### [RobertsDbContextExtensions](RobertsDbContextExtensions 'RobertsDbContextExtensions').[ExtensionsForCreateCommand](ExtensionsForCreateCommand 'RobertsDbContextExtensions.ExtensionsForCreateCommand')
## ExtensionsForCreateCommand.AddParameterValue(IDbCommand, string, bool) Method
Add an IDbDataParameter to the provided command using the specified
parameter name and bool value.
```csharp
public static void AddParameterValue(this System.Data.IDbCommand cmd, string ParameterName, bool Value);
```
#### Parameters
<a name='RobertsDbContextExtensions_ExtensionsForCreateCommand_AddParameterValue(System_Data_IDbCommand_string_bool)_cmd'></a>
`cmd` [System.Data.IDbCommand](https://docs.microsoft.com/en-us/dotnet/api/System.Data.IDbCommand 'System.Data.IDbCommand')  
The command to add the specified parameter to.
  
<a name='RobertsDbContextExtensions_ExtensionsForCreateCommand_AddParameterValue(System_Data_IDbCommand_string_bool)_ParameterName'></a>
`ParameterName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The name of the parameter (without an @ sign).
  
<a name='RobertsDbContextExtensions_ExtensionsForCreateCommand_AddParameterValue(System_Data_IDbCommand_string_bool)_Value'></a>
`Value` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
The value of the parameter.
  
