using System;
using System.Linq;
using Net.Urlify.Models;
using Net.Urlify.Attributes;
using System.Collections.Generic;
using System.Reflection;

namespace Net.Urlify.Extensions
{
    public static class ObjectExtensions
    {
        public static QueryStringParameterCollection ToQueryStringParameters(this object obj)
        {
            var properties = obj.GetType().GetProperties()
                .Where(prop => Attribute.IsDefined(prop, typeof(QueryStringPropertyAttribute)));

            var queryStringParams = new Dictionary<string, QueryStringParameterSettings>();
            foreach (var property in properties)
            {
                var attribute = property.GetCustomAttribute<QueryStringPropertyAttribute>();
                var value = property.GetValue(obj);
                if (value == null || attribute == null) continue;

                var name = string.IsNullOrWhiteSpace(attribute.Name) ? property.Name : attribute.Name;
                var isEncoded = attribute.IsEncoded;

                queryStringParams.Add(name, new QueryStringParameterSettings(value.ToString(), isEncoded));
            }

            return new QueryStringParameterCollection(queryStringParams);
        }
    }
}
