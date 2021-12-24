using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobertsDbContextExtensions
{
    /// <summary>
    /// Provides several extension methods relating to IDbCommands
    /// </summary>
    public static class CommandExtensions
    {

        #region IDbCommand execution extensions

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


        /// <summary>
        /// Execute the provided command and return a stream from the database. This is
        /// indended for accessing BLOBs stored in the database efficiently.
        /// </summary>
        /// <param name="cmd">The command to be executed.</param>
        /// <returns>A stream that reads directly from the database.</returns>
        public static Stream ExecuteScalarStream(this IDbCommand cmd)
        {
            return new ReaderStream(cmd.ExecuteReader(CommandBehavior.SequentialAccess));
        }
        #endregion



        #region Command creation
        /// <summary>
        /// Create an DbCommand and populate its parameters (if necesary)
        /// </summary>
        /// <param name="ctx">The DbContext used to create the command (will also be used to execute the command on)</param>
        /// <param name="Sql">The SQL the command will execute</param>
        /// <param name="Parameters">A list of values to be passed as parameters. See <see href="https://github.com/rmacfadyen/RobertsDbContextExtensions/blob/master/Parameters.md">Passing parameters</see></param>
        /// <returns>An initialized DbCommand ready for execution. If a transaction
        /// is active the command is enrolled in it.</returns>
        public static DbCommand CreateCommand(this DbContext ctx, string Sql, params object[] Parameters)
        {
            Helpers.EnsureConnectionOpen(ctx);

            //
            // Create the command, use the same timeout as the connection
            //
            var db = ctx.Database;
            var cn = db.GetDbConnection();
            var cmd = cn.CreateCommand();
            cmd.CommandText = Sql;
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = cn.ConnectionTimeout;

            //
            // If there's an open transaction use it on the command
            //
            var Txn = db.CurrentTransaction?.GetDbTransaction();
            if (Txn != null)
            {
                cmd.Transaction = Txn;
            }

            //
            // Populate the command parameters
            //  - Values go as "@p0", "@p1" etc
            //  - Objects use the object's property names
            //  - A mix and match approach is possible, but some care
            //    is needed to not mix up the parameter names. This is
            //    not really recommended because it makes the parameter 
            //    name to value correlation trickier to see when looking
            //    at the code (unamed parameters should be avoided for
            //    more than 1 or 2 parameters).
            //
            //    For example you will get parameters named @p0, @p1, @PropA, 
            //    @PropB, and @p3 from the following: 
            //      var PropA = DateTime.Now;
            //      var PropB = "text";
            //      cn.ExecuteNonQuery("select 1", 17, 33, new { PropA, PropB }, "more text")
            //
            //      and with a transaction...
            //
            //      var PropA = DateTime.Now;
            //      var PropB = "text";
            //      var Txn = cn.BeginTransaction();
            //      cn.ExecuteNonQuery("select 1", txn, 17, 33, new { PropA, PropB }, "more text")
            //      Txn.Commit();
            //
            if (Parameters != null)
            {
                //
                // Populate each parameter (except the first one if it was an IDbTransaction)
                //
                var ParameterCount = 0;
                foreach (var Parameter in Parameters)
                {
                    AddParameterToCommand(cmd, ParameterCount, Parameter);

                    ParameterCount += 1;
                }
            }

            return cmd;
        }

        /// <summary>
        /// Add an IDbDataParameter to the provided command using the specified
        /// parameter name and object value.
        /// </summary>
        /// <param name="cmd">The command to add the specified parameter to.</param>
        /// <param name="ParameterName">The name of the parameter (without an @ sign).</param>
        /// <param name="Value">The value of the parameter, null is changed to DBNull.Value</param>
        public static void AddParameterValue(this IDbCommand cmd, string ParameterName, object Value)
        {
            var p = cmd.CreateParameter();
            p.ParameterName = ParameterName;
            p.DbType = Value == null ? DbType.String : Helpers.typeMap[Value.GetType()];
            p.Value = Value ?? DBNull.Value;
            cmd.Parameters.Add(p);
        }

        /// <summary>
        /// Add an IDbDataParameter to the provided command using the specified
        /// parameter name and int value.
        /// </summary>
        /// <param name="cmd">The command to add the specified parameter to.</param>
        /// <param name="ParameterName">The name of the parameter (without an @ sign).</param>
        /// <param name="Value">The value of the parameter.</param>
        public static void AddParameterValue(this IDbCommand cmd, string ParameterName, int Value)
        {
            var p = cmd.CreateParameter();
            p.ParameterName = ParameterName;
            p.DbType = DbType.Int32;
            p.Value = Value;
            cmd.Parameters.Add(p);
        }

        /// <summary>
        /// Add an IDbDataParameter to the provided command using the specified
        /// parameter name and bool value.
        /// </summary>
        /// <param name="cmd">The command to add the specified parameter to.</param>
        /// <param name="ParameterName">The name of the parameter (without an @ sign).</param>
        /// <param name="Value">The value of the parameter.</param>
        public static void AddParameterValue(this IDbCommand cmd, string ParameterName, bool Value)
        {
            var p = cmd.CreateParameter();
            p.ParameterName = ParameterName;
            p.DbType = DbType.Boolean;
            p.Value = Value;
            cmd.Parameters.Add(p);
        }

        /// <summary>
        /// Add an IDbDataParameter to the provided command using the specified
        /// parameter name and NULL value. The underlying DbType of the parameter
        /// is always string.
        /// </summary>
        /// <remarks>
        /// In certain situations it can be tricky to correctly pass a NULL value
        /// as a parameter via code. This method allows for explicitly adding a
        /// string parameter will a NULL value.
        /// </remarks>
        /// <param name="cmd">The command to add the specified parameter to.</param>
        /// <param name="ParameterName">The name of the parameter (without an @ sign).</param>
        /// <param name="Value">Must be DBNull.Value</param>
        public static void AddParameterValue(this IDbCommand cmd, string ParameterName, DBNull Value)
        {
            var p = cmd.CreateParameter();
            p.ParameterName = ParameterName;
            p.DbType = DbType.String;
            p.Value = Value;
            cmd.Parameters.Add(p);
        }

        /// <summary>
        /// Add an IDbDataParameter to the provided command using the specified
        /// parameter name and string value. Null strings are passed as DbNull.Value.
        /// </summary>
        /// <param name="cmd">The command to add the specified parameter to.</param>
        /// <param name="ParameterName">The name of the parameter (without an @ sign).</param>
        /// <param name="Value">The value of the parameter, null will be changed to DBNull.Value.</param>
        public static void AddParameterValue(this IDbCommand cmd, string ParameterName, string Value)
        {
            var p = cmd.CreateParameter();
            p.ParameterName = ParameterName;
            p.DbType = DbType.String;
            if (Value == null)
            {
                p.Value = DBNull.Value;
            }
            else
            {
                p.Value = Value;
            }
            cmd.Parameters.Add(p);
        }
        #endregion



        #region Parameter value list handling

        internal static void AddParameterToCommand(DbCommand cmd, int ParameterCount, object ParameterValue)
        {
            if (ParameterValue == null || Helpers.IsValueTypeOrString(ParameterValue.GetType()))
            {
                AddValueTypeParameter(cmd, ParameterCount, ParameterValue);
            }
            else if (ParameterValue is IDictionary<string, object> ObjectDictionary)
            {
                AddParametersFromDictionary(cmd, ObjectDictionary);
            }
            else if (ParameterValue is IDictionary<string, string> StringDictionary)
            {
                AddParametersFromStringDictionary(cmd, StringDictionary);
            }
            else
            {
                AddParametersFromObjectProperties(cmd, ParameterValue);
            }
        }


        private static void AddParametersFromObjectProperties(DbCommand cmd, object ParameterValue)
        {
            //
            // An object has it's fields as parameters eg "@objPropA", "@objPropB"
            //
            var Properties = ParameterValue.GetType().GetProperties();
            foreach (var Property in Properties)
            {
                var v = Property.GetValue(ParameterValue);

                cmd.AddParameter(
                    ParameterName: Property.Name,
                    DbType: Property.PropertyType.IsEnum ? Helpers.typeMap[typeof(int)] : Helpers.typeMap[Property.PropertyType],
                    Value: v == null ? DBNull.Value : Property.PropertyType.IsEnum ? (int)v : v
                );
            }
        }

        
        private static void AddParametersFromStringDictionary(DbCommand cmd, IDictionary<string, string> StringDictionary)
        {
            //
            // An IDictionary could also be an expando object
            //
            foreach (var Key in StringDictionary.Keys)
            {
                var v = StringDictionary[Key];
                cmd.AddParameter(
                    ParameterName: Key,
                    DbType: v == null ? DbType.String : Helpers.typeMap[v.GetType()],
                    Value: v != null ? v : DBNull.Value
                );
            }
        }

        
        private static void AddParametersFromDictionary(DbCommand cmd, IDictionary<string, object> ObjectDictionary)
        {
            //
            // An IDictionary could also be an expando object
            //
            foreach (var Key in ObjectDictionary.Keys)
            {
                var v = ObjectDictionary[Key];
                cmd.AddParameter(
                    ParameterName: Key,
                    DbType: v == null ? DbType.String : Helpers.typeMap[v.GetType()],
                    Value: v ?? DBNull.Value
                );
            }
        }

        
        private static void AddValueTypeParameter(DbCommand cmd, int ParameterCount, object ParameterValue)
        {
            cmd.AddParameter(
                ParameterName: $"p{ParameterCount}",
                DbType: ParameterValue == null ? DbType.String : Helpers.typeMap[ParameterValue.GetType()],
                Value: ParameterValue ?? DBNull.Value
            );
        }

        
        private static void AddParameter(this DbCommand cmd, string ParameterName, DbType DbType, object Value)
        {
            var p = cmd.CreateParameter();
            p.ParameterName = ParameterName;
            p.DbType = DbType;
            p.Value = Value;
            cmd.Parameters.Add(p);
        }

        #endregion
    }
}
