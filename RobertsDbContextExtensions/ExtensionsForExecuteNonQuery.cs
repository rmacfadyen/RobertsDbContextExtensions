namespace RobertsDbContextExtensions
{
    /// <summary>
    /// DbContextExtension provides several convience methods based on
    /// classic ADO.NET.
    /// </summary>
    public static class ExtensionsForExecuteNonQuery
    {
 

        #region NonQuery from SQL

        /// <summary>
        /// Execute the provided SQL and return the number of rows affected.
        /// </summary>
        /// <param name="ctx">The DbContext to execute the SQL on.</param>
        /// <param name="Sql">The SQL to be executed.</param>
        /// <param name="Parameters">A list of values to be passed as parameters. See <see href="https://github.com/rmacfadyen/RobertsDbContextExtensions/blob/master/Parameters.md">Passing parameters</see></param>
        /// <returns>The number of rows affected. Zero if no rows where affected or if the query wasn't row related (eg. created a table)</returns>
        public static int ExecuteNonQuery(this DbContext ctx, string Sql, params object[] Parameters)
        {
            Helpers.EnsureConnectionOpen(ctx);

            using var cmd = ctx.CreateCommand(Sql, Parameters);
            return cmd.ExecuteNonQuery();
        }

        #endregion
    }
}