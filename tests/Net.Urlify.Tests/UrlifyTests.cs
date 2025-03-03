using Xunit;
using FluentAssertions;
using Net.Urlify.Tests.Models;

namespace Net.Urlify.Tests;

public class UrlifyTests
{
    public class BuildUrl
    {
        [Fact]
        internal void BuildUrl_ShouldConstructUrlCorrectly_WithQueryParameters()
        {
            var model = new SubsidiaryTestUrlifyModel();

            var url = model.BuildUrl();

            url.ToString().Should().Be("http://example.com/value1%20with%20spaces/value2%20with%20spaces?QueryStringProperty1=value1%2Fwith%20spaces&queryStringProperty2=value2%2Fwith%20spaces&QueryStringProperty3=value3%2Fwith%20spaces");
        }

        [Fact]
        internal void BuildUrl_ShouldHandleNoQueryParameters()
        {
            var model = new EmptyTestUrlifyModel();

            var url = model.BuildUrl();

            url.ToString().Should().Be("http://example.com");
        }
    }
}