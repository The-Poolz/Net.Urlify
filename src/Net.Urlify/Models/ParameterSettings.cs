namespace Net.Urlify.Models
{
    internal class ParameterSettings
    {
        public string Value { get; }
        public bool IsEncoded { get; }
        public int Order { get; }

        internal ParameterSettings(string value, bool isEncoded, int order)
        {
            Value = value;
            IsEncoded = isEncoded;
            Order = order;
        }
    }
}
