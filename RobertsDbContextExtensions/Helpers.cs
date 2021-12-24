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
    static class Helpers
    {
        /// <summary>
        /// Map of primitive types to DbType.
        /// </summary>
        internal static readonly Dictionary<Type, DbType> typeMap = new()
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


        #region Reader helpers

        /// <summary>
        /// Load a list of T's from a IDataReader
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dbDataReader"></param>
        /// <param name="DynamicColumns"></param>
        /// <returns></returns>
        internal static IList<T> ListFromDbReader<T>(IDataReader dbDataReader, IEnumerable<string> DynamicColumns = null)
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
        internal static System.Collections.IList ListFromDbReader(
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
        /// <param name="Parameters">A list of values to be passed as parameters. See <see href="https://github.com/rmacfadyen/RobertsDbContextExtensions/blob/master/Parameters.md">Passing parameters</see></param>
        /// <returns></returns>
        internal static T ExecuteReaderFromSql<T>(
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
        internal static T ExecuteReaderFromCmd<T>(
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
        internal static void EnsureConnectionOpen(DbContext ctx)
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




        #region Object vs Value

        /// <summary>
        /// Value types and strings are loaded into a list in quite a different
        /// manner than objects. Objects need to be created first and then
        /// populated, while values and strings can be read directly from an
        /// IDataRecord.
        /// </summary>
        /// <param name="TypeOfT">The type to check if it is a value type or string</param>
        /// <returns>True if the type is a value type or string, otherwise false</returns>
        internal static bool IsValueTypeOrString(Type TypeOfT)
        {
            return TypeOfT.IsValueType || TypeOfT == typeof(string);
        }

        #endregion
    }
}
