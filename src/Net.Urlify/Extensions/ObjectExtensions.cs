using Net.Urlify.Types;
using System.Reflection;
using Net.Urlify.Attributes;
using System.Collections.Generic;

namespace Net.Urlify.Extensions
{
    public static class ObjectExtensions
    {
        public static Dictionary<string, (string Value, bool IsEncoded)> ToDictionary(this object obj)
        {
            var properties = obj.GetType().GetProperties();
            var dictionary = new Dictionary<string, (string Value, bool IsEncoded)>();

            foreach (var property in properties)
            {
                var value = property.GetValue(obj);
                if (value == null) continue;

                var isEncoded = property.GetCustomAttribute<IncludeIsEncodedAttribute>()?.IsEncoded ?? true;
                var casingAttribute = property.GetCustomAttribute<PropertyNameCasingAttribute>();
                var key = ApplyCasing(property.Name, casingAttribute?.Casing ?? PropertyNameCasing.None);

                dictionary.Add(key, (value.ToString(), isEncoded)!);
            }

            return dictionary;
        }

        private static string ApplyCasing(string input, PropertyNameCasing casing)
        {
            return casing switch
            {
                PropertyNameCasing.FirstLetterUpperCase => char.ToLower(input[0]) + input.Substring(1),
                PropertyNameCasing.AllUpperCase => input.ToLower(),
                _ => input
            };
        }
    }
}
