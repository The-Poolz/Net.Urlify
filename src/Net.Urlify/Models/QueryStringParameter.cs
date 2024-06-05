namespace Net.Urlify.Models
{
    public class QueryStringParameter
    {
        public string Value { get; }
        public bool IsEncoded { get; }

        public QueryStringParameter(string value, bool isEncoded)
        {
            Value = value;
            IsEncoded = isEncoded;
        }
    }
}
