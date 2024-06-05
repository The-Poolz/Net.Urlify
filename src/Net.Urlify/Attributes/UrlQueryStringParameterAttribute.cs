using System;

namespace Net.Urlify.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class UrlQueryStringParameterAttribute : Attribute
    {
        public string? Name { get; }
        public bool IsEncoded { get; }

        public UrlQueryStringParameterAttribute(string name = "", bool isEncoded = false)
        {
            Name = name;
            IsEncoded = isEncoded;
        }
    }
}
