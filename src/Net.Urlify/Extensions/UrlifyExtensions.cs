using System;
using System.Linq;
using System.Reflection;
using Net.Urlify.Models;
using Net.Urlify.Attributes;
using System.Collections.Generic;

namespace Net.Urlify.Extensions
{
    internal static class UrlifyExtensions
    {
        internal static QueryStringParameterCollection ToQueryStringParameters(this Urlify sourceObject)
        {
            var properties = sourceObject.GetType().GetProperties()
                .Where(prop => Attribute.IsDefined(prop, typeof(QueryStringPropertyAttribute)));

            var queryStringParams = new Dictionary<string, QueryStringParameterSettings>();
            foreach (var property in properties)
            {
                var attribute = property.GetCustomAttribute<QueryStringPropertyAttribute>();
                var value = property.GetValue(sourceObject);
                if (value == null || attribute == null) continue;

                var name = string.IsNullOrWhiteSpace(attribute.Name) ? property.Name : attribute.Name;
                var isEncoded = attribute.IsEncoded;

                queryStringParams.Add(name, new QueryStringParameterSettings(value.ToString(), isEncoded));
            }

            return new QueryStringParameterCollection(queryStringParams);
        }
    }
}
