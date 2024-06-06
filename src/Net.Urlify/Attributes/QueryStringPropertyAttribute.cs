using System;

namespace Net.Urlify.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class QueryStringPropertyAttribute : Attribute
    {
        public string Name { get; }
        public bool IsEncoded { get; }

        public QueryStringPropertyAttribute(string name = "", bool isEncoded = true)
        {
            Name = name;
            IsEncoded = isEncoded;
        }
    }
}
