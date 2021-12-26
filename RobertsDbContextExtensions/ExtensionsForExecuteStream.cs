namespace RobertsDbContextExtensions
{
    /// <summary>
    /// ADO.NET supports efficient reading of BLOB data by using the
    /// CommandBehavior.SequentialAccess flag. By wrapping the returned
    /// IDataReader in a slim readonly stream you can read and process
    /// a BLOB without loading it entirely into memory. 
    /// 
    /// Perfect when dealing with files that have been stored in a database 
    /// and need to be beamed down to a client (eg. browser) without requiring
    /// the webserver to hold the entire BLOB in memory.
    /// </summary>
    public static class ExtensionsForExecuteStream
    {
        /// <summary>
        /// Execute the provided SQL and return a stream from the database. This is
        /// indended for accessing BLOBs stored in the database efficiently.
        /// </summary>
        /// <param name="ctx">The DbContext to execute the SQL on.</param>
        /// <param name="Sql">The SQL to be executed.</param>
        /// <param name="Parameters">A list of values to be passed as parameters. See <see href="https://github.com/rmacfadyen/RobertsDbContextExtensions/blob/master/Parameters.md">Passing parameters</see></param>
        /// <returns>A stream that reads directly from the database.</returns>
        public static Stream ExecuteStream(this DbContext ctx, string Sql, params object[] Parameters)
        {
            var cmd = ctx.CreateCommand(Sql, Parameters);
            return cmd.ExecuteStream();
        }


        /// <summary>
        /// Execute the provided command and return a stream from the database. This is
        /// indended for accessing BLOBs stored in the database efficiently.
        /// </summary>
        /// <param name="cmd">The command to be executed.</param>
        /// <returns>A stream that reads directly from the database.</returns>
        public static Stream ExecuteStream(this IDbCommand cmd)
        {
            return new ReaderStream(cmd.ExecuteReader(CommandBehavior.SequentialAccess));
        }
    }
}
