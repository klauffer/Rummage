using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Search.FuzzySearch;
using Xunit;
using Xunit.Abstractions;

namespace Search.Tests
{
    public class LevenshteinSearchShould
    {
        private ITestOutputHelper OutputHelper { get; }
        public LevenshteinSearchShould(ITestOutputHelper outputHelper)
        {
            OutputHelper = outputHelper;
        }

        [Fact]
        public async void FindExactMatch()
        {
            var searchEngine = SetUp();
            var searchResult = await searchEngine.Search("Homer Simpson");
            var actual = searchResult.FirstOrDefault(x => x.PhraseId == "1");
            Assert.Equal("1", actual.PhraseId);
            Assert.Equal("Homer Simpson", actual.MatchingPhrase);
        }

        [Fact]
        public async void FindSubsetMatch()
        {
            var searchEngine = SetUp();
            var searchResult = await searchEngine.Search("omer");
            var actual = searchResult.FirstOrDefault(x => x.PhraseId == "1");
            Assert.Equal("1", actual.PhraseId);
            Assert.Equal("Homer Simpson", actual.MatchingPhrase);
        }

        [Fact]
        public async void NotFindMatch()
        {
            var searchEngine = SetUp();
            var searchResult = await searchEngine.Search("qwerty");
            Assert.DoesNotContain(searchResult, x => x.MatchingPhrase == "qwerty");
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
            getData.Set.Add(new IndexItem("1", "Homer Simpson"));
            getData.Set.Add(new IndexItem("2", "Marge Simpson"));
            getData.Set.Add(new IndexItem("3", "Bart Simpson"));
            getData.Set.Add(new IndexItem("4", "Lisa Simpson"));
            getData.Set.Add(new IndexItem("5", "Maggie Simpson"));
            getData.Set.Add(new IndexItem("6", "Abraham Jebediah Simpson"));
            getData.Set.Add(new IndexItem("7", "Ned Flanders"));
            getData.Set.Add(new IndexItem("8", "Moe Szyslak")); 
            getData.Set.Add(new IndexItem("9", "Milhouse Van Houten"));
            var logger = TestLogger.CreateLogger<SearchEngine>(OutputHelper);
            return new SearchEngine(getData, FuzzySearchType.Levenshtein, logger);
        }

        private class GetData : IGetData
        {
            public HashSet<IndexItem> Set = new HashSet<IndexItem>();

            public Task<HashSet<IndexItem>> GetIndexedDataToSearch(CancellationToken cancellationToken) => Task.FromResult(Set);
        }
    }
}
