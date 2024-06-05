namespace Net.Urlify.Models
{
    internal class QueryStringParameterSettings
    {
        internal string Value { get; }
        internal bool IsEncoded { get; }

        internal QueryStringParameterSettings(string value, bool isEncoded)
        {
            Value = value;
            IsEncoded = isEncoded;
        }
    }
}
