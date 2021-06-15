using Microsoft.Extensions.DependencyInjection;
using Search.FuzzySearch;
using Xunit;
using Xunit.Abstractions;

namespace Search.Tests
{
    public class DotNetDIShould : SetupFixture
    {
        public DotNetDIShould(ITestOutputHelper outputHelper) : base(outputHelper)
        {
        }

        [Fact]
        public void MapSearchEngine()
        {
            var service = new ServiceCollection();
            service.AddSearch(FuzzySearchType.Basic);
            service.AddTransient(_ => GetLogger());
            var provider = service.BuildServiceProvider();
            var searchEngine = provider.GetService<ISearchEngine>();
            Assert.NotNull(searchEngine);
        }
    }
}
