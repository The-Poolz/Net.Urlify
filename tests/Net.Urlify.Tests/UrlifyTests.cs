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

            url.ToString().Should().Be("http://example.com?Param1=value1%2Fwith%20spaces&param2=value2%2Fwith%20spaces&Param3=value3%2Fwith%20spaces");
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