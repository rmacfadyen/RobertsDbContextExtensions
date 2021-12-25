namespace RobertsDbContextExtensions
{
    /// <summary>
    /// Extensions that load lists from an IDbCommand
    /// </summary>
    public static class ListFromIDbCommandExtensions
    {


        #region ExecuteList<T1..T6> from CMD

        /// <summary>
        /// Execute the provided command and return the result set mapped to
        /// an IList&lt;T&gt;.
        /// </summary>
        /// <seealso cref="ExecuteList{T}(DbContext, IDbCommand)"/>
        /// <seealso cref="ExecuteList{T1, T2}(DbContext, IDbCommand)"/>
        /// <seealso cref="ExecuteList{T1, T2, T3}(DbContext, IDbCommand)"/>
        /// <seealso cref="ExecuteList{T1, T2, T3, T4}(DbContext, IDbCommand)"/>
        /// <seealso cref="ExecuteList{T1, T2, T3, T4, T5}(DbContext, IDbCommand)"/>
        /// <seealso cref="ExecuteList{T1, T2, T3, T4, T5, T6}(DbContext, IDbCommand)"/>
        /// <typeparam name="T">The type the first result set should be mapped to.</typeparam>
        /// <param name="ctx">The DbContext to execute the command on.</param>
        /// <param name="cmd">The command to be executed.</param>
        /// <returns>The first result set mapped to a list of T's.</returns>
        public static IList<T> ExecuteList<T>(
            this DbContext ctx, IDbCommand cmd
        )
        {
            return ctx.ExecuteReaderFromCmd(
                (dbReader, _) => Helpers.ListFromDbReader<T>(dbReader),
                null,
                cmd
            );
        }


        /// <summary>
        /// Execute the provided command and return a tuple of the 
        /// first two result sets mapped to lists.
        /// </summary>
        /// <seealso cref="ExecuteList{T}(DbContext, IDbCommand)"/>
        /// <seealso cref="ExecuteList{T1, T2}(DbContext, IDbCommand)"/>
        /// <seealso cref="ExecuteList{T1, T2, T3}(DbContext, IDbCommand)"/>
        /// <seealso cref="ExecuteList{T1, T2, T3, T4}(DbContext, IDbCommand)"/>
        /// <seealso cref="ExecuteList{T1, T2, T3, T4, T5}(DbContext, IDbCommand)"/>
        /// <seealso cref="ExecuteList{T1, T2, T3, T4, T5, T6}(DbContext, IDbCommand)"/>
        /// <typeparam name="T1">The type the first result set should be mapped to.</typeparam>
        /// <typeparam name="T2">The type the second result set should be mapped to.</typeparam>
        /// <param name="ctx">The DbContext to execute the command on.</param>
        /// <param name="cmd">The command to be executed.</param>
        /// <returns>A tuple, with each value being the corresponding mapping of a result set.</returns>
        public static (IList<T1>, IList<T2>) ExecuteList<T1, T2>(
            this DbContext ctx, IDbCommand cmd
        )
        {
            return ctx.ExecuteReaderFromCmd<(IList<T1>, IList<T2>)>(
                (dbReader, _) => {
                    var t1 = Helpers.ListFromDbReader<T1>(dbReader);
                    dbReader.NextResult();

                    var t2 = Helpers.ListFromDbReader<T2>(dbReader);

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
        /// <seealso cref="ExecuteList{T}(DbContext, IDbCommand)"/>
        /// <seealso cref="ExecuteList{T1, T2}(DbContext, IDbCommand)"/>
        /// <seealso cref="ExecuteList{T1, T2, T3}(DbContext, IDbCommand)"/>
        /// <seealso cref="ExecuteList{T1, T2, T3, T4}(DbContext, IDbCommand)"/>
        /// <seealso cref="ExecuteList{T1, T2, T3, T4, T5}(DbContext, IDbCommand)"/>
        /// <seealso cref="ExecuteList{T1, T2, T3, T4, T5, T6}(DbContext, IDbCommand)"/>
        /// <typeparam name="T1">The type the first result set should be mapped to.</typeparam>
        /// <typeparam name="T2">The type the second result set should be mapped to.</typeparam>
        /// <typeparam name="T3">The type the third result set should be mapped to.</typeparam>
        /// <param name="ctx">The DbContext to execute the command on.</param>
        /// <param name="cmd">The command to be executed.</param>
        /// <returns>A tuple, with each value being the corresponding mapping of a result set.</returns>
        public static (IList<T1>, IList<T2>, IList<T3>) ExecuteList<T1, T2, T3>(
            this DbContext ctx, IDbCommand cmd
        )
        {
            return ctx.ExecuteReaderFromCmd<(IList<T1>, IList<T2>, IList<T3>)>(
                (dbReader, _) => {
                    var t1 = Helpers.ListFromDbReader<T1>(dbReader);
                    dbReader.NextResult();

                    var t2 = Helpers.ListFromDbReader<T2>(dbReader);
                    dbReader.NextResult();

                    var t3 = Helpers.ListFromDbReader<T3>(dbReader);

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
        /// <seealso cref="ExecuteList{T}(DbContext, IDbCommand)"/>
        /// <seealso cref="ExecuteList{T1, T2}(DbContext, IDbCommand)"/>
        /// <seealso cref="ExecuteList{T1, T2, T3}(DbContext, IDbCommand)"/>
        /// <seealso cref="ExecuteList{T1, T2, T3, T4}(DbContext, IDbCommand)"/>
        /// <seealso cref="ExecuteList{T1, T2, T3, T4, T5}(DbContext, IDbCommand)"/>
        /// <seealso cref="ExecuteList{T1, T2, T3, T4, T5, T6}(DbContext, IDbCommand)"/>
        /// <typeparam name="T1">The type the first result set should be mapped to.</typeparam>
        /// <typeparam name="T2">The type the second result set should be mapped to.</typeparam>
        /// <typeparam name="T3">The type the third result set should be mapped to.</typeparam>
        /// <typeparam name="T4">The type the forth result set should be mapped to.</typeparam>
        /// <param name="ctx">The DbContext to execute the command on.</param>
        /// <param name="cmd">The command to be executed.</param>
        /// <returns>A tuple, with each value being the corresponding mapping of a result set.</returns>
        public static (IList<T1>, IList<T2>, IList<T3>, IList<T4>) ExecuteList<T1, T2, T3, T4>(
            this DbContext ctx, IDbCommand cmd
        )
        {
            return ctx.ExecuteReaderFromCmd<(IList<T1>, IList<T2>, IList<T3>, IList<T4>)>(
                (dbReader, _) => {
                    var t1 = Helpers.ListFromDbReader<T1>(dbReader);
                    dbReader.NextResult();

                    var t2 = Helpers.ListFromDbReader<T2>(dbReader);
                    dbReader.NextResult();

                    var t3 = Helpers.ListFromDbReader<T3>(dbReader);
                    dbReader.NextResult();

                    var t4 = Helpers.ListFromDbReader<T4>(dbReader);

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
        /// <seealso cref="ExecuteList{T}(DbContext, IDbCommand)"/>
        /// <seealso cref="ExecuteList{T1, T2}(DbContext, IDbCommand)"/>
        /// <seealso cref="ExecuteList{T1, T2, T3}(DbContext, IDbCommand)"/>
        /// <seealso cref="ExecuteList{T1, T2, T3, T4}(DbContext, IDbCommand)"/>
        /// <seealso cref="ExecuteList{T1, T2, T3, T4, T5}(DbContext, IDbCommand)"/>
        /// <seealso cref="ExecuteList{T1, T2, T3, T4, T5, T6}(DbContext, IDbCommand)"/>
        /// <typeparam name="T1">The type the first result set should be mapped to.</typeparam>
        /// <typeparam name="T2">The type the second result set should be mapped to.</typeparam>
        /// <typeparam name="T3">The type the third result set should be mapped to.</typeparam>
        /// <typeparam name="T4">The type the forth result set should be mapped to.</typeparam>
        /// <typeparam name="T5">The type the fifth result set should be mapped to.</typeparam>
        /// <param name="ctx">The DbContext to execute the command on.</param>
        /// <param name="cmd">The command to be executed.</param>
        /// <returns>A tuple, with each value being the corresponding mapping of a result set.</returns>
        public static (IList<T1>, IList<T2>, IList<T3>, IList<T4>, IList<T5>) ExecuteList<T1, T2, T3, T4, T5>(
            this DbContext ctx, IDbCommand cmd
        )
        {
            return ctx.ExecuteReaderFromCmd<(IList<T1>, IList<T2>, IList<T3>, IList<T4>, IList<T5>)>(
                (dbReader, _) => {
                    var t1 = Helpers.ListFromDbReader<T1>(dbReader);
                    dbReader.NextResult();

                    var t2 = Helpers.ListFromDbReader<T2>(dbReader);
                    dbReader.NextResult();

                    var t3 = Helpers.ListFromDbReader<T3>(dbReader);
                    dbReader.NextResult();

                    var t4 = Helpers.ListFromDbReader<T4>(dbReader);
                    dbReader.NextResult();

                    var t5 = Helpers.ListFromDbReader<T5>(dbReader);

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
        /// <seealso cref="ExecuteList{T}(DbContext, IDbCommand)"/>
        /// <seealso cref="ExecuteList{T1, T2}(DbContext, IDbCommand)"/>
        /// <seealso cref="ExecuteList{T1, T2, T3}(DbContext, IDbCommand)"/>
        /// <seealso cref="ExecuteList{T1, T2, T3, T4}(DbContext, IDbCommand)"/>
        /// <seealso cref="ExecuteList{T1, T2, T3, T4, T5}(DbContext, IDbCommand)"/>
        /// <seealso cref="ExecuteList{T1, T2, T3, T4, T5, T6}(DbContext, IDbCommand)"/>
        /// <typeparam name="T1">The type the first result set should be mapped to.</typeparam>
        /// <typeparam name="T2">The type the second result set should be mapped to.</typeparam>
        /// <typeparam name="T3">The type the third result set should be mapped to.</typeparam>
        /// <typeparam name="T4">The type the forth result set should be mapped to.</typeparam>
        /// <typeparam name="T5">The type the fifth result set should be mapped to.</typeparam>
        /// <typeparam name="T6">The type the sixth result set should be mapped to.</typeparam>
        /// <param name="ctx">The DbContext to execute the command on.</param>
        /// <param name="cmd">The command to be executed.</param>
        /// <returns>A tuple, with each value being the corresponding mapping of a result set.</returns>
        public static (IList<T1>, IList<T2>, IList<T3>, IList<T4>, IList<T5>, IList<T6>) ExecuteList<T1, T2, T3, T4, T5, T6>(
            this DbContext ctx, IDbCommand cmd
        )
        {
            return ctx.ExecuteReaderFromCmd<(IList<T1>, IList<T2>, IList<T3>, IList<T4>, IList<T5>, IList<T6>)>(
                (dbReader, _) => {
                    var t1 = Helpers.ListFromDbReader<T1>(dbReader);
                    dbReader.NextResult();

                    var t2 = Helpers.ListFromDbReader<T2>(dbReader);
                    dbReader.NextResult();

                    var t3 = Helpers.ListFromDbReader<T3>(dbReader);
                    dbReader.NextResult();

                    var t4 = Helpers.ListFromDbReader<T4>(dbReader);
                    dbReader.NextResult();

                    var t5 = Helpers.ListFromDbReader<T5>(dbReader);
                    dbReader.NextResult();

                    var t6 = Helpers.ListFromDbReader<T6>(dbReader);

                    return (t1, t2, t3, t4, t5, t6);
                },
                null,
                cmd
            );
        }
        #endregion


    }
}
