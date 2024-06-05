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
        public static QueryStringParameters ToQueryStringParameters(this object obj)
        {
            var properties = obj.GetType().GetProperties()
                .Where(prop => Attribute.IsDefined(prop, typeof(UrlQueryStringParameterAttribute)));

            var dictionary = new Dictionary<string, QueryStringParameterSettings>();
            foreach (var property in properties)
            {
                var attribute = property.GetCustomAttribute<UrlQueryStringParameterAttribute>();
                var value = property.GetValue(obj);
                if (value == null || attribute == null) continue;

                var name = string.IsNullOrWhiteSpace(attribute.Name) ? property.Name : attribute.Name;
                var isEncoded = attribute.IsEncoded;

                dictionary.Add(name, new QueryStringParameterSettings(value.ToString(), isEncoded));
            }

            return new QueryStringParameters(dictionary);
        }
    }
}
