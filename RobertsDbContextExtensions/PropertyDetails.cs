using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobertsDbContextExtensions
{
    internal class PropertyDetails
    {
        public PropertyDetails(
            Type PropertyType,
            FastPropertySetter Setter,
            string PropertyName)
        {
            this.PropertyType = PropertyType;
            this.Setter = Setter;
            this.PropertyName = PropertyName;
        }

        public Type PropertyType { get; }
        public FastPropertySetter Setter { get; }
        public string PropertyName { get; set; }
        public int Ordinal { get; set;  }
        public bool IsNullable { get; set; }
        public bool IsEnum { get; set; }
    }
}
