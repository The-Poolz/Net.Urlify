using Flurl;
using System;
using System.Linq;
using System.Reflection;
using Net.Urlify.Extensions;
using Net.Urlify.Attributes;
using System.Collections.Generic;

namespace Net.Urlify
{
    /// <summary>
    /// Provides a base class for constructing URLs with query parameters from objects derived from this class.
    /// </summary>
    /// <remarks>
    /// This class encapsulates common functionality for URL construction by using query parameters
    /// extracted from properties marked with the <see cref="QueryStringPropertyAttribute"/>.
    /// </remarks>
    public abstract class Urlify
    {
        private readonly string baseUrl;
        internal IEnumerable<PropertyInfo> Properties { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Urlify"/> class with the specified base URL.
        /// </summary>
        /// <param name="baseUrl">The base URL to use for constructing URLs. This URL serves as the starting point to which query parameters will be appended.</param>
        protected Urlify(string baseUrl)
        {
            this.baseUrl = baseUrl;
            Properties = GetType().GetProperties()
                .Where(prop => Attribute.IsDefined(prop, typeof(QueryStringPropertyAttribute)));
        }

        /// <summary>
        /// Constructs a complete URL by appending query parameters extracted from the object's properties to the base URL.
        /// </summary>
        /// <returns>
        /// A <see cref="Url"/> object that represents the complete URL with query parameters included.
        /// </returns>
        /// <remarks>
        /// This method aggregates query parameters by extracting values from properties marked with <see cref="QueryStringPropertyAttribute"/>.<br/>
        /// Each parameter is added to the base URL using URL encoding settings specified in the attribute.
        /// </remarks>
        public Url BuildUrl()
        {
            var parameters = this.ToQueryStringParameters();
            return parameters
                .Aggregate(new Url(baseUrl), (currentUrl, param) =>
                    currentUrl.SetQueryParam(param.Key, param.Value.Value, param.Value.IsEncoded));
        }
    }
}
