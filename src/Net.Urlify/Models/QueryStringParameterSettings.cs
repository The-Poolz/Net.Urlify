namespace Net.Urlify.Models
{
    internal class QueryStringParameterSettings
    {
        public string Value { get; }
        public bool IsEncoded { get; }

        internal QueryStringParameterSettings(string value, bool isEncoded)
        {
            Value = value;
            IsEncoded = isEncoded;
        }
    }
}
