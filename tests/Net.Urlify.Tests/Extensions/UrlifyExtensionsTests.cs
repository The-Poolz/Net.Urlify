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

            result.Should().ContainKey("QueryStringProperty1")
                .And.Subject["QueryStringProperty1"].Should().BeEquivalentTo(new ParameterSettings("value1/with spaces", false, 1));
            result.Should().ContainKey("queryStringProperty2")
                .And.Subject["queryStringProperty2"].Should().BeEquivalentTo(new ParameterSettings("value2/with spaces", false, 2));
            result.Should().ContainKey("QueryStringProperty3")
                .And.Subject["QueryStringProperty3"].Should().BeEquivalentTo(new ParameterSettings("value3/with spaces", false, 3));
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

    public class ToPathParameters
    {
        [Fact]
        internal void ShouldConvertPropertiesCorrectly()
        {
            var model = new SubsidiaryTestUrlifyModel();

            var result = model.ToPathParameters();

            result.Should().ContainKey("PathProperty1")
                .And.Subject["PathProperty1"].Should().BeEquivalentTo(new ParameterSettings("value1 with spaces", false, 1));
            result.Should().ContainKey("PathProperty2")
                .And.Subject["PathProperty2"].Should().BeEquivalentTo(new ParameterSettings("value2 with spaces", false, 2));
        }

        [Fact]
        internal void ShouldReturnEmpty_WhenNoAttributedProperties()
        {
            var model = new EmptyTestUrlifyModel();

            var result = model.ToPathParameters();

            result.Should().BeEmpty();
        }

        [Fact]
        internal void ShouldIgnoreNullProperties()
        {
            var model = new NullPropertyTestUrlifyModel();

            var result = model.ToPathParameters();

            result.Should().BeEmpty();
        }
    }
}
