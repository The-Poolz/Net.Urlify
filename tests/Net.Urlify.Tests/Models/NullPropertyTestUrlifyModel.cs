using Net.Urlify.Attributes;

namespace Net.Urlify.Tests.Models;

internal class NullPropertyTestUrlifyModel : Urlify
{
    [QueryStringProperty]
    public string? QueryStringProperty { get; set; } = null;

    [PathProperty]
    public string? PathProperty { get; set; } = null;

    public NullPropertyTestUrlifyModel() : base("http://example.com") { }
}