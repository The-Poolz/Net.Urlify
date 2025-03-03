using System;

namespace Net.Urlify.Attributes
{
    /// <summary>
    /// Specifies the attribute to mark properties that should be included as query string parameters in a URL.
    /// </summary>
    /// <remarks>
    /// Use this attribute to define how a property of a data model should be represented as a query string in the URL.<br/>
    /// For example, you can specify a custom name for the query parameter, whether it should be URL-encoded, and the order in which parameters should appear.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Property)]
    public class QueryStringPropertyAttribute : PropertyAttribute
    {
        public QueryStringPropertyAttribute(string name = "", bool isEncoded = false, int order = 0)
            : base(name, isEncoded, order)
        { }
    }
}
