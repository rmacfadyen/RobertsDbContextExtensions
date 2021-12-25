### [RobertsDbContextExtensions](RobertsDbContextExtensions 'RobertsDbContextExtensions')
## ExtensionsForExecuteDynamicList Class
Extensions that load a lists that includes dynamic columns. The key concept
behind ExecuteDynamicList is where the list of fields retrived by the
query can vary at runtime. Because the list is dynamic at runtime a simple
POCO class by itself isn't sufficient.

To solve the problem ExecuteDynamicList relies on the POCO containing a
plain array of object values. For example:
```csharp
public static class ExtensionsForExecuteDynamicList
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ExtensionsForExecuteDynamicList  
### Example
public class MyDynamicData
{
    public string FieldOne { get; set; } // always included in the query
    public object[] AdditionalFields { get; set; } // populated based on a list of field names
}

public ILIst<MyDynamicData> GetData(bool IncludeAdditionalFields)
{
    string Sql;
    string[] AdditionalFields;
    
    if (IncludeAdditionalFields)
    {
        Sql = "select FieldOne, FieldTwo, FieldThree from MyTable";
        AdditionalFields = new[] { "FieldTwo", "FieldThree" };
    }
    else
    {
        Sql = "select FieldOne, FieldTwo, FieldThree from MyTable";
        AdditionalFields = null;
    }
   
    return ctx.ExecuteDynamicList(Sql, AdditionalColumns);
}

| Methods | |
| :--- | :--- |
| [ExecuteDynamicList&lt;T&gt;(DbContext, string, IEnumerable&lt;string&gt;, object[])](ExtensionsForExecuteDynamicList_ExecuteDynamicList_T_(DbContext_string_IEnumerable_string__object__) 'RobertsDbContextExtensions.ExtensionsForExecuteDynamicList.ExecuteDynamicList&lt;T&gt;(Microsoft.EntityFrameworkCore.DbContext, string, System.Collections.Generic.IEnumerable&lt;string&gt;, object[])') | A dynamic list is a regular POCO object with one property defined as an object[]. This array will be populated with column values as passed in the DynmaicColumnNames list (in the same order). The other properties on the object will be populated as normal.  |
| [ExecuteDynamicList&lt;T&gt;(DbContext, IDbCommand, IEnumerable&lt;string&gt;)](ExtensionsForExecuteDynamicList_ExecuteDynamicList_T_(DbContext_IDbCommand_IEnumerable_string_) 'RobertsDbContextExtensions.ExtensionsForExecuteDynamicList.ExecuteDynamicList&lt;T&gt;(Microsoft.EntityFrameworkCore.DbContext, System.Data.IDbCommand, System.Collections.Generic.IEnumerable&lt;string&gt;)') | A dynamic list is a regular POCO object with one property defined as an object[]. This array will be populated with column values as passed in the DynmaicColumnNames list (in the same order). The other properties on the object will be populated as normal.  |
| [ExecuteDynamicList(DbContext, IEnumerable&lt;Type&gt;, string, IEnumerable&lt;string&gt;, object[])](ExtensionsForExecuteDynamicList_ExecuteDynamicList(DbContext_IEnumerable_Type__string_IEnumerable_string__object__) 'RobertsDbContextExtensions.ExtensionsForExecuteDynamicList.ExecuteDynamicList(Microsoft.EntityFrameworkCore.DbContext, System.Collections.Generic.IEnumerable&lt;System.Type&gt;, string, System.Collections.Generic.IEnumerable&lt;string&gt;, object[])') | When you have a query that consists of several result sets, and the first result contains columns that are not known in  advanced, then ExecuteDynamicList is your ticket.  |
| [ExecuteDynamicList(DbContext, IEnumerable&lt;Type&gt;, IEnumerable&lt;string&gt;, DbCommand)](ExtensionsForExecuteDynamicList_ExecuteDynamicList(DbContext_IEnumerable_Type__IEnumerable_string__DbCommand) 'RobertsDbContextExtensions.ExtensionsForExecuteDynamicList.ExecuteDynamicList(Microsoft.EntityFrameworkCore.DbContext, System.Collections.Generic.IEnumerable&lt;System.Type&gt;, System.Collections.Generic.IEnumerable&lt;string&gt;, System.Data.Common.DbCommand)') | When you have a query that consists of several result sets, and the first result contains columns that are not known in  advanced, then ExecuteDynamicList is your ticket.  |
