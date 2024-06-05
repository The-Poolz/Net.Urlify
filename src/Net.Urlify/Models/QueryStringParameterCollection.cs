using System;
using Net.Urlify.Extensions;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Net.Urlify.Models
{
    [Serializable]
    internal class QueryStringParameterCollection : Dictionary<string, QueryStringParameterSettings>
    {
        internal QueryStringParameterCollection(Urlify sourceObject)
            : base(sourceObject.ToQueryStringParameters())
        { }

        internal QueryStringParameterCollection(IDictionary<string, QueryStringParameterSettings> queryStringParams)
            : base(queryStringParams)
        { }

        protected QueryStringParameterCollection(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }
}
