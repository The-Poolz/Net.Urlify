using Net.Urlify.Extensions;
using System.Collections.Generic;

namespace Net.Urlify.Models
{
    public class QueryStringParameters : Dictionary<string, QueryStringParameterSettings>
    {
        public QueryStringParameters(object obj)
            : base(obj.ToQueryStringParameters())
        { }

        public QueryStringParameters(IDictionary<string, QueryStringParameterSettings> queryStringParameters)
            : base(queryStringParameters)
        { }
    }
}
