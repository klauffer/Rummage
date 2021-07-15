using Microsoft.Extensions.DependencyInjection;
using Rummage.FuzzySearch;
using Rummage.Tests.TestHelpers;
using Xunit;

namespace Rummage.Tests
{
    public sealed class DotNetDIShould : TestFixture
    {
        public DotNetDIShould() : base(FuzzySearchType.Levenshtein)
        {
        }

        [Fact]
        public void MapSearchEngine()
        {
            var service = new ServiceCollection();
            service.AddSearch<int>(FuzzySearchType.Levenshtein);
            var provider = service.BuildServiceProvider();
            var searchEngine = provider.GetService<SearchEngine<int>>();
            Assert.NotNull(searchEngine);
        }
    }
}
