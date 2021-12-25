﻿namespace RobertsDbContextExtensions
{
    /// <summary>
    /// ExecuteScalar extension methods 
    /// </summary>
    public static class ExtensionExecuteScalar
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
        /// Execute the provided SQL and return a stream from the database. This is
        /// indended for accessing BLOBs stored in the database efficiently.
        /// </summary>
        /// <param name="ctx">The DbContext to execute the SQL on.</param>
        /// <param name="Sql">The SQL to be executed.</param>
        /// <param name="Parameters">A list of values to be passed as parameters. See <see href="https://github.com/rmacfadyen/RobertsDbContextExtensions/blob/master/Parameters.md">Passing parameters</see></param>
        /// <returns>A stream that reads directly from the database.</returns>
        public static Stream ExecuteScalarStream(this DbContext ctx, string Sql, params object[] Parameters)
        {
            var cmd = ctx.CreateCommand(Sql, Parameters);
            return cmd.ExecuteScalarStream();
        }
    }
}
