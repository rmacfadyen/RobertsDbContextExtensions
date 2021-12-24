using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
