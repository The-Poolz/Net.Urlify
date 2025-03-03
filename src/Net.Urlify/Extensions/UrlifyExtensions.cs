using System.Linq;
using System.Reflection;
using Net.Urlify.Models;
using Net.Urlify.Attributes;

namespace Net.Urlify.Extensions
{
    internal static class UrlifyExtensions
    {
        internal static ParameterCollection ToPathParameters(this Urlify sourceObject)
        {
            return sourceObject.ToParameters<PathPropertyAttribute>();
        }

        internal static ParameterCollection ToQueryStringParameters(this Urlify sourceObject)
        {
            return sourceObject.ToParameters<QueryStringPropertyAttribute>();
        }

        internal static ParameterCollection ToParameters<TPropertyAttribute>(this Urlify sourceObject)
            where TPropertyAttribute : PropertyAttribute
        {
            return new ParameterCollection(sourceObject.Properties
                .Select(property => new {
                    Property = property,
                    Attribute = property.GetCustomAttribute<TPropertyAttribute>(),
                    Value = property.GetValue(sourceObject)
                })
                .Where(x => x.Value != null && x.Attribute != null)
                .OrderBy(x => x.Attribute.Order)
                .ToDictionary(
                    x => string.IsNullOrWhiteSpace(x.Attribute.Name) ? x.Property.Name : x.Attribute.Name,
                    x => new ParameterSettings(x.Value.ToString(), x.Attribute.IsEncoded, x.Attribute.Order)
                ));
        }
    }
}
