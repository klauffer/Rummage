using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Search.FuzzySearch;
using Xunit;
using Xunit.Abstractions;
using Microsoft.Extensions.Logging;

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
            service.AddTransient<IGetData, GetData>();
            service.AddTransient(_ => GetLogger());
            var provider = service.BuildServiceProvider();
            var searchEngine = provider.GetService<ISearchEngine>();
            Assert.NotNull(searchEngine);
        }

        private class GetData : IGetData
        {
            public HashSet<IndexItem> Set = new HashSet<IndexItem>();

            public Task<HashSet<IndexItem>> GetIndexedDataToSearch(CancellationToken cancellationToken) => Task.FromResult(Set);
        }
    }
}
