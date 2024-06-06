using Xunit;
using FluentAssertions;

namespace Net.Urlify.Tests
{
    public class UrlifyTests
    {
        [Fact]
        public void Test()
        {
            const string message = "hello world!";

            message.Should().Be(message);
        }
    }
}