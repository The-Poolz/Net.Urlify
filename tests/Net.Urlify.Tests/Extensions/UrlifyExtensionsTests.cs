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
            var model = new TestUrlifyModel();

            var result = model.ToQueryStringParameters();

            result.Should().ContainKey("param1")
                .And.Subject["param1"].Should().BeEquivalentTo(new QueryStringParameterSettings("value1/with spaces", false));
            result.Should().ContainKey("Param2")
                .And.Subject["Param2"].Should().BeEquivalentTo(new QueryStringParameterSettings("value2/with spaces", false));
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
