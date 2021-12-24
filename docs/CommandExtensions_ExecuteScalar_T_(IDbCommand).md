### [RobertsDbContextExtensions](RobertsDbContextExtensions 'RobertsDbContextExtensions').[CommandExtensions](CommandExtensions 'RobertsDbContextExtensions.CommandExtensions')
## CommandExtensions.ExecuteScalar&lt;T&gt;(IDbCommand) Method
Executes the provided command and returns the first column
of the first row of the first result set as an T.
```csharp
public static T ExecuteScalar<T>(this System.Data.IDbCommand cmd);
```
#### Type parameters
<a name='RobertsDbContextExtensions_CommandExtensions_ExecuteScalar_T_(System_Data_IDbCommand)_T'></a>
`T`  
The type the first column of the first row of the first result set will be cast to.
  
#### Parameters
<a name='RobertsDbContextExtensions_CommandExtensions_ExecuteScalar_T_(System_Data_IDbCommand)_cmd'></a>
`cmd` [System.Data.IDbCommand](https://docs.microsoft.com/en-us/dotnet/api/System.Data.IDbCommand 'System.Data.IDbCommand')  
The command to be executed.
  
#### Returns
[T](CommandExtensions_ExecuteScalar_T_(IDbCommand)#RobertsDbContextExtensions_CommandExtensions_ExecuteScalar_T_(System_Data_IDbCommand)_T 'RobertsDbContextExtensions.CommandExtensions.ExecuteScalar&lt;T&gt;(System.Data.IDbCommand).T')  
The first column
            of the first row of the first result set cast to a T.
