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
    /// Represents the base class for URL data models. This class provides functionality to construct URLs with common parameters,
    /// leveraging environment-specific base URLs.
    /// </summary>
    public abstract class Urlify
    {
        private readonly string baseUrl;
        internal IEnumerable<PropertyInfo> Properties { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Urlify"/> class with the specified base URL.
        /// </summary>
        /// <param name="baseUrl">The base URL to use for constructing URLs.</param>
        protected Urlify(string baseUrl)
        {
            this.baseUrl = baseUrl;
            Properties = GetType().GetProperties()
                .Where(prop => Attribute.IsDefined(prop, typeof(QueryStringPropertyAttribute)));
        }

        /// <summary>
        /// Constructs a complete URL by appending necessary query parameters to the base URL.
        /// </summary>
        /// <returns>A <see cref="Url"/> object that represents the complete URL with query parameters included.</returns>
        public Url BuildUrl()
        {
            var parameters = this.ToQueryStringParameters();
            return parameters
                .Aggregate(new Url(baseUrl), (currentUrl, param) =>
                    currentUrl.SetQueryParam(param.Key, param.Value.Value, param.Value.IsEncoded));
        }
    }
}
