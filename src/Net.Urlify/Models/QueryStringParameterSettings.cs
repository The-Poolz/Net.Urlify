namespace Net.Urlify.Models
{
    public class QueryStringParameterSettings
    {
        public string Value { get; }
        public bool IsEncoded { get; }

        public QueryStringParameterSettings(string value, bool isEncoded)
        {
            Value = value;
            IsEncoded = isEncoded;
        }
    }
}
