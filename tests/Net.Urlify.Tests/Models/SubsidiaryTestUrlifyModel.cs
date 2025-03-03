using Net.Urlify.Attributes;

namespace Net.Urlify.Tests.Models;

internal class SubsidiaryTestUrlifyModel : TestUrlifyModel
{
    [QueryStringProperty(isEncoded: false, order: 1)]
    public string QueryStringProperty1 { get; set; } = "value1/with spaces";

    [PathProperty(isEncoded: false, order: 1)]
    public string PathProperty1 { get; set; } = "value1 with spaces";
}