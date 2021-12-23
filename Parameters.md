## Passing Parameters

Several methods accept a list of parameters to be passed to SQL as a "params object[]". 
Each object is one of:

- A primitive type or string will be converted to a a numbered parameter (eg. @p0, @p1, @p2 and so forth).
- An IDictionary<string, string> will have its entries converted to a list of named properties.
- An IDictionary<string, object> will have its entries converted to a list of named properties.
- Or, finally, an object who's public properties will be converted to a list of named parmeters.

Consider the following:

```c#
    var Sql = @"[... something complex ...]";

    int CustomerId = 1701;
    string CustomerName = "The Lumbar Board";
    bool SoftDeleted = "Not Deleted";

    var d1 = new Dictionary<string, string> = {
        { "key1", "v1" },
        { "key2", "v2" }
    };

    var d2 = new Dictionary<string, object> = {
        { "b1", 12.5m },
        { "b2", DateTime.Now }
    };

    var p3 = new {
        c1 = false,
        c2 = Guid.Empty
    };

    var cmd = ctx.CreateCommand(Sql, CustomerId, CustomerName, d1, d2, p3, SoftDeleted)
```

The command will be created with the following parameters:
- @p0 = 1701
- @p1 = "The Lumbar Board"
- @key1 = "v1"
- @key2 = "v2"
- @b1 = 12.5m
- @b2 = 12/12/2021 17:23:12.21234
- @c1 = false
- @c2 = 00000000-0000-0000-0000-000000000000
- @p2 = "Not Deleted"

Typically, an anonymous class instance is used like so:
```c#
    var Sql = @"[... something complex ...]";
    var cmd = ctx.CreateCommand(Sql, new {
        c1 = false,
        c2 = Guid.Empty
    });
```
or
```c#
    var CustomerId = 1701;
    var CustomerName = "The Lumbar Board";

    var Sql = @"[... something complex ...]";
    var cmd = ctx.CreateCommand(Sql, new {
        CustomerId,
        CustomerName
    });
```

