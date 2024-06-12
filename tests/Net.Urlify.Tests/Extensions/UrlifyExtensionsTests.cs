using Xunit;
using FluentAssertions;
using Net.Urlify.Models;
using Net.Urlify.Extensions;
using Net.Urlify.Tests.Models;

namespace Net.Urlify.Tests.Extensions;

public class UrlifyExtensionsTests
{
	public class ToQueryStringParameters
    {
		[Fact]
		internal void ShouldConvertPropertiesCorrectly()
        {
            var model = new SubsidiaryTestUrlifyModel();

            var result = model.ToQueryStringParameters();

            result.Should().ContainKey("Param1")
                .And.Subject["Param1"].Should().BeEquivalentTo(new QueryStringParameterSettings("value1/with spaces", false, 1));
            result.Should().ContainKey("param2")
                .And.Subject["param2"].Should().BeEquivalentTo(new QueryStringParameterSettings("value2/with spaces", false, 2));
            result.Should().ContainKey("Param3")
                .And.Subject["Param3"].Should().BeEquivalentTo(new QueryStringParameterSettings("value3/with spaces", false, 3));
        }

        [Fact]
        internal void ShouldReturnEmpty_WhenNoAttributedProperties()
        {
            var model = new EmptyTestUrlifyModel();

            var result = model.ToQueryStringParameters();

            result.Should().BeEmpty();
        }

        [Fact]
        internal void ShouldIgnoreNullProperties()
        {
            var model = new NullPropertyTestUrlifyModel();

            var result = model.ToQueryStringParameters();

            result.Should().BeEmpty();
        }
    }
}
