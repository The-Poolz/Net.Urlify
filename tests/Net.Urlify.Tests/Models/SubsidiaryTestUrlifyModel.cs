using Net.Urlify.Attributes;

namespace Net.Urlify.Tests.Models;

internal class SubsidiaryTestUrlifyModel : TestUrlifyModel
{
    [QueryStringProperty(isEncoded: false, order: 1)]
    public string Param1 { get; set; } = "value1/with spaces";
}