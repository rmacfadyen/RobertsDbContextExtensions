### [RobertsDbContextExtensions](RobertsDbContextExtensions 'RobertsDbContextExtensions')
## DynamicListExtensions Class
Extensions that load a lists that includes dynamic columns
```csharp
public static class DynamicListExtensions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; DynamicListExtensions  

| Methods | |
| :--- | :--- |
| [ExecuteDynamicList&lt;T&gt;(DbContext, string, IEnumerable&lt;string&gt;, object[])](DynamicListExtensions_ExecuteDynamicList_T_(DbContext_string_IEnumerable_string__object__) 'RobertsDbContextExtensions.DynamicListExtensions.ExecuteDynamicList&lt;T&gt;(Microsoft.EntityFrameworkCore.DbContext, string, System.Collections.Generic.IEnumerable&lt;string&gt;, object[])') | A dynamic list is a regular POCO object with one property defined as an object[]. This array will be populated with column values as passed in the DynmaicColumnNames list (in the same order). The other properties on the object will be populated as normal.  |
| [ExecuteDynamicList(DbContext, IEnumerable&lt;Type&gt;, string, IEnumerable&lt;string&gt;, object[])](DynamicListExtensions_ExecuteDynamicList(DbContext_IEnumerable_Type__string_IEnumerable_string__object__) 'RobertsDbContextExtensions.DynamicListExtensions.ExecuteDynamicList(Microsoft.EntityFrameworkCore.DbContext, System.Collections.Generic.IEnumerable&lt;System.Type&gt;, string, System.Collections.Generic.IEnumerable&lt;string&gt;, object[])') | When you have a query that consists of several result sets, and the first result contains columns that are not known in  advanced, then ExecuteDynamicList is your ticket.  |
