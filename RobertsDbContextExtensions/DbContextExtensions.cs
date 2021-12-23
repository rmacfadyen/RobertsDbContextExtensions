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
        /// <summary>
        /// Map of primitive types to DbType.
        /// </summary>
        private static readonly Dictionary<Type, DbType> typeMap = new()
        {
            { typeof(byte), DbType.Byte },
            { typeof(sbyte), DbType.SByte },
            { typeof(short), DbType.Int16 },
            { typeof(ushort), DbType.UInt16 },
            { typeof(int), DbType.Int32 },
            { typeof(uint), DbType.UInt32 },
            { typeof(long), DbType.Int64 },
            { typeof(ulong), DbType.UInt64 },
            { typeof(float), DbType.Single },
            { typeof(double), DbType.Double },
            { typeof(decimal), DbType.Decimal },
            { typeof(bool), DbType.Boolean },
            { typeof(string), DbType.String },
            { typeof(char), DbType.StringFixedLength },
            { typeof(Guid), DbType.Guid },
            { typeof(DateTime), DbType.DateTime },
            { typeof(DateTimeOffset), DbType.DateTimeOffset },
            { typeof(byte[]), DbType.Binary },

            { typeof(DateOnly), DbType.Date },
            { typeof(TimeOnly), DbType.Time },

            { typeof(byte?), DbType.Byte },
            { typeof(sbyte?), DbType.SByte },
            { typeof(short?), DbType.Int16 },
            { typeof(ushort?), DbType.UInt16 },
            { typeof(int?), DbType.Int32 },
            { typeof(uint?), DbType.UInt32 },
            { typeof(long?), DbType.Int64 },
            { typeof(ulong?), DbType.UInt64 },
            { typeof(float?), DbType.Single },
            { typeof(double?), DbType.Double },
            { typeof(decimal?), DbType.Decimal },
            { typeof(bool?), DbType.Boolean },
            { typeof(char?), DbType.StringFixedLength },
            { typeof(Guid?), DbType.Guid },
            { typeof(DateTime?), DbType.DateTime },
            { typeof(DateTimeOffset?), DbType.DateTimeOffset },
            { typeof(DateOnly?), DbType.Date },
            { typeof(TimeOnly?), DbType.Time },
        };


        #region NonQuery from SQL
      
        /// <summary>
        /// Execute the provided SQL and return the number of rows affected.
        /// </summary>
        /// <param name="ctx">The DbContext to execute the SQL on</param>
        /// <param name="Sql">The SQL to be executed.</param>
        /// <param name="Parameters"></param>
        /// <returns>The number of rows affected. Zero if no rows where affected or if the query wasn't row related (eg. created a table)</returns>
        public static int ExecuteNonQuery(this DbContext ctx, string Sql, params object[] Parameters)
        {
            EnsureConnectionOpen(ctx);

            using var cmd = ctx.CreateCommand(Sql, Parameters);
            return cmd.ExecuteNonQuery();
        }

        #endregion



        #region ExecuteScalar from SQL and CMD

        /// <summary>
        /// Execute the provided SQL and return the first column of the first row of
        /// the result set.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ctx">The DbContext to execute the SQL on</param>
        /// <param name="Sql">The SQL to be executed.</param>
        /// <param name="Parameters">A list of values to be passed as parameters. See <see href="https://github.com/rmacfadyen/RobertsDbContextExtensions/blob/master/Parameters.md">Passing parameters</see></param>
        /// <returns></returns>
        public static T ExecuteScalar<T>(this DbContext ctx, string Sql, params object[] Parameters)
        {
            return ctx.ExecuteReaderFromSql(
                (dbReader, _) => ListFromDbReader<T>(dbReader),
                null,
                Sql,
                Parameters
            ).FirstOrDefault();
        }

        /// <summary>
        /// Execute the provided command and return the first column of the first row of
        /// the result set.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ctx">The DbContext to execute the command on</param>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static T ExecuteScalar<T>(this DbContext ctx, IDbCommand cmd)
        {
            return ctx.ExecuteReaderFromCmd(
                (dbReader, _) => ListFromDbReader<T>(dbReader),
                null,
                cmd
            ).FirstOrDefault();
        }


        #endregion



        #region DynamicList

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
        /// <typeparam name="T"></typeparam>
        /// <param name="ctx">The DbContext to execute the SQL on</param>
        /// <param name="Sql">The SQL to be executed.</param>
        /// <param name="DynamicColumnNames"></param>
        /// <param name="Parameters"></param>
        /// <returns></returns>
        public static IList<T> ExecuteDynamicList<T>(
            this DbContext ctx, string Sql, IEnumerable<string> DynamicColumnNames, params object[] Parameters
        )
        {
            return ctx.ExecuteReaderFromSql(
                ListFromDbReader<T>,
                DynamicColumnNames,
                Sql,
                Parameters
            );
        }


        /// <summary>
        /// When you have a query that consists of several result sets,
        /// and the first result contains columns that are not known in 
        /// advanced, then ExecuteDynamicList is your ticket.
        /// </summary>
        /// <param name="ctx">The DbContext to execute the SQL on</param>
        /// <param name="Types"></param>
        /// <param name="Sql">The SQL to be executed.</param>
        /// <param name="DynamicColumnNames"></param>
        /// <param name="Parameters"></param>
        /// <returns></returns>
        public static IList<object> ExecuteDynamicList(
            this DbContext ctx,
            IEnumerable<Type> Types,
            string Sql,
            IEnumerable<string> DynamicColumnNames = null,
            params object[] Parameters
        )
        {
            EnsureConnectionOpen(ctx);

            using var cmd = ctx.CreateCommand(Sql, Parameters);
            using var dbReader = cmd.ExecuteReader();
            var AllResults = new List<object>();

            //
            // Dynamic columns only come from the first result set
            //
            var t1 = ListFromDbReader(dbReader, Types.First(), DynamicColumnNames);
            AllResults.Add(t1);
            dbReader.NextResult();

            //
            // All other results sets just use property mapping
            //
            foreach (var ThisResultType in Types.Skip(1))
            {
                var t2 = ListFromDbReader(dbReader, ThisResultType);
                AllResults.Add(t2);

                dbReader.NextResult();
            }

            return AllResults;
        }

        #endregion



        #region ExecuteList<T1..T6> from CMD

        /// <summary>
        /// Execute the provided command and return the result set mapped to
        /// an IList&lt;T&gt;.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ctx">The DbContext to execute the command on</param>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static IList<T> ExecuteList<T>(
            this DbContext ctx, IDbCommand cmd
        )
        {
            return ctx.ExecuteReaderFromCmd(
                (dbReader, _) => ListFromDbReader<T>(dbReader),
                null,
                cmd
            );
        }


        /// <summary>
        /// Execute the provided command and return a tuple of the 
        /// first two result sets mapped to lists.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="ctx">The DbContext to execute the command on</param>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static (IList<T1>, IList<T2>) ExecuteList<T1, T2>(
            this DbContext ctx, IDbCommand cmd
        )
        {
            return ctx.ExecuteReaderFromCmd<(IList<T1>, IList<T2>)>(
                (dbReader, _) => {
                    var t1 = ListFromDbReader<T1>(dbReader);
                    dbReader.NextResult();

                    var t2 = ListFromDbReader<T2>(dbReader);

                    return (t1, t2);
                },
                null,
                cmd
            );
        }

        /// <summary>
        /// Execute the provided command and return a tuple of the 
        /// first three result sets mapped to lists.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="ctx">The DbContext to execute the command on</param>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static (IList<T1>, IList<T2>, IList<T3>) ExecuteList<T1, T2, T3>(
            this DbContext ctx, IDbCommand cmd
        )
        {
            return ctx.ExecuteReaderFromCmd<(IList<T1>, IList<T2>, IList<T3>)>(
                (dbReader, _) => {
                    var t1 = ListFromDbReader<T1>(dbReader);
                    dbReader.NextResult();

                    var t2 = ListFromDbReader<T2>(dbReader);
                    dbReader.NextResult();

                    var t3 = ListFromDbReader<T3>(dbReader);

                    return (t1, t2, t3);
                },
                null,
                cmd
            );
        }


        /// <summary>
        /// Execute the provided command and return a tuple of the 
        /// first four result sets mapped to lists.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <param name="ctx">The DbContext to execute the command on</param>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static (IList<T1>, IList<T2>, IList<T3>, IList<T4>) ExecuteList<T1, T2, T3, T4>(
            this DbContext ctx, IDbCommand cmd
        )
        {
            return ctx.ExecuteReaderFromCmd<(IList<T1>, IList<T2>, IList<T3>, IList<T4>)>(
                (dbReader, _) => {
                    var t1 = ListFromDbReader<T1>(dbReader);
                    dbReader.NextResult();

                    var t2 = ListFromDbReader<T2>(dbReader);
                    dbReader.NextResult();

                    var t3 = ListFromDbReader<T3>(dbReader);
                    dbReader.NextResult();

                    var t4 = ListFromDbReader<T4>(dbReader);

                    return (t1, t2, t3, t4);
                },
                null,
                cmd
            );
        }

        /// <summary>
        /// Execute the provided command and return a tuple of the 
        /// first five result sets mapped to lists.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <param name="ctx">The DbContext to execute the command on</param>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static (IList<T1>, IList<T2>, IList<T3>, IList<T4>, IList<T5>) ExecuteList<T1, T2, T3, T4, T5>(
            this DbContext ctx, IDbCommand cmd
        )
        {
            return ctx.ExecuteReaderFromCmd<(IList<T1>, IList<T2>, IList<T3>, IList<T4>, IList<T5>)>(
                (dbReader, _) => {
                    var t1 = ListFromDbReader<T1>(dbReader);
                    dbReader.NextResult();

                    var t2 = ListFromDbReader<T2>(dbReader);
                    dbReader.NextResult();

                    var t3 = ListFromDbReader<T3>(dbReader);
                    dbReader.NextResult();

                    var t4 = ListFromDbReader<T4>(dbReader);
                    dbReader.NextResult();

                    var t5 = ListFromDbReader<T5>(dbReader);

                    return (t1, t2, t3, t4, t5);
                },
                null,
                cmd
            );
        }

        /// <summary>
        /// Execute the provided command and return a tuple of the 
        /// first six result sets mapped to lists.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <param name="ctx">The DbContext to execute the command on</param>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static (IList<T1>, IList<T2>, IList<T3>, IList<T4>, IList<T5>, IList<T6>) ExecuteList<T1, T2, T3, T4, T5, T6>(
            this DbContext ctx, IDbCommand cmd
        )
        {
            return ctx.ExecuteReaderFromCmd<(IList<T1>, IList<T2>, IList<T3>, IList<T4>, IList<T5>, IList<T6>)>(
                (dbReader, _) => {
                    var t1 = ListFromDbReader<T1>(dbReader);
                    dbReader.NextResult();

                    var t2 = ListFromDbReader<T2>(dbReader);
                    dbReader.NextResult();

                    var t3 = ListFromDbReader<T3>(dbReader);
                    dbReader.NextResult();

                    var t4 = ListFromDbReader<T4>(dbReader);
                    dbReader.NextResult();

                    var t5 = ListFromDbReader<T5>(dbReader);
                    dbReader.NextResult();

                    var t6 = ListFromDbReader<T6>(dbReader);

                    return (t1, t2, t3, t4, t5, t6);
                },
                null,
                cmd
            );
        }
        #endregion



        #region ExecuteList<T1..T6> from SQL

        /// <summary>
        /// Execute the provided SQL and return a tuple of the 
        /// first result set mapped to lists.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ctx">The DbContext to execute the SQL on</param>
        /// <param name="Sql">The SQL to be executed.</param>
        /// <param name="Parameters"></param>
        /// <returns></returns>
        public static IList<T> ExecuteList<T>(
            this DbContext ctx, string Sql, params object[] Parameters
        )
        {
            return ctx.ExecuteReaderFromSql(
                (dbReader, _) => ListFromDbReader<T>(dbReader),
                null,
                Sql,
                Parameters
            );
        }

        /// <summary>
        /// Execute the provided SQL and return a tuple of the 
        /// first two result sets mapped to lists.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="ctx">The DbContext to execute the SQL on</param>
        /// <param name="Sql">The SQL to be executed.</param>
        /// <param name="Parameters"></param>
        /// <returns></returns>
        public static (IList<T1>, IList<T2>) ExecuteList<T1, T2>(
            this DbContext ctx, string Sql, params object[] Parameters
        )
        {
            return ctx.ExecuteReaderFromSql<(IList<T1>, IList<T2>)>(
                (dbReader, _) => {
                    var t1 = ListFromDbReader<T1>(dbReader);
                    dbReader.NextResult();

                    var t2 = ListFromDbReader<T2>(dbReader);

                    return (t1, t2);
                },
                null,
                Sql,
                Parameters
            );
        }


        /// <summary>
        /// Execute the provided SQL and return a tuple of the 
        /// first three result sets mapped to lists.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="ctx">The DbContext to execute the SQL on</param>
        /// <param name="Sql">The SQL to be executed.</param>
        /// <param name="Parameters"></param>
        /// <returns></returns>
        public static (IList<T1>, IList<T2>, IList<T3>) ExecuteList<T1, T2, T3>(
            this DbContext ctx, string Sql, params object[] Parameters
        )
        {
            return ctx.ExecuteReaderFromSql<(IList<T1>, IList<T2>, IList<T3>)>(
                (dbReader, _) => {
                    var t1 = ListFromDbReader<T1>(dbReader);
                    dbReader.NextResult();

                    var t2 = ListFromDbReader<T2>(dbReader);
                    dbReader.NextResult();

                    var t3 = ListFromDbReader<T3>(dbReader);

                    return (t1, t2, t3);
                },
                null,
                Sql,
                Parameters
            );
        }


        /// <summary>
        /// Execute the provided SQL and return a tuple of the 
        /// first four result sets mapped to lists.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <param name="ctx">The DbContext to execute the SQL on</param>
        /// <param name="Sql">The SQL to be executed.</param>
        /// <param name="Parameters"></param>
        /// <returns></returns>
        public static (IList<T1>, IList<T2>, IList<T3>, IList<T4>) ExecuteList<T1, T2, T3, T4>(
            this DbContext ctx, string Sql, params object[] Parameters
        )
        {
            return ctx.ExecuteReaderFromSql<(IList<T1>, IList<T2>, IList<T3>, IList<T4>)>(
                (dbReader, _) => {
                    var t1 = ListFromDbReader<T1>(dbReader);
                    dbReader.NextResult();

                    var t2 = ListFromDbReader<T2>(dbReader);
                    dbReader.NextResult();

                    var t3 = ListFromDbReader<T3>(dbReader);
                    dbReader.NextResult();

                    var t4 = ListFromDbReader<T4>(dbReader);

                    return (t1, t2, t3, t4);
                },
                null,
                Sql,
                Parameters
            );
        }

        /// <summary>
        /// Execute the provided SQL and return a tuple of the 
        /// first five result sets mapped to lists.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <param name="ctx">The DbContext to execute the SQL on</param>
        /// <param name="Sql">The SQL to be executed.</param>
        /// <param name="Parameters"></param>
        /// <returns></returns>
        public static (IList<T1>, IList<T2>, IList<T3>, IList<T4>, IList<T5>) ExecuteList<T1, T2, T3, T4, T5>(
             this DbContext ctx, string Sql, params object[] Parameters
         )
        {
            return ctx.ExecuteReaderFromSql<(IList<T1>, IList<T2>, IList<T3>, IList<T4>, IList<T5>)>(
                (dbReader, _) => {
                    var t1 = ListFromDbReader<T1>(dbReader);
                    dbReader.NextResult();

                    var t2 = ListFromDbReader<T2>(dbReader);
                    dbReader.NextResult();

                    var t3 = ListFromDbReader<T3>(dbReader);
                    dbReader.NextResult();

                    var t4 = ListFromDbReader<T4>(dbReader);
                    dbReader.NextResult();

                    var t5 = ListFromDbReader<T5>(dbReader);

                    return (t1, t2, t3, t4, t5);
                },
                null,
                Sql,
                Parameters
            );
        }

        /// <summary>
        /// Execute the provided SQL and return a tuple of the 
        /// first six result sets mapped to lists.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <param name="ctx">The DbContext to execute the SQL on</param>
        /// <param name="Sql">The SQL to be executed.</param>
        /// <param name="Parameters"></param>
        /// <returns></returns>
        public static (IList<T1>, IList<T2>, IList<T3>, IList<T4>, IList<T5>, IList<T6>) ExecuteList<T1, T2, T3, T4, T5, T6>(
            this DbContext ctx, string Sql, params object[] Parameters
        )
        {
            return ctx.ExecuteReaderFromSql<(IList<T1>, IList<T2>, IList<T3>, IList<T4>, IList<T5>, IList<T6>)>(
                (dbReader, _) => {
                    var t1 = ListFromDbReader<T1>(dbReader);
                    dbReader.NextResult();

                    var t2 = ListFromDbReader<T2>(dbReader);
                    dbReader.NextResult();

                    var t3 = ListFromDbReader<T3>(dbReader);
                    dbReader.NextResult();

                    var t4 = ListFromDbReader<T4>(dbReader);
                    dbReader.NextResult();

                    var t5 = ListFromDbReader<T5>(dbReader);
                    dbReader.NextResult();

                    var t6 = ListFromDbReader<T6>(dbReader);

                    return (t1, t2, t3, t4, t5, t6);
                },
                null,
                Sql,
                Parameters
            );
        }
        #endregion



        #region Command creation
        /// <summary>
        /// Create an DbCommand and populate its parameters (if necesary)
        /// </summary>
        /// <param name="ctx">The DbContext used to create the command (will also be used to execute the command on)</param>
        /// <param name="Sql">The SQL the command will execute</param>
        /// <param name="Parameters">The parameters, if any, that should be passed to the SQL.
        /// </param>
        /// <returns>Am initialized DbCommand ready for execution. If a transaction
        /// is active the command is enrolled in it.</returns>
        public static DbCommand CreateCommand(this DbContext ctx, string Sql, params object[] Parameters)
        {
            EnsureConnectionOpen(ctx);

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
        #endregion



        #region Stream from SQL
        /// <summary>
        /// Execute the provided SQL and return a stream from the database. This is
        /// indended for accessing BLOBs stored in the database efficiently.
        /// </summary>
        /// <param name="ctx">The DbContext to execute the SQL on</param>
        /// <param name="Sql">The SQL to be executed.</param>
        /// <param name="Parameters"></param>
        /// <returns></returns>
        public static Stream ExecuteScalarStream(this DbContext ctx, string Sql, params object[] Parameters)
        {
            var cmd = ctx.CreateCommand(Sql, Parameters);
            return cmd.ExecuteScalarStream();
        }
        #endregion



        #region Dataset routines (horrible horrible dataset)

        /// <summary>
        /// Execute the provided command and return its results as a classic ADO.NET DataSet.
        /// Only provided for migratory purposes. Should be avoided for new code.
        /// </summary>
        /// <param name="ctx">The DbContext to execute the command on</param>
        /// <param name="cmd"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static DataSet LoadDataset(this DbContext ctx, DbCommand cmd)
        {
            var cn = ctx.Database.GetDbConnection();
            var Factory = DbProviderFactories.GetFactory(cn) ?? throw new InvalidOperationException("DbProviderFactories.CreateFactory(cn) return null"); 
            using var da = Factory.CreateDataAdapter() ?? throw new InvalidOperationException($"The data provider's factory, {Factory.GetType().FullName}, does not support DataAdapter");
            da.SelectCommand = cmd;
            var ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        /// <summary>
        /// Executes the provided command and returns a list of T1's that
        /// have had their child records populated via the provided assignment
        /// lambda. 
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="ctx">The DbContext to execute the command on</param>
        /// <param name="cmd"></param>
        /// <param name="T1Column"></param>
        /// <param name="Assignment"></param>
        /// <param name="T2Column"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static IList<T1> LoadDataset<T1, T2>(
            this DbContext ctx,
            DbCommand cmd,
            string T1Column,
            Action<T1, IList<T2>> Assignment,
            string T2Column = null
        ) where T1 : new()
        {
            using var ds = ctx.LoadDataset(cmd) ?? throw new InvalidOperationException("LoadDataset returned null");

            var ParentTable = ds.Tables[0];
            var ParentColumn = ParentTable.Columns[T1Column] ?? throw new InvalidOperationException($"Parent table does not have specified column {T1Column}");

            var ChildTable = ds.Tables[1];
            var ChildColumn = ChildTable.Columns[T2Column ?? T1Column] ?? throw new InvalidOperationException($"Child table does not have specified column {T2Column ?? T1Column}");

            ds.Relations.Add("ChildTable", new[] { ParentColumn }, new[] { ChildColumn });

            var Data = new List<T1>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                var Row = LoadOneFromDr<T1>(dr);
                var ChildRows = dr.GetChildRows("ChildTable");
                Assignment(Row, ReadChildRows<T2>(ChildRows));

                Data.Add(Row);
            }

            return Data;
        }


        /// <summary>
        /// Takes a list of DataRows and populates an IList<typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Rows"></param>
        /// <returns>An IList<typeparamref name="T"/> based on the passed Rows</returns>
        /// <exception cref="InvalidOperationException"></exception>
        private static IList<T> ReadChildRows<T>(IEnumerable<DataRow> Rows)
        {
            var List = new List<T>();

            //
            // The type of the child rows can't really be a primitive/string
            // because if that were the case then the relationship between
            // the parent and child is just the parent id... so totally
            // meaningless. But... might as well be prepared for it anyways.
            //
            var TypeOfT = typeof(T);
            if (TypeOfT.IsPrimitive || TypeOfT == typeof(string))
            {
                List.AddRange(Rows.Select(dr => (T)dr[0]));
            }
            else
            {
                var Constructor = TypeOfT.GetConstructor(Type.EmptyTypes) ?? throw new InvalidOperationException("GetConstructor returned null");
                var Properties = TypeOfT.GetProperties();
                var FirstRow = Rows.FirstOrDefault();
                if (FirstRow == null)
                {
                    return List;
                }

                foreach (var dr in Rows)
                {
                    var o = (T)Constructor.Invoke(null);

                    InitializeFromDataRow(Properties, FirstRow.Table.Columns, dr, o);

                    List.Add(o);
                }
            }

            return List;
        }


        /// <summary>
        /// Load one DataRow into one instance of T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dr"></param>
        /// <returns></returns>
        private static T LoadOneFromDr<T>(DataRow dr) where T : new()
        {
            var Properties = typeof(T).GetProperties();
            var o = new T();
            InitializeFromDataRow(Properties, dr.Table.Columns, dr, o);
            return o;
        }


        /// <summary>
        /// Populates an object's properties from a DataROw
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Properties"></param>
        /// <param name="Columns"></param>
        /// <param name="dr"></param>
        /// <param name="o"></param>
        private static void InitializeFromDataRow<T>(
            System.Reflection.PropertyInfo[] Properties, 
            DataColumnCollection Columns, 
            DataRow dr, 
            T o)
        {
            foreach (var Property in Properties)
            {
                if (Columns.Contains(Property.Name))
                {
                    var v = dr[Property.Name];

                    if (v == DBNull.Value)
                    {
                        Property.SetValue(o, null, null);
                    }
                    else
                    {
                        try
                        {
                            Property.SetValue(o, v, null);
                        }
                        catch (ArgumentException)
                        {
                            if (Property.PropertyType.IsEnum && v is string sValue)
                            {
                                if (sValue == string.Empty)
                                {
                                    Property.SetValue(o, 0, null);
                                }
                                else
                                {
                                    var EnumValue = Enum.Parse(Property.PropertyType, sValue, true);
                                    Property.SetValue(o, EnumValue, null);
                                }
                            }
                            else
                            {
                                throw;
                            }
                        }
                    }
                }
            }
        }
        #endregion



        #region DataTable routines (horrible horrible datatable)

        /// <summary>
        /// Executes the provided SQL and returns a classic ADO.NET DataTable. 
        /// Only provided for migratory purposes. Should be avoided for new code.
        /// </summary>
        /// <param name="ctx">The DbContext to execute the SQL on</param>
        /// <param name="Sql"></param>
        /// <param name="Parameters"></param>
        /// <returns></returns>
        public static DataTable LoadDataTable(this DbContext ctx, string Sql, params object[] Parameters)
        {
            var cmd = ctx.CreateCommand(Sql, Parameters);
            return ctx.LoadDataTable(cmd);
        }

        /// <summary>
        /// Executes the provided command and returns a classic ADO.NET DataTable. 
        /// Only provided for migratory purposes. Should be avoided for new code.
        /// </summary>
        /// <param name="ctx">The DbContext to execute the command on</param>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static DataTable LoadDataTable(this DbContext ctx, IDbCommand cmd)
        {
            EnsureConnectionOpen(ctx);

            var dt = new DataTable();
            using var dr = cmd.ExecuteReader();
            dt.Load(dr);

            return dt;
        }

        #endregion



        #region IDbCommand extensions

        /// <summary>
        /// Executes the provided command and returns the first column
        /// of the first row of the first result set as an T.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static T ExecuteScalar<T>(this IDbCommand cmd)
        {
            var cn = cmd.Connection;
            if (cn != null && cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }

            using var dbDataReader = cmd.ExecuteReader();
            return ListFromDbReader<T>(dbDataReader).FirstOrDefault();
        }

        /// <summary>
        /// Execute the provided command and return a stream from the database. This is
        /// indended for accessing BLOBs stored in the database efficiently.
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static Stream ExecuteScalarStream(this IDbCommand cmd)
        {
            return new ReaderStream(cmd.ExecuteReader(CommandBehavior.SequentialAccess));
        }

        /// <summary>
        /// Add an IDbDataParameter to the provided command using the specified
        /// parameter name and object value.
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="ParameterName"></param>
        /// <param name="Parameter"></param>
        public static void AddParameterValue(this IDbCommand cmd, string ParameterName, object Parameter)
        {
            var p = cmd.CreateParameter();
            p.ParameterName = ParameterName;
            p.DbType = Parameter == null ? DbType.String : typeMap[Parameter.GetType()];
            p.Value = Parameter ?? DBNull.Value;
            cmd.Parameters.Add(p);
        }

        /// <summary>
        /// Add an IDbDataParameter to the provided command using the specified
        /// parameter name and int value.
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="ParameterName"></param>
        /// <param name="Value"></param>
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
        /// <param name="cmd"></param>
        /// <param name="ParameterName"></param>
        /// <param name="Value"></param>
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
        /// <param name="cmd"></param>
        /// <param name="ParameterName"></param>
        /// <param name="Value"></param>
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
        /// <param name="cmd"></param>
        /// <param name="ParameterName"></param>
        /// <param name="Value"></param>
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



        #region Private helpers



        #region Reader helpers

        /// <summary>
        /// Load a list of T's from a IDataReader
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dbDataReader"></param>
        /// <param name="DynamicColumns"></param>
        /// <returns></returns>
        private static IList<T> ListFromDbReader<T>(IDataReader dbDataReader, IEnumerable<string> DynamicColumns = null)
        {
            IList<PropertyDetails> ColumnsToRead;
            Func<IDataRecord, Type, IList<PropertyDetails>, (FastPropertySetter, IList<int>)?, T> RowConverter;
            (FastPropertySetter, IList<int>)? DynamicColumnsToRead;

            //
            // Pick the correct row conversion routine based on whether
            // or not the type is primitive/string, object + dynamic, or just object
            //
            var TypeOfT = typeof(T);
            if (IsValueTypeOrString(TypeOfT))
            {
                ColumnsToRead = null;
                RowConverter = ReadPrimitiveOrString<T>;
                DynamicColumnsToRead = null;
            }
            else
            {
                ColumnsToRead = DataRecordConverter.GetColumnMapping(dbDataReader, TypeOfT);
                RowConverter = ReadObject<T>;

                if (DynamicColumns == null || !DynamicColumns.Any())
                {
                    DynamicColumnsToRead = null;
                }
                else
                {
                    DynamicColumnsToRead = DataRecordConverter.GetDynamicColumnMapping(dbDataReader, TypeOfT, DynamicColumns);
                }
            }

            //
            // Finally build the list
            //
            var List = new List<T>();
            while (dbDataReader.Read())
            {
                var o = RowConverter(dbDataReader, TypeOfT, ColumnsToRead, DynamicColumnsToRead);
                List.Add(o);
            }

            return List;
        }

        /// <summary>
        /// Load a list of the specified type from an IDataReader
        /// </summary>
        /// <param name="dbDataReader"></param>
        /// <param name="TypeOfT"></param>
        /// <param name="DynamicColumns"></param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        private static System.Collections.IList ListFromDbReader(
            IDataReader dbDataReader,
            Type TypeOfT,
            IEnumerable<string> DynamicColumns = null)
        {
            IList<PropertyDetails> ColumnsToRead;
            Func<IDataRecord, Type, IList<PropertyDetails>, (FastPropertySetter, IList<int>)?, object> RowConverter;
            (FastPropertySetter, IList<int>)? DynamicColumnsToRead;

            //
            // Pick the correct row conversion routine based on whether
            // or not the type is primitive/string, object + dynamic, or just object
            //
            if (IsValueTypeOrString(TypeOfT))
            {
                ColumnsToRead = null;
                RowConverter = ReadPrimitiveOrString;
                DynamicColumnsToRead = null;
            }
            else
            {
                ColumnsToRead = DataRecordConverter.GetColumnMapping(dbDataReader, TypeOfT);
                RowConverter = ReadObject;

                if (DynamicColumns == null || !DynamicColumns.Any())
                {
                    DynamicColumnsToRead = null;
                }
                else
                {
                    DynamicColumnsToRead = DataRecordConverter.GetDynamicColumnMapping(dbDataReader, TypeOfT, DynamicColumns);
                }
            }

            //
            // Finally build the list
            //
            var t = typeof(List<>).MakeGenericType(TypeOfT);
            var List = (System.Collections.IList)Activator.CreateInstance(t);
            if (List == null) throw new NullReferenceException(nameof(List));


            while (dbDataReader.Read())
            {
                var o = RowConverter(dbDataReader, TypeOfT, ColumnsToRead, DynamicColumnsToRead);
                List.Add(o);
            }

            return List;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ctx"></param>
        /// <param name="operation"></param>
        /// <param name="ColumnNames"></param>
        /// <param name="Sql"></param>
        /// <param name="Parameters"></param>
        /// <returns></returns>
        private static T ExecuteReaderFromSql<T>(
            this DbContext ctx,
            Func<IDataReader, IEnumerable<string>, T> operation,
            IEnumerable<string> ColumnNames,
            string Sql,
            params object[] Parameters
        )
        {
            using var cmd = ctx.CreateCommand(Sql, Parameters);
            return ctx.ExecuteReaderFromCmd(operation, ColumnNames, cmd);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ctx"></param>
        /// <param name="operation"></param>
        /// <param name="ColumnNames"></param>
        /// <param name="cmd"></param>
        /// <returns></returns>
        private static T ExecuteReaderFromCmd<T>(
              this DbContext ctx,
              Func<IDataReader, IEnumerable<string>, T> operation,
              IEnumerable<string> ColumnNames,
              IDbCommand cmd
          )
        {
            EnsureConnectionOpen(ctx);

            using var dbDataReader = cmd.ExecuteReader();
            return operation(dbDataReader, ColumnNames);
        }


        /// <summary>
        /// Return the first column from the IDataRecord as a T where T is
        /// either a primitive type or a string.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dr"></param>
        /// <param name="TypeOfT"></param>
        /// <param name="p"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        private static T ReadPrimitiveOrString<T>(IDataRecord dr, Type TypeOfT, IList<PropertyDetails> p, (FastPropertySetter, IList<int>)? d)
        {
            return (T)DataRecordConverter.ReadValue(dr, 0, TypeOfT);
        }
        private static object ReadPrimitiveOrString(IDataRecord dr, Type TypeOfT, IList<PropertyDetails> p, (FastPropertySetter, IList<int>)? d)
        {
            return DataRecordConverter.ReadValue(dr, 0, TypeOfT);
        }

        /// <summary>
        /// Return an instance of T populated from the IDataRecord.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dr">The IDataRecord who's values will be used to initialize the T return value</param>
        /// <param name="TypeOfT">The type information for T (done to avoid call GetType on every record)</param>
        /// <param name="ColumnsToRead">A list of which columns/properties will be read</param>
        /// <param name="DynamicFields"></param>
        /// <returns>An instance of T populated from the record</returns>
        private static T ReadObject<T>(
            IDataRecord dr,
            Type TypeOfT,
            IList<PropertyDetails> ColumnsToRead,
            (FastPropertySetter, IList<int>)? DynamicFields)
        {
            if (ColumnsToRead == null) throw new ArgumentNullException(nameof(ColumnsToRead));

            //
            // Get the activator and create an instance of T
            //
            var ThisActivator = FastActivator<T>.Instance;
            var o = ThisActivator() ?? throw new InvalidOperationException("FastActivator failed to create instance");
            DataRecordConverter.ReadObject(dr, ColumnsToRead, o);

            if (DynamicFields.HasValue)
            {
                var DynamicObject = DataRecordConverter.ReadDynamicObject(dr, DynamicFields.Value.Item2);
                DynamicFields.Value.Item1.Set(o, DynamicObject);
            }

            return o;
        }


        private static object ReadObject(
            IDataRecord dr,
            Type TypeOfT,
            IList<PropertyDetails> ColumnsToRead,
            (FastPropertySetter, IList<int>)? DynamicFields)
        {
            if (ColumnsToRead == null) throw new ArgumentNullException(nameof(ColumnsToRead));

            //
            // Get the activator from the cache of activators
            //
            var ThisActivator = FastActivator.Instance(TypeOfT);
            var o = ThisActivator();

            //
            // Copy the columns to the newly create object
            //
            DataRecordConverter.ReadObject(dr, ColumnsToRead, o);

            if (DynamicFields.HasValue)
            {
                var DynamicObject = DataRecordConverter.ReadDynamicObject(dr, DynamicFields.Value.Item2);
                DynamicFields.Value.Item1.Set(o, DynamicObject);
            }

            return o;
        }

        #endregion



        #region Connection helpers
        /// <summary>
        /// Ensure the database connection is open.
        /// </summary>
        /// <param name="ctx"></param>
        private static void EnsureConnectionOpen(DbContext ctx)
        {
            EnsureConnectionOpen(ctx.Database.GetDbConnection());
        }

        /// <summary>
        /// Ensure the database connection is open.
        /// </summary>
        /// <param name="cn"></param>
        private static void EnsureConnectionOpen(IDbConnection cn)
        {
            if (cn != null)
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
            }
        }
        #endregion



        #region Parameter helpers

        private static void AddParameterToCommand(DbCommand cmd, int ParameterCount, object ParameterValue)
        {
            if (ParameterValue == null || IsValueTypeOrString(ParameterValue.GetType()))
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
                var p = cmd.CreateParameter();
                p.ParameterName = Property.Name;
                if (Property.PropertyType.IsEnum)
                {
                    p.DbType = typeMap[typeof(int)];
                }
                else
                {
                    p.DbType = typeMap[Property.PropertyType];
                }
                var v = Property.GetValue(ParameterValue);
                if (v == null)
                {
                    p.Value = DBNull.Value;
                }
                else
                {
                    if (Property.PropertyType.IsEnum)
                    {
                        p.Value = (int)v;
                    }
                    else
                    {
                        p.Value = v;
                    }
                }
                cmd.Parameters.Add(p);
            }
        }

        private static void AddParametersFromStringDictionary(DbCommand cmd, IDictionary<string, string> StringDictionary)
        {
            //
            // An IDictionary could also be an expando object
            //
            foreach (var Key in StringDictionary.Keys)
            {
                var p = cmd.CreateParameter();
                p.ParameterName = Key;
                var v = StringDictionary[Key];
                p.DbType = v == null ? DbType.String : typeMap[v.GetType()];
                p.Value = v;
                cmd.Parameters.Add(p);
            }
        }

        private static void AddParametersFromDictionary(DbCommand cmd, IDictionary<string, object> ObjectDictionary)
        {
            //
            // An IDictionary could also be an expando object
            //
            foreach (var Key in ObjectDictionary.Keys)
            {
                var p = cmd.CreateParameter();
                p.ParameterName = Key;
                var v = ObjectDictionary[Key];
                p.DbType = v == null ? DbType.String : typeMap[v.GetType()];
                p.Value = v ?? DBNull.Value;
                cmd.Parameters.Add(p);
            }
        }

        private static void AddValueTypeParameter(DbCommand cmd, int ParameterCount, object ParameterValue)
        {
            //
            // A simple value/string is create as "@p0", "@p1" etc
            //
            var p = cmd.CreateParameter();
            p.ParameterName = $"p{ParameterCount}";
            p.DbType = ParameterValue == null ? DbType.String : typeMap[ParameterValue.GetType()];
            p.Value = ParameterValue ?? DBNull.Value;
            cmd.Parameters.Add(p);
        }
        #endregion



        #region Object vs Value

        /// <summary>
        /// Value types and strings are loaded into a list in quite a different
        /// manner than objects. Objects need to be created first and then
        /// populated, while values and strings can be read directly from an
        /// IDataRecord.
        /// </summary>
        /// <param name="TypeOfT">The type to check if it is a value type or string</param>
        /// <returns>True if the type is a value type or string, otherwise false</returns>
        private static bool IsValueTypeOrString(Type TypeOfT)
        {
            return TypeOfT.IsValueType || TypeOfT == typeof(string);
        }

        #endregion



        #endregion
    }
}