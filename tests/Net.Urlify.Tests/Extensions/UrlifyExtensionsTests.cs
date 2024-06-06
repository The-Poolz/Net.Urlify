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

            result.Should().ContainKey("property1")
                .And.Subject["property1"].Should().BeEquivalentTo(new QueryStringParameterSettings("value1", true));
            result.Should().ContainKey("Property2")
                .And.Subject["Property2"].Should().BeEquivalentTo(new QueryStringParameterSettings("123", false));
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
