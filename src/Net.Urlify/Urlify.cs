using Flurl;
using System.Linq;
using Net.Urlify.Extensions;

namespace Net.Urlify
{
    /// <summary>
    /// Represents the base class for URL data models. This class provides functionality to construct URLs with common parameters,
    /// leveraging environment-specific base URLs.
    /// </summary>
    public abstract class Urlify
    {
        private readonly string baseUrl;

        /// <summary>
        /// Initializes a new instance of the <see cref="Urlify"/> class with the specified base URL.
        /// </summary>
        /// <param name="baseUrl">The base URL to use for constructing URLs.</param>
        protected Urlify(string baseUrl)
        {
            this.baseUrl = baseUrl;
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
