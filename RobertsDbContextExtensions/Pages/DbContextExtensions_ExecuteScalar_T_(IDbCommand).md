### [RobertsDbContextExtensions](RobertsDbContextExtensions 'RobertsDbContextExtensions').[DbContextExtensions](DbContextExtensions 'RobertsDbContextExtensions.DbContextExtensions')
## DbContextExtensions.ExecuteScalar&lt;T&gt;(IDbCommand) Method
Executes the provided command and returns the first column  
of the first row of the first result set as an T.  
```csharp
public static T ExecuteScalar<T>(this System.Data.IDbCommand cmd);
```
#### Type parameters
<a name='RobertsDbContextExtensions_DbContextExtensions_ExecuteScalar_T_(System_Data_IDbCommand)_T'></a>
`T`  
  
#### Parameters
<a name='RobertsDbContextExtensions_DbContextExtensions_ExecuteScalar_T_(System_Data_IDbCommand)_cmd'></a>
`cmd` [System.Data.IDbCommand](https://docs.microsoft.com/en-us/dotnet/api/System.Data.IDbCommand 'System.Data.IDbCommand')  
  
#### Returns
[T](DbContextExtensions_ExecuteScalar_T_(IDbCommand)#RobertsDbContextExtensions_DbContextExtensions_ExecuteScalar_T_(System_Data_IDbCommand)_T 'RobertsDbContextExtensions.DbContextExtensions.ExecuteScalar&lt;T&gt;(System.Data.IDbCommand).T')  
