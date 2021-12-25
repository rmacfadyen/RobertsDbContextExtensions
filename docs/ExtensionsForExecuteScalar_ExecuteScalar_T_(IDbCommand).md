### [RobertsDbContextExtensions](RobertsDbContextExtensions 'RobertsDbContextExtensions').[ExtensionsForExecuteScalar](ExtensionsForExecuteScalar 'RobertsDbContextExtensions.ExtensionsForExecuteScalar')
## ExtensionsForExecuteScalar.ExecuteScalar&lt;T&gt;(IDbCommand) Method
Executes the provided command and returns the first column
of the first row of the first result set as an T.
```csharp
public static T ExecuteScalar<T>(this System.Data.IDbCommand cmd);
```
#### Type parameters
<a name='RobertsDbContextExtensions_ExtensionsForExecuteScalar_ExecuteScalar_T_(System_Data_IDbCommand)_T'></a>
`T`  
The type the first column of the first row of the first result set will be cast to.
  
#### Parameters
<a name='RobertsDbContextExtensions_ExtensionsForExecuteScalar_ExecuteScalar_T_(System_Data_IDbCommand)_cmd'></a>
`cmd` [System.Data.IDbCommand](https://docs.microsoft.com/en-us/dotnet/api/System.Data.IDbCommand 'System.Data.IDbCommand')  
The command to be executed.
  
#### Returns
[T](ExtensionsForExecuteScalar_ExecuteScalar_T_(IDbCommand)#RobertsDbContextExtensions_ExtensionsForExecuteScalar_ExecuteScalar_T_(System_Data_IDbCommand)_T 'RobertsDbContextExtensions.ExtensionsForExecuteScalar.ExecuteScalar&lt;T&gt;(System.Data.IDbCommand).T')  
The first column
            of the first row of the first result set cast to a T.
