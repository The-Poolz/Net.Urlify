namespace Net.Urlify.Models
{
    internal class QueryStringParameterSettings
    {
        public string Value { get; }
        public bool IsEncoded { get; }
        public int Order { get; }

        internal QueryStringParameterSettings(string value, bool isEncoded, int order)
        {
            Value = value;
            IsEncoded = isEncoded;
            Order = order;
        }
    }
}
