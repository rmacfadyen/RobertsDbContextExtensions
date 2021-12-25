namespace RobertsDbContextExtensions
{
    internal class DataRecordConverter
    {
        //
        // Cache of FastProperty objects per object property
        //
        private static readonly ConcurrentDictionary<PropertyInfo, FastPropertySetter> Setters = new();

        /// <summary>
        /// Given a datarecord and ordinal return an object that can be
        /// assigned to a value of the destination type. For example if
        /// the destination is a DateTime? then return the source field
        /// as either a DateTime or null.
        /// 
        /// Very unforgiving of type mismatches, will throw InvalidCastException
        /// if the source and destination types are not compatible. Not all
        /// conversions are supported (eg. int to bool? throws InvalidCastException)
        /// </summary>
        /// <param name="dataRecord"></param>
        /// <param name="Ordinal"></param>
        /// <param name="TypeOfT"></param>
        /// <returns></returns>
        public static object ReadValue(IDataRecord dataRecord, int Ordinal, Type TypeOfT)
        {
            var Value = dataRecord.GetValue(Ordinal);
            var ValueTypeOf = Value.GetType();

            //
            // If the source type is the same as the destination type we're good
            //
            if (ValueTypeOf == TypeOfT)
            {
                return Value;
            }

            //
            // Destination types of enums need special attention
            //  - Will throw an exception if the source value can't be converted to an enum
            //
            if (TypeOfT.IsEnum)
            {
                //
                // If the source type is a string use enum parsing to get the destination value
                //
                if (Value is string sValue)
                {
                    return (int)Enum.Parse(TypeOfT, sValue, true);
                }
                else
                {
                    //
                    // Otherwise just change it's type
                    //
                    return TrappedInvalidCast(ValueTypeOf, typeof(int), () => Enum.ToObject(TypeOfT, Value));
                }
            }

            //
            // If the destination is nullable (eg. DateTime?) and the 
            // destination can be assigned from the source just return 
            // the value. Otherwise if the value is DbNull just return
            // null. For some reason int? would fail the IsAssignableFrom
            // test. Weird.
            //
            var DestinationTypeIsNullable = (TypeOfT.IsGenericType && TypeOfT.GetGenericTypeDefinition() == typeof(Nullable<>));
            if (DestinationTypeIsNullable)
            {
                if (TypeOfT.IsAssignableFrom(ValueTypeOf))
                {
                    return Value;
                }
                if (Value == DBNull.Value)
                {
                    return null;
                }
            }

            //
            // Strings need a little bit of extra care around null
            //
            if (TypeOfT == typeof(string))
            {
                if (Value == DBNull.Value)
                {
                    return null;
                }
            }

            //
            // Lastly just try to change the type
            //
            return TrappedInvalidCast(ValueTypeOf, TypeOfT, () => Convert.ChangeType(Value, TypeOfT));
        }


        /// <summary>
        /// Common routine for handling an invalid cast execption. Need to provide
        /// extra information so it's easier to sort out what's causing the problem,
        /// especially the name of the property being assigned to.
        /// </summary>
        /// <param name="FromType">The type of the field in the IDataRecord</param>
        /// <param name="ToType">The type the field is being converted to</param>
        /// <param name="operation">a lambda that executes an operation that might throw InvalidCastException</param>
        /// <returns>The result of the lambda</returns>
        private static object TrappedInvalidCast(Type FromType, Type ToType, Func<object> operation)
        {
            try
            {
                return operation();
            }
            catch (InvalidCastException e)
            {
                var FromTypeName = GetDisplayName(FromType);
                var ToTypeName = GetDisplayName(ToType);
                var Message = $"Invalid cast. Value of type '{FromTypeName}' cannot be cast to '{ToTypeName}'.";
                throw new InvalidCastException(Message, e);
            }
        }

        /// <summary>
        /// Populate the given object with values from the datareader's current record
        /// </summary>
        /// <param name="dbDataReader"></param>
        /// <param name="ColumnsToRead"></param>
        /// <param name="o"></param>
        public static void ReadObject(
             IDataRecord dbDataReader,
             IList<PropertyDetails> ColumnsToRead,
             object o)
        {
            //
            // Do each column in the destination
            //
            foreach (var Column in ColumnsToRead)
            {
                //
                // If the source value is DbNull use null (if the type supports it)
                //
                if (dbDataReader.IsDBNull(Column.Ordinal))
                {
                    if (Column.IsNullable)
                    {
                        Column.Setter.Set(o, null);
                    }
                    else
                    {
                        var Message = $"{Column.PropertyName} cannot be set to null because it is of type '{GetDisplayName(Column.PropertyType)}'.";
                        throw new NullReferenceException(Message);
                    }
                }
                else
                {
                    //
                    // Get a value compatible with the destimation
                    //
                    object ColumnValue;

                    try
                    {
                        ColumnValue = ReadValue(dbDataReader, Column.Ordinal, Column.PropertyType);
                    }
                    catch (InvalidCastException e)
                    {
                        var Message = $"Invalid cast setting property {Column.PropertyName}. {e.Message.Replace("Invalid cast. ", string.Empty)}";
                        throw new InvalidCastException(Message, e.InnerException);
                    }

                    //
                    // Assign the value
                    //
                    Column.Setter.Set(o, ColumnValue);
                }
            }
        }


        /// <summary>
        /// Populate the given object with values from the datareader's current record
        /// </summary>
        /// <param name="dbDataReader"></param>
        /// <param name="ColumnOrdinalsToRead"></param>
        public static object[] ReadDynamicObject(
             IDataRecord dbDataReader,
             IList<int> ColumnOrdinalsToRead)
        {
            var DynamicObject = new object[ColumnOrdinalsToRead.Count];

            //
            // Do each column in the destination
            //
            var i = 0;
            foreach (var ColumnOrdinal in ColumnOrdinalsToRead)
            {
                //
                // If the source value is DbNull use null (if the type supports it)
                //
                if (dbDataReader.IsDBNull(ColumnOrdinal))
                {
                    DynamicObject[i] = null;
                }
                else
                {
                    DynamicObject[i] = dbDataReader.GetValue(ColumnOrdinal);
                }

                i += 1;
            }

            return DynamicObject;
        }

        /// <summary>
        /// Get a nice display name for a type (matches what would be used in source).
        /// From https://stackoverflow.com/questions/14910584/get-propertytype-name-in-reflection-from-nullable-type
        /// </summary>
        /// <param name="t">The type who's display name will be returned</param>
        /// <returns>The display name for the type as it would be in source code.</returns>
        internal static string GetDisplayName(Type t)
        {
            //
            // Handle nullable types
            //
            if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>))
                return $"{GetDisplayName(t.GetGenericArguments()[0])}?";

            //
            // Handle generic types
            //
            if (t.IsGenericType)
                return
                    $"{t.Name.Remove(t.Name.IndexOf('`'))}<{string.Join(",", t.GetGenericArguments().Select(at => GetDisplayName(at)))}>";

            //
            // Handle arrays
            //
            if (t.IsArray)
            {
                var ElmentType = t.GetElementType();
                return $"{GetDisplayName(ElmentType)}[{new string(',', t.GetArrayRank() - 1)}]";
            }

            //
            // No luck
            //
            return t.Name;
        }


        /// <summary>
        /// Given a datareader and a object definition figure out which columns
        /// in the object match columns in the datareader. In otherwords this
        /// sorts out which columns will be read into an object. Some columns
        /// in the datareader might not get read, some columns in the destination
        /// object might not get set. It all depends on the names matching.
        /// 
        /// The core of this is a list of matching columns and thier associated
        /// fast property setter.
        /// </summary>
        /// <param name="dbDataReader"></param>
        /// <param name="TypeOfT"></param>
        /// <returns></returns>
        public static IList<PropertyDetails> GetColumnMapping(IDataReader dbDataReader, Type TypeOfT)
        {
            //
            // Fish out the list of columns returned by the query
            //
            var Columns = new Dictionary<string, int>();
            for (var i = 0; i < dbDataReader.FieldCount; i += 1)
            {
                //
                // Ignore duplicate columns (takes the first value)
                //
                var ColumnName = dbDataReader.GetName(i);
                if (!Columns.ContainsKey(ColumnName))
                {
                    Columns.Add(ColumnName, i);
                }
            }

            //
            // Fish out the matching object properties
            //
            var Properties = TypeOfT.GetProperties();
            var ColumnsToRead = new List<PropertyDetails>();
            foreach (var Property in Properties)
            {
                if (Columns.ContainsKey(Property.Name))
                {
                    var Found = Setters.TryGetValue(Property, out var ThisSetter);
                    if (!Found)
                    {
                        var ReadOnlyProperty = null == (Property.GetSetMethod() ?? Property.GetSetMethod(true));
                        if (ReadOnlyProperty)
                        {
                            continue;
                        }

                        ThisSetter = new FastPropertySetter(Property);
                        Setters.TryAdd(Property, ThisSetter);
                    }
                    var ActualSetter = ThisSetter ?? throw new InvalidOperationException("No property setter was available");

                    var IsNullable = false;
                    if (!Property.PropertyType.IsValueType)
                    {
                        IsNullable = true;
                    }
                    else
                    {
                        if (Nullable.GetUnderlyingType(Property.PropertyType) != null)
                        {
                            IsNullable = true;
                        }
                    }

                    var ThisProperty = new PropertyDetails(Property.PropertyType, ActualSetter, Property.Name)
                    {
                        Ordinal = Columns[Property.Name],
                        IsEnum = Property.PropertyType.IsEnum,
                        IsNullable = IsNullable
                    };

                    ColumnsToRead.Add(ThisProperty);
                }
            }

            //
            // Throw if there are no matching columns between the class and the query
            //
            if (ColumnsToRead.Count == 0)
            {
                throw new ArgumentException("Map of query results to object properties is empty (no matching columns)");
            }

            return ColumnsToRead;
        }


        public static (FastPropertySetter, IList<int>) GetDynamicColumnMapping(IDataReader dbDataReader, Type TypeOfT, IEnumerable<string> DynamicColumns)
        {
            //
            // Fish out which property will store the dynamic fields
            //
            var Property = (
                from p in TypeOfT.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
                where
                    p.PropertyType.IsArray
                    && p.PropertyType == typeof(object[])
                select p
            ).FirstOrDefault();
            if (Property == null)
            {
                throw new InvalidOperationException($"Cannot query for dynamic columns because a property of type object[] was not found on type \"{TypeOfT.Name}\"");
            }

            //
            // Get the possibly cached setter for the property
            //
            var Found = Setters.TryGetValue(Property, out var ThisSetter);
            if (!Found)
            {
                ThisSetter = new FastPropertySetter(Property);
                Setters.TryAdd(Property, ThisSetter);
            }
            if (ThisSetter == null) throw new InvalidOperationException("No setter was available");

            //
            // Fish out the list of columns returned by the query
            //
            var Columns = new Dictionary<string, int>();
            for (var i = 0; i < dbDataReader.FieldCount; i += 1)
            {
                //
                // Ignore duplicate columns (takes the first value)
                //
                var ColumnName = dbDataReader.GetName(i);
                if (!Columns.ContainsKey(ColumnName))
                {
                    Columns.Add(ColumnName, i);
                }
            }

            //
            // Fish out the matching object properties
            //
            var ColumnsToRead = new List<int>();
            foreach (var DynamicColumnName in DynamicColumns)
            {
                if (Columns.ContainsKey(DynamicColumnName))
                {
                    ColumnsToRead.Add(Columns[DynamicColumnName]);
                }
                else
                {
                    throw new InvalidOperationException($"Cannot query for dynamic columns because the dynamic column \"{DynamicColumnName}\" was not returned by the query");
                }
            }

            return (ThisSetter, ColumnsToRead);
        }
    }
}