namespace RobertsDbContextExtensions
{
    /// <summary>
    /// Extensions that load a lists that includes dynamic columns. The key concept
    /// behind ExecuteDynamicList is where the list of fields retrived by the
    /// query can vary at runtime. Because the list is dynamic at runtime a simple
    /// POCO class by itself isn't sufficient.
    /// 
    /// To solve the problem ExecuteDynamicList relies on the POCO containing a
    /// plain array of object values. For example:
    /// </summary>
    /// <example>
    /// public class MyDynamicData
    /// {
    ///     public string FieldOne { get; set; } // always included in the query
    ///     public object[] AdditionalFields { get; set; } // populated based on a list of field names
    /// }
    /// 
    /// public ILIst&lt;MyDynamicData> GetData(bool IncludeAdditionalFields)
    /// {
    ///     string Sql;
    ///     string[] AdditionalFields;
    ///     
    ///     if (IncludeAdditionalFields)
    ///     {
    ///         Sql = "select FieldOne, FieldTwo, FieldThree from MyTable";
    ///         AdditionalFields = new[] { "FieldTwo", "FieldThree" };
    ///     }
    ///     else
    ///     {
    ///         Sql = "select FieldOne, FieldTwo, FieldThree from MyTable";
    ///         AdditionalFields = null;
    ///     }
    ///    
    ///     return ctx.ExecuteDynamicList(Sql, AdditionalColumns);
    /// }
    /// </example>
    public static class ExtensionsForExecuteDynamicList
    {
        /// <summary>
        /// A dynamic list is a regular POCO object with one property defined
        /// as an object[]. This array will be populated with column values
        /// as passed in the DynmaicColumnNames list (in the same order). The
        /// other properties on the object will be populated as normal.
        /// </summary>
        /// <remarks>
        /// This is a bit tricky to do, but also surprisingly straight-forward.
        /// When we decide whether we're reading a value or an object we now
        /// decide between value, dynamic, or object. For dynamic we figure
        /// out the FastProperty setter (just once, not once per record) and
        /// calculate a mapping between column ordinals (what a DbDataReader
        /// operates on) and column names. 
        /// 
        /// We then loop through the data reader, populate the regular properties,
        /// then pull out any dynamic properties into a list. Finally we assign
        /// the list to the fast property for the object[] property.
        /// 
        /// The end result is that we can have a class like:
        ///   class MyRecord {
        ///     public int i { get; set; }
        ///     public object[] values {get; set; }
        ///   }
        /// and have it populated from a simple query like:
        ///   var r = ctx.ExecuteDynamicList&lt;MyRecord&gt;("select i, j, k from tbl", new List&lt;string&gt; { "j", "k" })
        /// which populates: r.i, r.values[0], and r.values[1]
        /// 
        /// It is up to the caller to track the order of columns in the object array.
        /// This is mostly done for an expected performance gain (duplicating the
        /// mapping on every row/instance seems wasteful, even if it's only a reference)
        /// </remarks>
        /// <typeparam name="T">The type the first result set should be mapped to. Must include an object[] property to 
        /// hold the list of values for the columns from DynamicColumnNames.</typeparam>
        /// <param name="ctx">The DbContext to execute the SQL on.</param>
        /// <param name="Sql">The SQL to be executed.</param>
        /// <param name="DynamicColumnNames">A list of columns names who's values will populate
        /// the first object[] property on T.</param>
        /// <param name="Parameters">A list of values to be passed as parameters. See <see href="https://github.com/rmacfadyen/RobertsDbContextExtensions/blob/master/Parameters.md">Passing parameters</see></param>
        /// <returns>The first result set mapped to a list of T's, with the columns
        /// specified as dynamic loaded into the first object[] property on T.
        /// </returns>
        public static IList<T> ExecuteDynamicList<T>(
            this DbContext ctx, string Sql, IEnumerable<string> DynamicColumnNames, params object[] Parameters
        )
        {
            return ctx.ExecuteReaderFromSql(
                Helpers.ListFromDbReader<T>,
                DynamicColumnNames,
                Sql,
                Parameters
            );
        }


        /// <summary>
        /// A dynamic list is a regular POCO object with one property defined
        /// as an object[]. This array will be populated with column values
        /// as passed in the DynmaicColumnNames list (in the same order). The
        /// other properties on the object will be populated as normal.
        /// </summary>
        /// <see cref="ExecuteDynamicList(DbContext, IEnumerable{Type}, string, IEnumerable{string}, object[])"/>
        /// <typeparam name="T">The type the first result set should be mapped to. Must include an object[] property to 
        /// hold the list of values for the columns from DynamicColumnNames.</typeparam>
        /// <param name="ctx">The DbContext to execute the SQL on.</param>
        /// <param name="cmd">The command to be executed.</param>
        /// <param name="DynamicColumnNames">A list of columns names who's values will populate
        /// the first object[] property on T.</param>
        /// <returns>The first result set mapped to a list of T's, with the columns
        /// specified as dynamic loaded into the first object[] property on T.
        /// </returns>
        public static IList<T> ExecuteDynamicList<T>(
            this DbContext ctx, IDbCommand cmd, IEnumerable<string> DynamicColumnNames
        )
        {
            return ctx.ExecuteReaderFromCmd(
                Helpers.ListFromDbReader<T>,
                DynamicColumnNames,
                cmd
            );
        }

        /// <summary>
        /// When you have a query that consists of several result sets,
        /// and the first result contains columns that are not known in 
        /// advanced, then ExecuteDynamicList is your ticket.
        /// </summary>
        /// <param name="ctx">The DbContext to execute the SQL on.</param>
        /// <param name="Types">A list of Types the query's result sets will be
        /// mapped to. The first type must have an object[] property to hold
        /// the dynamic column values.</param>
        /// <param name="Sql">The SQL to be executed.</param>
        /// <param name="DynamicColumnNames">A list of columns names who's values will populate
        /// the first object[] property on T.</param>
        /// <param name="Parameters">A list of values to be passed as parameters. See <see href="https://github.com/rmacfadyen/RobertsDbContextExtensions/blob/master/Parameters.md">Passing parameters</see></param>
        /// <returns>A list of lists. Each list corresponds to the type from the Types parameter.</returns>
        public static IList<object> ExecuteDynamicList(
            this DbContext ctx,
            IEnumerable<Type> Types,
            string Sql,
            IEnumerable<string> DynamicColumnNames = null,
            params object[] Parameters
        )
        {
            using var cmd = ctx.CreateCommand(Sql, Parameters);

            return ExecuteDynamicList(ctx, Types, DynamicColumnNames, cmd);
        }


        /// <summary>
        /// When you have a query that consists of several result sets,
        /// and the first result contains columns that are not known in 
        /// advanced, then ExecuteDynamicList is your ticket.
        /// </summary>
        /// <param name="ctx">The DbContext to execute the SQL on.</param>
        /// <param name="Types">A list of Types the query's result sets will be
        /// mapped to. The first type must have an object[] property to hold
        /// the dynamic column values.</param>
        /// <param name="cmd">The command to be executed.</param>
        /// <param name="DynamicColumnNames">A list of columns names who's values will populate
        /// the first object[] property on T.</param>
        /// <returns>A list of lists. Each list corresponds to the type from the Types parameter.</returns>
        public static IList<object> ExecuteDynamicList(DbContext ctx, IEnumerable<Type> Types, IEnumerable<string> DynamicColumnNames, DbCommand cmd)
        {
            Helpers.EnsureConnectionOpen(ctx);
            var dbReader = cmd.ExecuteReader();
            var AllResults = new List<object>();

            //
            // Dynamic columns only come from the first result set
            //
            var t1 = Helpers.ListFromDbReader(dbReader, Types.First(), DynamicColumnNames);
            AllResults.Add(t1);
            dbReader.NextResult();

            //
            // All other results sets just use property mapping
            //
            foreach (var ThisResultType in Types.Skip(1))
            {
                var t2 = Helpers.ListFromDbReader(dbReader, ThisResultType);
                AllResults.Add(t2);

                dbReader.NextResult();
            }

            return AllResults;
        }
    }
}
