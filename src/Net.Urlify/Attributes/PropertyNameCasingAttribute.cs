using System;
using Net.Urlify.Types;

namespace Net.Urlify.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyNameCasingAttribute : Attribute
    {
        public PropertyNameCasing Casing { get; }

        public PropertyNameCasingAttribute(PropertyNameCasing casing = PropertyNameCasing.None)
        {
            Casing = casing;
        }
    }
}
