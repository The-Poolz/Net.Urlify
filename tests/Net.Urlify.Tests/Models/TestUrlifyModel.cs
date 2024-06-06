using Net.Urlify.Attributes;

namespace Net.Urlify.Tests.Models;

internal class TestUrlifyModel : Urlify
{
    [QueryStringProperty("property1")]
    public string Property1 { get; set; } = "value1";

    [QueryStringProperty(isEncoded: false)]
    public int Property2 { get; set; } = 123;

    public TestUrlifyModel() : base("http://example.com") { }
}
