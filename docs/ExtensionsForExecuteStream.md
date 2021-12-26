### [RobertsDbContextExtensions](RobertsDbContextExtensions 'RobertsDbContextExtensions')
## ExtensionsForExecuteStream Class
ADO.NET supports efficient reading of BLOB data by using the
CommandBehavior.SequentialAccess flag. By wrapping the returned
IDataReader in a slim readonly stream you can read and process
a BLOB without loading it entirely into memory. 

Perfect when dealing with files that have been stored in a database 
and need to be beamed down to a client (eg. browser) without requiring
the webserver to hold the entire BLOB in memory.
```csharp
public static class ExtensionsForExecuteStream
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ExtensionsForExecuteStream  

| Methods | |
| :--- | :--- |
| [ExecuteStream(DbContext, string, object[])](ExtensionsForExecuteStream_ExecuteStream(DbContext_string_object__) 'RobertsDbContextExtensions.ExtensionsForExecuteStream.ExecuteStream(Microsoft.EntityFrameworkCore.DbContext, string, object[])') | Execute the provided SQL and return a stream from the database. This is indended for accessing BLOBs stored in the database efficiently.  |
| [ExecuteStream(IDbCommand)](ExtensionsForExecuteStream_ExecuteStream(IDbCommand) 'RobertsDbContextExtensions.ExtensionsForExecuteStream.ExecuteStream(System.Data.IDbCommand)') | Execute the provided command and return a stream from the database. This is indended for accessing BLOBs stored in the database efficiently.  |
