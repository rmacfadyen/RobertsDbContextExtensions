### [RobertsDbContextExtensions](RobertsDbContextExtensions 'RobertsDbContextExtensions').[DbContextExtensions](DbContextExtensions 'RobertsDbContextExtensions.DbContextExtensions')
## DbContextExtensions.LoadDataset&lt;T1,T2&gt;(DbContext, DbCommand, string, Action&lt;T1,IList&lt;T2&gt;&gt;, string) Method
Executes the provided command and returns a list of T1's that
have had their child records populated via the provided assignment
lambda. 
```csharp
public static System.Collections.Generic.IList<T1> LoadDataset<T1,T2>(this Microsoft.EntityFrameworkCore.DbContext ctx, System.Data.Common.DbCommand cmd, string T1Column, System.Action<T1,System.Collections.Generic.IList<T2>> Assignment, string T2Column=null)
    where T1 : new();
```
#### Type parameters
<a name='RobertsDbContextExtensions_DbContextExtensions_LoadDataset_T1_T2_(Microsoft_EntityFrameworkCore_DbContext_System_Data_Common_DbCommand_string_System_Action_T1_System_Collections_Generic_IList_T2___string)_T1'></a>
`T1`  
  
<a name='RobertsDbContextExtensions_DbContextExtensions_LoadDataset_T1_T2_(Microsoft_EntityFrameworkCore_DbContext_System_Data_Common_DbCommand_string_System_Action_T1_System_Collections_Generic_IList_T2___string)_T2'></a>
`T2`  
  
#### Parameters
<a name='RobertsDbContextExtensions_DbContextExtensions_LoadDataset_T1_T2_(Microsoft_EntityFrameworkCore_DbContext_System_Data_Common_DbCommand_string_System_Action_T1_System_Collections_Generic_IList_T2___string)_ctx'></a>
`ctx` [Microsoft.EntityFrameworkCore.DbContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.EntityFrameworkCore.DbContext 'Microsoft.EntityFrameworkCore.DbContext')  
  
<a name='RobertsDbContextExtensions_DbContextExtensions_LoadDataset_T1_T2_(Microsoft_EntityFrameworkCore_DbContext_System_Data_Common_DbCommand_string_System_Action_T1_System_Collections_Generic_IList_T2___string)_cmd'></a>
`cmd` [System.Data.Common.DbCommand](https://docs.microsoft.com/en-us/dotnet/api/System.Data.Common.DbCommand 'System.Data.Common.DbCommand')  
  
<a name='RobertsDbContextExtensions_DbContextExtensions_LoadDataset_T1_T2_(Microsoft_EntityFrameworkCore_DbContext_System_Data_Common_DbCommand_string_System_Action_T1_System_Collections_Generic_IList_T2___string)_T1Column'></a>
`T1Column` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
  
<a name='RobertsDbContextExtensions_DbContextExtensions_LoadDataset_T1_T2_(Microsoft_EntityFrameworkCore_DbContext_System_Data_Common_DbCommand_string_System_Action_T1_System_Collections_Generic_IList_T2___string)_Assignment'></a>
`Assignment` [System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-2 'System.Action`2')[T1](DbContextExtensions_LoadDataset_T1_T2_(DbContext_DbCommand_string_Action_T1_IList_T2___string)#RobertsDbContextExtensions_DbContextExtensions_LoadDataset_T1_T2_(Microsoft_EntityFrameworkCore_DbContext_System_Data_Common_DbCommand_string_System_Action_T1_System_Collections_Generic_IList_T2___string)_T1 'RobertsDbContextExtensions.DbContextExtensions.LoadDataset&lt;T1,T2&gt;(Microsoft.EntityFrameworkCore.DbContext, System.Data.Common.DbCommand, string, System.Action&lt;T1,System.Collections.Generic.IList&lt;T2&gt;&gt;, string).T1')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Action-2 'System.Action`2')[System.Collections.Generic.IList&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[T2](DbContextExtensions_LoadDataset_T1_T2_(DbContext_DbCommand_string_Action_T1_IList_T2___string)#RobertsDbContextExtensions_DbContextExtensions_LoadDataset_T1_T2_(Microsoft_EntityFrameworkCore_DbContext_System_Data_Common_DbCommand_string_System_Action_T1_System_Collections_Generic_IList_T2___string)_T2 'RobertsDbContextExtensions.DbContextExtensions.LoadDataset&lt;T1,T2&gt;(Microsoft.EntityFrameworkCore.DbContext, System.Data.Common.DbCommand, string, System.Action&lt;T1,System.Collections.Generic.IList&lt;T2&gt;&gt;, string).T2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-2 'System.Action`2')  
  
<a name='RobertsDbContextExtensions_DbContextExtensions_LoadDataset_T1_T2_(Microsoft_EntityFrameworkCore_DbContext_System_Data_Common_DbCommand_string_System_Action_T1_System_Collections_Generic_IList_T2___string)_T2Column'></a>
`T2Column` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
  
#### Returns
[System.Collections.Generic.IList&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[T1](DbContextExtensions_LoadDataset_T1_T2_(DbContext_DbCommand_string_Action_T1_IList_T2___string)#RobertsDbContextExtensions_DbContextExtensions_LoadDataset_T1_T2_(Microsoft_EntityFrameworkCore_DbContext_System_Data_Common_DbCommand_string_System_Action_T1_System_Collections_Generic_IList_T2___string)_T1 'RobertsDbContextExtensions.DbContextExtensions.LoadDataset&lt;T1,T2&gt;(Microsoft.EntityFrameworkCore.DbContext, System.Data.Common.DbCommand, string, System.Action&lt;T1,System.Collections.Generic.IList&lt;T2&gt;&gt;, string).T1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
