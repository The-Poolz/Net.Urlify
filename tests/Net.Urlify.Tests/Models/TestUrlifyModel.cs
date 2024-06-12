using Net.Urlify.Attributes;

namespace Net.Urlify.Tests.Models;

public class TestUrlifyModel : Urlify
{
    [QueryStringProperty("param2", false, 2)]
    public string Param2 { get; set; } = "value2/with spaces";

    [QueryStringProperty(isEncoded: false, order: 3)]
    public string Param3 { get; set; } = "value3/with spaces";

    public TestUrlifyModel() : base("http://example.com") { }
}
