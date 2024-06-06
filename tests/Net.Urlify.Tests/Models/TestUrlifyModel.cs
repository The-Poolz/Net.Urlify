using Net.Urlify.Attributes;

namespace Net.Urlify.Tests.Models;

internal class TestUrlifyModel : Urlify
{
    [QueryStringProperty("param1", false)]
    public string Param1 { get; set; } = "value1/with spaces";

    [QueryStringProperty(isEncoded: false)]
    public string Param2 { get; set; } = "value2/with spaces";

    public TestUrlifyModel() : base("http://example.com") { }
}
