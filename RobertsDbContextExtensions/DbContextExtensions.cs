using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data;
using System.Collections.Concurrent;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data.Common;
using System.IO;

namespace RobertsDbContextExtensions
{
    /// <summary>
    /// DbContextExtension provides several convience methods based on
    /// classic ADO.NET.
    /// </summary>
    public static class DbContextExtensions
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



        #region ExecuteScalar from SQL and CMD

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


        #endregion



        #region Stream from SQL
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
        #endregion


    }
}