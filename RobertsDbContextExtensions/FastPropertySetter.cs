using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RobertsDbContextExtensions
{
    //
    // From: http://geekswithblogs.net/Madman/archive/2008/06/27/faster-reflection-using-expression-trees.aspx
    //
    internal class FastPropertySetter
    {
        readonly Action<object, object> SetDelegate;

        /// <summary>
        /// A FastProperty setter allows for pretty quick setting of 
        /// a specified property on an object. Caching the setter
        /// will ensure the very fastest setting possible
        /// </summary>
        /// <param name="Property"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public FastPropertySetter(PropertyInfo Property)
        {
            //
            // Get the type this property is for
            //
            var DeclaringType = Property.DeclaringType ?? throw new ArgumentNullException(nameof(Property.DeclaringType));

            //
            // Fish out the get set method
            //  - prefer public but use private if not available
            //
            var GetSetMethod =
                Property.GetSetMethod()
                ?? Property.GetSetMethod(true)
                ?? throw new InvalidOperationException("Property GetSetMethod(true) returned null");

            //
            // Build the right hand side 
            //  - value as T is slightly faster than (T)value, so if it's not a value type, use that
            //
            var value = Expression.Parameter(typeof(object), "value");
            var valueCast =
                Property.PropertyType.IsValueType
                ? Expression.Convert(value, Property.PropertyType)
                : Expression.TypeAs(value, Property.PropertyType);

            //
            // Build the left hand side
            //
            var instance = Expression.Parameter(typeof(object), "instance");
            var instanceCast = 
                DeclaringType.IsValueType 
                ? Expression.Convert(instance, DeclaringType) 
                : Expression.TypeAs(instance, DeclaringType);

            //
            // Finally compile the set delegate
            //
            SetDelegate = 
                Expression.Lambda<Action<object, object>>(
                    Expression.Call(instanceCast, GetSetMethod, valueCast), 
                    new[] { instance, value }
                ).Compile();
        }


        /// <summary>
        /// Sets an object instance's property value quickly
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="value"></param>
        public void Set(object instance, object value) => SetDelegate(instance, value);
    }
}
