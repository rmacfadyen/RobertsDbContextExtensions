### [RobertsDbContextExtensions](RobertsDbContextExtensions 'RobertsDbContextExtensions')
## CommandExtensions Class
Provides several extension methods relating to IDbCommands
```csharp
public static class CommandExtensions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; CommandExtensions  

| Methods | |
| :--- | :--- |
| [AddParameterValue(IDbCommand, string, bool)](CommandExtensions_AddParameterValue(IDbCommand_string_bool) 'RobertsDbContextExtensions.CommandExtensions.AddParameterValue(System.Data.IDbCommand, string, bool)') | Add an IDbDataParameter to the provided command using the specified parameter name and bool value.  |
| [AddParameterValue(IDbCommand, string, int)](CommandExtensions_AddParameterValue(IDbCommand_string_int) 'RobertsDbContextExtensions.CommandExtensions.AddParameterValue(System.Data.IDbCommand, string, int)') | Add an IDbDataParameter to the provided command using the specified parameter name and int value.  |
| [AddParameterValue(IDbCommand, string, object)](CommandExtensions_AddParameterValue(IDbCommand_string_object) 'RobertsDbContextExtensions.CommandExtensions.AddParameterValue(System.Data.IDbCommand, string, object)') | Add an IDbDataParameter to the provided command using the specified parameter name and object value.  |
| [AddParameterValue(IDbCommand, string, string)](CommandExtensions_AddParameterValue(IDbCommand_string_string) 'RobertsDbContextExtensions.CommandExtensions.AddParameterValue(System.Data.IDbCommand, string, string)') | Add an IDbDataParameter to the provided command using the specified parameter name and string value. Null strings are passed as DbNull.Value.  |
| [AddParameterValue(IDbCommand, string, DBNull)](CommandExtensions_AddParameterValue(IDbCommand_string_DBNull) 'RobertsDbContextExtensions.CommandExtensions.AddParameterValue(System.Data.IDbCommand, string, System.DBNull)') | Add an IDbDataParameter to the provided command using the specified parameter name and NULL value. The underlying DbType of the parameter is always string.  |
| [CreateCommand(DbContext, string, object[])](CommandExtensions_CreateCommand(DbContext_string_object__) 'RobertsDbContextExtensions.CommandExtensions.CreateCommand(Microsoft.EntityFrameworkCore.DbContext, string, object[])') | Create an DbCommand and populate its parameters (if necesary)  |
| [ExecuteScalar&lt;T&gt;(IDbCommand)](CommandExtensions_ExecuteScalar_T_(IDbCommand) 'RobertsDbContextExtensions.CommandExtensions.ExecuteScalar&lt;T&gt;(System.Data.IDbCommand)') | Executes the provided command and returns the first column of the first row of the first result set as an T.  |
| [ExecuteScalarStream(IDbCommand)](CommandExtensions_ExecuteScalarStream(IDbCommand) 'RobertsDbContextExtensions.CommandExtensions.ExecuteScalarStream(System.Data.IDbCommand)') | Execute the provided command and return a stream from the database. This is indended for accessing BLOBs stored in the database efficiently.  |
