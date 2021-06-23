using Microsoft.Extensions.DependencyInjection;
using Search.FuzzySearch;
using Search.Tests.TestHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Search.Tests
{
    public sealed class DotNetDIShould : TestFixture
    {
        public DotNetDIShould(ITestOutputHelper outputHelper) : base(outputHelper, FuzzySearchType.Levenshtein)
        {
        }

        [Fact]
        public void MapSearchEngine()
        {
            var service = new ServiceCollection();
            service.AddSearch(FuzzySearchType.Levenshtein);
            service.AddTransient(_ => GetLogger());
            var provider = service.BuildServiceProvider();
            var searchEngine = provider.GetService<SearchEngine>();
            Assert.NotNull(searchEngine);
        }
    }
}
