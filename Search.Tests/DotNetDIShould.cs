using Microsoft.Extensions.DependencyInjection;
using Search.FuzzySearch;
using Xunit;
using Xunit.Abstractions;

namespace Search.Tests
{
    public class DotNetDIShould : TestFixture
    {
        public DotNetDIShould(ITestOutputHelper outputHelper) : base(outputHelper, FuzzySearchType.Basic)
        {
        }

        [Fact]
        public void MapSearchEngine()
        {
            var service = new ServiceCollection();
            service.AddSearch(FuzzySearchType.Basic);
            service.AddTransient(_ => GetLogger());
            var provider = service.BuildServiceProvider();
            var searchEngine = provider.GetService<SearchEngine>();
            Assert.NotNull(searchEngine);
        }
    }
}
