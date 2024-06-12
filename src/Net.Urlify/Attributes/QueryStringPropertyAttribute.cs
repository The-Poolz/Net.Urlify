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
    public class QueryStringPropertyAttribute : Attribute
    {
        /// <summary>
        /// Gets the name of the query parameter.
        /// </summary>
        /// <value>
        /// The name used for the query string parameter in the URL. If left empty, the property name will be used.
        /// </value>
        public string Name { get; }

        /// <summary>
        /// Gets a value indicating whether the query parameter value has already been URL-encoded.
        /// </summary>
        /// <value>
        /// <see langword="true"/> if the query parameter value has already been URL-encoded; otherwise, <see langword="false"/>.
        /// </value>
        public bool IsEncoded { get; }

        /// <summary>
        /// Gets the order in which the query parameter should appear in the URL.
        /// </summary>
        /// <value>
        /// The integer representing the order of the parameter. Parameters are sorted in ascending order. Default is 0, which does not enforce any specific positioning unless other parameters specify an order.
        /// </value>
        public int Order { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryStringPropertyAttribute"/> class.
        /// </summary>
        /// <param name="name">The name of the query string parameter. Defaults to an empty string.</param>
        /// <param name="isEncoded">Indicates whether the query parameter value has already been URL-encoded. Defaults to <see langword="false"/>.</param>
        /// <param name="order">The order in which the query parameter appears in the URL. Defaults to 0.</param>
        public QueryStringPropertyAttribute(string name = "", bool isEncoded = false, int order = 0)
        {
            Name = name;
            IsEncoded = isEncoded;
            Order = order;
        }
    }
}
