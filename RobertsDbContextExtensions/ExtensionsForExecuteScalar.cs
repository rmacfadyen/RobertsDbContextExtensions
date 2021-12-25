namespace RobertsDbContextExtensions
{
    /// <summary>
    /// ExecuteScalar extension methods 
    /// </summary>
    public static class ExtensionsForExecuteScalar
    {

        /// <summary>
        /// Execute the provided SQL and return the first row of
        /// the result set.
        /// </summary>
        /// <typeparam name="T">The type the first result set should be mapped to.</typeparam>
        /// <param name="ctx">The DbContext to execute the SQL on.</param>
        /// <param name="Sql">The SQL to be executed.</param>
        /// <param name="Parameters">A list of values to be passed as parameters. See <see href="https://github.com/rmacfadyen/RobertsDbContextExtensions/blob/master/Parameters.md">Passing parameters</see></param>
        /// <returns>The value of the first column of the first row of the first result set cast as a T.</returns>
        public static T ExecuteScalar<T>(this DbContext ctx, string Sql, params object[] Parameters)
        {
            return ctx.ExecuteReaderFromSql(
                (dbReader, _) => Helpers.ListFromDbReader<T>(dbReader),
                null,
                Sql,
                Parameters
            ).FirstOrDefault();
        }

        /// <summary>
        /// Execute the provided command and return the first column of the first row of
        /// the result set.
        /// </summary>
        /// <typeparam name="T">The type the first result set should be mapped to.</typeparam>
        /// <param name="ctx">The DbContext to execute the command on.</param>
        /// <param name="cmd">The command to be executed.</param>
        /// <returns>The value of the first column of the first row of the first result set cast as a T.</returns>
        public static T ExecuteScalar<T>(this DbContext ctx, IDbCommand cmd)
        {
            return ctx.ExecuteReaderFromCmd(
                (dbReader, _) => Helpers.ListFromDbReader<T>(dbReader),
                null,
                cmd
            ).FirstOrDefault();
        }




        /// <summary>
        /// Executes the provided command and returns the first column
        /// of the first row of the first result set as an T.
        /// </summary>
        /// <typeparam name="T">The type the first column of the first row of the first result set will be cast to.</typeparam>
        /// <param name="cmd">The command to be executed.</param>
        /// <returns>The first column
        /// of the first row of the first result set cast to a T.</returns>
        public static T ExecuteScalar<T>(this IDbCommand cmd)
        {
            var cn = cmd.Connection;
            if (cn != null && cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }

            using var dbDataReader = cmd.ExecuteReader();
            return Helpers.ListFromDbReader<T>(dbDataReader).FirstOrDefault();
        }
    }
}
