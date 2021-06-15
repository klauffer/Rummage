using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Search.FuzzySearch;
using Xunit.Abstractions;

namespace Search.Tests
{
    public abstract class SetupFixture
    {
        private ITestOutputHelper OutputHelper { get; }
        public SetupFixture(ITestOutputHelper outputHelper)
        {
            OutputHelper = outputHelper;
        }

        protected SearchEngine SetUp(FuzzySearchType fuzzySearchType)
        {
            var getData = new GetData();
            getData.Set.Add(new IndexItem("1", "Homer Simpson"));
            getData.Set.Add(new IndexItem("2", "Marge Simpson"));
            getData.Set.Add(new IndexItem("3", "Bart Simpson"));
            getData.Set.Add(new IndexItem("4", "Lisa Simpson"));
            getData.Set.Add(new IndexItem("5", "Maggie Simpson"));
            getData.Set.Add(new IndexItem("6", "Abraham Jebediah Simpson"));
            getData.Set.Add(new IndexItem("7", "Ned Flanders"));
            getData.Set.Add(new IndexItem("8", "Moe Szyslak"));
            getData.Set.Add(new IndexItem("9", "Milhouse Van Houten"));
            var logger = GetLogger();
            return new SearchEngine(getData, fuzzySearchType, logger);
        }

        protected ILogger GetLogger() => TestLogger.CreateLogger<SearchEngine>(OutputHelper);

        private class GetData : IGetData
        {
            public HashSet<IndexItem> Set = new HashSet<IndexItem>();

            public Task<HashSet<IndexItem>> GetIndexedDataToSearch(CancellationToken cancellationToken) => Task.FromResult(Set);
        }
    }
}
