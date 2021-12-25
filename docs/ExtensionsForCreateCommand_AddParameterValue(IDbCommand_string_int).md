### [RobertsDbContextExtensions](RobertsDbContextExtensions 'RobertsDbContextExtensions').[ExtensionsForCreateCommand](ExtensionsForCreateCommand 'RobertsDbContextExtensions.ExtensionsForCreateCommand')
## ExtensionsForCreateCommand.AddParameterValue(IDbCommand, string, int) Method
Add an IDbDataParameter to the provided command using the specified
parameter name and int value.
```csharp
public static void AddParameterValue(this System.Data.IDbCommand cmd, string ParameterName, int Value);
```
#### Parameters
<a name='RobertsDbContextExtensions_ExtensionsForCreateCommand_AddParameterValue(System_Data_IDbCommand_string_int)_cmd'></a>
`cmd` [System.Data.IDbCommand](https://docs.microsoft.com/en-us/dotnet/api/System.Data.IDbCommand 'System.Data.IDbCommand')  
The command to add the specified parameter to.
  
<a name='RobertsDbContextExtensions_ExtensionsForCreateCommand_AddParameterValue(System_Data_IDbCommand_string_int)_ParameterName'></a>
`ParameterName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The name of the parameter (without an @ sign).
  
<a name='RobertsDbContextExtensions_ExtensionsForCreateCommand_AddParameterValue(System_Data_IDbCommand_string_int)_Value'></a>
`Value` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The value of the parameter.
  
