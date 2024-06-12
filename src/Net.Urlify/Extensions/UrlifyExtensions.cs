using System.Linq;
using System.Reflection;
using Net.Urlify.Models;
using Net.Urlify.Attributes;

namespace Net.Urlify.Extensions
{
    internal static class UrlifyExtensions
    {
        internal static QueryStringParameterCollection ToQueryStringParameters(this Urlify sourceObject)
        {
            return new QueryStringParameterCollection(sourceObject.Properties
                .Select(property => new {
                    Property = property,
                    Attribute = property.GetCustomAttribute<QueryStringPropertyAttribute>(),
                    Value = property.GetValue(sourceObject)
                })
                .Where(x => x.Value != null && x.Attribute != null)
                .OrderBy(x => x.Attribute.Order)
                .ToDictionary(
                    x => string.IsNullOrWhiteSpace(x.Attribute.Name) ? x.Property.Name : x.Attribute.Name,
                    x => new QueryStringParameterSettings(x.Value.ToString(), x.Attribute.IsEncoded, x.Attribute.Order)
                ));
        }
    }
}
