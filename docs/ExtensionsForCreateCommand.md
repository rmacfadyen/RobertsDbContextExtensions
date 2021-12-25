### [RobertsDbContextExtensions](RobertsDbContextExtensions 'RobertsDbContextExtensions')
## ExtensionsForCreateCommand Class
Provides several extension methods relating to IDbCommands
```csharp
public static class ExtensionsForCreateCommand
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ExtensionsForCreateCommand  

| Methods | |
| :--- | :--- |
| [AddParameterValue(IDbCommand, string, bool)](ExtensionsForCreateCommand_AddParameterValue(IDbCommand_string_bool) 'RobertsDbContextExtensions.ExtensionsForCreateCommand.AddParameterValue(System.Data.IDbCommand, string, bool)') | Add an IDbDataParameter to the provided command using the specified parameter name and bool value.  |
| [AddParameterValue(IDbCommand, string, int)](ExtensionsForCreateCommand_AddParameterValue(IDbCommand_string_int) 'RobertsDbContextExtensions.ExtensionsForCreateCommand.AddParameterValue(System.Data.IDbCommand, string, int)') | Add an IDbDataParameter to the provided command using the specified parameter name and int value.  |
| [AddParameterValue(IDbCommand, string, object)](ExtensionsForCreateCommand_AddParameterValue(IDbCommand_string_object) 'RobertsDbContextExtensions.ExtensionsForCreateCommand.AddParameterValue(System.Data.IDbCommand, string, object)') | Add an IDbDataParameter to the provided command using the specified parameter name and object value.  |
| [AddParameterValue(IDbCommand, string, string)](ExtensionsForCreateCommand_AddParameterValue(IDbCommand_string_string) 'RobertsDbContextExtensions.ExtensionsForCreateCommand.AddParameterValue(System.Data.IDbCommand, string, string)') | Add an IDbDataParameter to the provided command using the specified parameter name and string value. Null strings are passed as DbNull.Value.  |
| [AddParameterValue(IDbCommand, string, DBNull)](ExtensionsForCreateCommand_AddParameterValue(IDbCommand_string_DBNull) 'RobertsDbContextExtensions.ExtensionsForCreateCommand.AddParameterValue(System.Data.IDbCommand, string, System.DBNull)') | Add an IDbDataParameter to the provided command using the specified parameter name and NULL value. The underlying DbType of the parameter is always string.  |
| [CreateCommand(DbContext, string, object[])](ExtensionsForCreateCommand_CreateCommand(DbContext_string_object__) 'RobertsDbContextExtensions.ExtensionsForCreateCommand.CreateCommand(Microsoft.EntityFrameworkCore.DbContext, string, object[])') | Create an DbCommand and populate its parameters (if necesary)  |
