global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Storage;
global using System.Collections.Concurrent;
global using System.Data;
global using System.Data.Common;
global using System.Reflection;
global using System.Runtime.CompilerServices;
global using System.Linq.Expressions;

[assembly: InternalsVisibleTo("RobertsDbContextExtensionsTests")]

namespace RobertsDbContextExtensions
{
    /// <summary>
    /// The original inspiration for these extensions came from ADO.NET's ExecuteScalar(..) method.
    /// It was clear that with a little generic magic it could have been so much easier to use.
    /// The same for constructing command objects, just so many of the same steps repeated over
    /// and over.Data tables are also fairly pondorous, especially when a simple IList&lt;T&gt; would
    /// be so much easier to deal with.
    /// </summary>
    internal static class NamespaceDoc { } // internal so it is not visible outside the assembly
}
