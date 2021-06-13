using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Search.FuzzySearch;
using Xunit;
using Xunit.Abstractions;

namespace Search.Tests
{
    public class BasicSearchShould
    {
        private ITestOutputHelper OutputHelper { get; }
        public BasicSearchShould(ITestOutputHelper outputHelper)
        {
            OutputHelper = outputHelper;
        }

        [Fact]
        public async void FindExactMatch()
        {
            var searchEngine = SetUp();
            var searchResult = await searchEngine.Search("Homer");
            var actual = searchResult.FirstOrDefault(x => x.PhraseId == "1");
            Assert.Equal("1", actual.PhraseId);
            Assert.Equal("Homer", actual.MatchingPhrase);
        }

        [Fact]
        public async void FindSubsetMatch()
        {
            var searchEngine = SetUp();
            var searchResult = await searchEngine.Search("ome");
            var actual = searchResult.FirstOrDefault(x => x.PhraseId == "1");
            Assert.Equal("1", actual.PhraseId);
            Assert.Equal("Homer", actual.MatchingPhrase);
        }

        [Fact]
        public async void NotFindMatch()
        {
            var searchEngine = SetUp();
            var searchResult = await searchEngine.Search("qwerty");
            Assert.Empty(searchResult);
        }

        [Fact]
        public async void CancelSearch()
        {
            var searchEngine = SetUp();
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;
            tokenSource.Cancel();
            await Assert.ThrowsAsync<OperationCanceledException>(async () => await searchEngine.Search("qqq", token));
        }

        private SearchEngine SetUp()
        {
            var getData = new GetData();
            getData.Set.Add(new IndexItem("1", "Homer"));
            var logger = TestLogger.CreateLogger<SearchEngine>(OutputHelper);
            return new SearchEngine(getData, FuzzySearchType.Basic, logger);
        }

        private class GetData : IGetData
        {
            public HashSet<IndexItem> Set = new HashSet<IndexItem>();

            public Task<HashSet<IndexItem>> GetIndexedDataToSearch(CancellationToken cancellationToken) => Task.FromResult(Set);
        }
    }
}
