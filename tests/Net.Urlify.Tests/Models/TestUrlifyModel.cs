using Net.Urlify.Attributes;

namespace Net.Urlify.Tests.Models;

public class TestUrlifyModel : Urlify
{
    [QueryStringProperty("queryStringProperty2", false, 2)]
    public string QueryStringProperty2 { get; set; } = "value2/with spaces";

    [QueryStringProperty(isEncoded: false, order: 3)]
    public string QueryStringProperty3 { get; set; } = "value3/with spaces";

    [PathProperty(isEncoded: false, order: 2)]
    public string PathProperty2 { get; set; } = "value2 with spaces";

    public TestUrlifyModel() : base("http://example.com") { }
}
