namespace Net.Urlify.Tests.Models;

internal class EmptyTestUrlifyModel : Urlify
{
    public string Property1 { get; set; } = "value1";
    public int Property2 { get; set; } = 123;

    public EmptyTestUrlifyModel() : base("http://example.com") { }
}