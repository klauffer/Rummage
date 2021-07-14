using Microsoft.Extensions.DependencyInjection;
using Rummage.FuzzySearch;
using Rummage.Tests.TestHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Rummage.Tests
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
            service.AddSearch<int>(FuzzySearchType.Levenshtein);
            service.AddTransient(_ => GetLogger());
            var provider = service.BuildServiceProvider();
            var searchEngine = provider.GetService<SearchEngine<int>>();
            Assert.NotNull(searchEngine);
        }
    }
}
