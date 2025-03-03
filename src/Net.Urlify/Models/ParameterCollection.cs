using System;
using Net.Urlify.Extensions;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Net.Urlify.Models
{
    [Serializable]
    internal class ParameterCollection : Dictionary<string, ParameterSettings>
    {
        internal ParameterCollection(Urlify sourceObject)
            : base(sourceObject.ToQueryStringParameters())
        { }

        internal ParameterCollection(IDictionary<string, ParameterSettings> queryStringParams)
            : base(queryStringParams)
        { }

        protected ParameterCollection(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }
}
