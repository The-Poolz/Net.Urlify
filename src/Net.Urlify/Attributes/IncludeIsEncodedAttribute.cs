using System;

namespace Net.Urlify.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class IncludeIsEncodedAttribute : Attribute
    {
        public bool IsEncoded { get; }

        public IncludeIsEncodedAttribute(bool isEncoded = true)
        {
            IsEncoded = isEncoded;
        }
    }
}
