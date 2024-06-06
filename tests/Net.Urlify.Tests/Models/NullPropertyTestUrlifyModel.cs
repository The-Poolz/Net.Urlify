using Net.Urlify.Attributes;

namespace Net.Urlify.Tests.Models;

internal class NullPropertyTestUrlifyModel : Urlify
{
    [QueryStringProperty("property1")]
    public string? Property1 { get; set; } = null;

    public NullPropertyTestUrlifyModel() : base("http://example.com") { }
}