using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace Search.Tests.Infrastructure
{
    internal sealed class TestLoggerProvider : ILoggerProvider
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly LoggerExternalScopeProvider _scopeProvider = new LoggerExternalScopeProvider();

        public TestLoggerProvider(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new TestLogger(_testOutputHelper, _scopeProvider, categoryName);
        }

        public void Dispose()
        {
        }
    }
}
