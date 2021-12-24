### [RobertsDbContextExtensions](RobertsDbContextExtensions 'RobertsDbContextExtensions')
## IDbCommandExtensions Class
Provides several extension methods relating to IDbCommands
```csharp
public static class IDbCommandExtensions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; IDbCommandExtensions  

| Methods | |
| :--- | :--- |
| [AddParameterValue(IDbCommand, string, bool)](IDbCommandExtensions_AddParameterValue(IDbCommand_string_bool) 'RobertsDbContextExtensions.IDbCommandExtensions.AddParameterValue(System.Data.IDbCommand, string, bool)') | Add an IDbDataParameter to the provided command using the specified parameter name and bool value.  |
| [AddParameterValue(IDbCommand, string, int)](IDbCommandExtensions_AddParameterValue(IDbCommand_string_int) 'RobertsDbContextExtensions.IDbCommandExtensions.AddParameterValue(System.Data.IDbCommand, string, int)') | Add an IDbDataParameter to the provided command using the specified parameter name and int value.  |
| [AddParameterValue(IDbCommand, string, object)](IDbCommandExtensions_AddParameterValue(IDbCommand_string_object) 'RobertsDbContextExtensions.IDbCommandExtensions.AddParameterValue(System.Data.IDbCommand, string, object)') | Add an IDbDataParameter to the provided command using the specified parameter name and object value.  |
| [AddParameterValue(IDbCommand, string, string)](IDbCommandExtensions_AddParameterValue(IDbCommand_string_string) 'RobertsDbContextExtensions.IDbCommandExtensions.AddParameterValue(System.Data.IDbCommand, string, string)') | Add an IDbDataParameter to the provided command using the specified parameter name and string value. Null strings are passed as DbNull.Value.  |
| [AddParameterValue(IDbCommand, string, DBNull)](IDbCommandExtensions_AddParameterValue(IDbCommand_string_DBNull) 'RobertsDbContextExtensions.IDbCommandExtensions.AddParameterValue(System.Data.IDbCommand, string, System.DBNull)') | Add an IDbDataParameter to the provided command using the specified parameter name and NULL value. The underlying DbType of the parameter is always string.  |
| [CreateCommand(DbContext, string, object[])](IDbCommandExtensions_CreateCommand(DbContext_string_object__) 'RobertsDbContextExtensions.IDbCommandExtensions.CreateCommand(Microsoft.EntityFrameworkCore.DbContext, string, object[])') | Create an DbCommand and populate its parameters (if necesary)  |
| [ExecuteScalar&lt;T&gt;(IDbCommand)](IDbCommandExtensions_ExecuteScalar_T_(IDbCommand) 'RobertsDbContextExtensions.IDbCommandExtensions.ExecuteScalar&lt;T&gt;(System.Data.IDbCommand)') | Executes the provided command and returns the first column of the first row of the first result set as an T.  |
| [ExecuteScalarStream(IDbCommand)](IDbCommandExtensions_ExecuteScalarStream(IDbCommand) 'RobertsDbContextExtensions.IDbCommandExtensions.ExecuteScalarStream(System.Data.IDbCommand)') | Execute the provided command and return a stream from the database. This is indended for accessing BLOBs stored in the database efficiently.  |
