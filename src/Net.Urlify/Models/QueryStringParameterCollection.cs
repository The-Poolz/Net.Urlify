using System;
using Net.Urlify.Extensions;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Net.Urlify.Models
{
    [Serializable]
    public class QueryStringParameterCollection : Dictionary<string, QueryStringParameterSettings>
    {
        public QueryStringParameterCollection(object sourceObject)
            : base(sourceObject.ToQueryStringParameters())
        { }

        public QueryStringParameterCollection(IDictionary<string, QueryStringParameterSettings> queryStringParams)
            : base(queryStringParams)
        { }

        protected QueryStringParameterCollection(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }
}
